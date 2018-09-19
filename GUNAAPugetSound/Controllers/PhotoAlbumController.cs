using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using GUNAAPugetSound.DTOs;
using GUNAAPugetSound.Entities;
using GUNAAPugetSound.Helpers;
using GUNAAPugetSound.Models;
using GUNAAPugetSound.Services;
using GUNAAPugetSound.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GUNAAPugetSound.Controllers
{
    [Route("api/[controller]")]
    public class PhotoAlbumController : Controller
    {
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IAlbumData _albumData;
        private readonly IPhotoData _photoData;
        private IUserService _userService;
        private GUNAADbContext _db;
        // GET: PhtotoAlbum
        public PhotoAlbumController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings, IAlbumData albumData, IPhotoData photoData)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _albumData = albumData;
            _photoData = photoData;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {

            var photoAlbums = _albumData.GetAll();
            var photosDTo = _mapper.Map<IList<Album>>(photoAlbums);
            return Ok(photosDTo);
        }

        [HttpGet("[action]")]
        public IActionResult GetById(Guid id)
        {
            var photoAlbum = _albumData.Get(id);
            var albumDto = _mapper.Map<Album>(photoAlbum);
            return Ok(albumDto);
        }

        [HttpPost("[action]")]
        public IActionResult Create(AlbumEditViewModel model, UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);
            var userId = user.Id;
            //TODO: create a function that uses the userId to get all other data from Identity
            var album = new Album(model.AlbumName, model.AlbumDesc);

            try
            {
                // save 
                _albumData.Add(album);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("[action]")]
        public IActionResult Edit(Guid id, AlbumEditViewModel input)
        {

            try
            {
                var model = _albumData.Get(id);
                if (model == null)
                {
                    return BadRequest(new { message = "No Album Found." });
                }
                // save 
                var album = new Album(input.AlbumName, input.AlbumDesc, id);
                _albumData.Edit(album);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("[action]")]
        public IActionResult Delete(Guid id)
        {
            var model = _albumData.Get(id);
            if (model == null)
            {
                return BadRequest(new { message = "Album does not exist." });
            }
            _albumData.Delete(model);
            return Ok();

        }

        public IActionResult Details(Guid id)
        {
            var model = _albumData.Get(id);
            if (model == null)
            {
                BadRequest("Album Does Not Exist");
            }
            return Ok(model);
        }

        //public ActionResult ShowPhotoAlbum(Guid albumGuid, string filter = null, int page = 1, int pageSize = 16)
        //{

        //    PhotoAlbumViewModel model;
        //    if (!_photoData.GetAllByAlbumId(albumGuid).Any())
        //    {
        //        model = new PhotoAlbumViewModel() { NoPhotos = true, SelectedAlbum = _albumData.Get(albumGuid) };
        //        return View(model);
        //    }
        //    model = new PhotoAlbumViewModel
        //    {
        //        SelectedAlbum = _albumData.Get(albumGuid),
        //        Photos = _photoData.GetAllByAlbumId(albumGuid),
        //        NoPhotos = false
        //    };
        //    //model.Records.Content =
        //    //    _photoData.GetAllByAlbumId(albumGuid)
        //    //        .OrderByDescending(x => x.CreatedOn)
        //    //        .Skip((page - 1)*pageSize)
        //    //        .Take(pageSize)
        //    //        .ToList();


        //    model.TotalRecords = model.Photos.Count(x => filter == null || (x.Description.Contains(filter)));

        //    model.CurrentPage = page;
        //    model.PageSize = pageSize;

        //    return View(model);
        //}

        //public ActionResult AddPhoto()
        //{
        //    var photo = new Photo();
        //    return View(photo);
        //}
        //[HttpPost("[action]")]
        //public ActionResult AddPhoto(Guid id, Photo photo, IEnumerable<HttpPostedFileBase> files)
        //{
        //    if (!ModelState.IsValid)
        //        return View();
        //    var httpPostedFileBases = files as IList<HttpPostedFileBase> ?? files.ToList();
        //    var count = httpPostedFileBases.Count();
        //    var first = httpPostedFileBases.FirstOrDefault();
        //    if (count == 0 || first == null)
        //    {
        //        ViewBag.error = "Please choose a file";
        //        return View();
        //    }

        //    foreach (var file in httpPostedFileBases)
        //    {
        //        if (file.ContentLength == 0) continue;

        //        var fileName = Guid.NewGuid().ToString();
        //        var extension = System.IO.Path.GetExtension(file.FileName).ToLower();

        //        using (var img = System.Drawing.Image.FromStream(file.InputStream))
        //        {
        //            var thumbPath = $"/GalleryImages/thumbs/{fileName}{extension}";
        //            var imagePath = $"/GalleryImages/{fileName}{extension}";

        //            // Save thumbnail size image, 100 x 100
        //            SaveToFolder(img, fileName, extension, new Size(100, 100), thumbPath);

        //            // Save large size image, 800 x 800
        //            SaveToFolder(img, fileName, extension, new Size(600, 600), imagePath);
        //            var model = new Photo(id, photo.Description, imagePath, thumbPath);
        //            //Save to db
        //            _photoData.Add(model);
        //        }

        //    }

        //    return RedirectToAction("Photos", new { id = photo.Id });
        //}

        ////[HttpGet]
        ////public ActionResult UploadImage()
        ////{
        ////    return View();
        ////}
        //[HttpPost("[action]")]
        //public ActionResult UploadImageMethod()
        //{
        //    if (Request.Files.Count != 0)
        //    {
        //        for (int i = 0; i < Request.Files.Count; i++)
        //        {
        //            //HttpPostedFileBase file = Request.Files[i];
        //            //int fileSize = file.ContentLength;
        //            //string fileName = file.FileName;
        //            //file.SaveAs(Server.MapPath("~/Uploaded_Files/" + fileName));
        //            //Photo imageGallery = new Photo();
        //            //imageGallery.Id = Guid.NewGuid();
        //            //imageGallery.Name = fileName;
        //            //imageGallery.ImagePath = "~/Upload_Files/" + fileName;
        //            //db.ImageGallery.Add(imageGallery);
        //            //db.SaveChanges();
        //        }
        //        return Content("Success");
        //    }
        //    return Content("failed");
        //}

        //public Size NewImageSize(Size imageSize, Size newSize)
        //{
        //    Size finalSize;
        //    if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
        //    {
        //        double tempval;
        //        if (imageSize.Height > imageSize.Width)
        //            tempval = newSize.Height / (imageSize.Height * 1.0);
        //        else
        //            tempval = newSize.Width / (imageSize.Width * 1.0);

        //        finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
        //    }
        //    else
        //        finalSize = imageSize; // image is already small size

        //    return finalSize;
        //}
        //private void SaveToFolder(MediaTypeNames.Image img, string fileName, string extension, Size newSize, string pathToSave)
        //{
        //    // Get new resolution
        //    Size imgSize = NewImageSize(img.Size, newSize);
        //    using (System.Drawing.Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
        //    {
        //        newImg.Save(Server.MapPath(pathToSave), img.RawFormat);
        //    }
        //}
    }
}
    
