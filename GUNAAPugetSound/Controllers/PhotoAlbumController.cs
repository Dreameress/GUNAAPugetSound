using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Net.Http.Headers;
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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GUNAAPugetSound.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoAlbumController : Controller
    {
        private IMapper _mapper;
        private IAlbumData _albumData;
        private IPhotoData _photoData;
        private IUserService _userService;
        private IHostingEnvironment _hostingEnvironment;
        // GET: PhtotoAlbum
        public PhotoAlbumController(IAlbumData albumData, IPhotoData photoData, IUserService userService, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _userService = userService;
            _mapper = mapper;
            _albumData = albumData;
            _photoData = photoData;
            _hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var photoAlbums = _albumData.GetAll();
                var photosDTo = _mapper.Map<IList<Album>>(photoAlbums);
                return Ok(photosDTo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult GetAllPhotos(DeleteDto dto)
        {
            try
            {
                var photos = _photoData.GetAllByAlbumId(new Guid(dto.Guid.Id));
                var photosDTo = _mapper.Map<IList<Photo>>(photos);
                return Ok(photosDTo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost("[action]")]
        public IActionResult GetById(DeleteDto dto)
        {
            try
            {
                var model = _albumData.Get(new Guid(dto.Guid.Id));
                var albumDto = _mapper.Map<Album>(model);
                return Ok(albumDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("[action]")]
        public IActionResult Create(AlbumDto albumDto)
        {
            try
            {
                var userDto = albumDto.User;
                var model = albumDto.Model;

                var album = new Album(model.AlbumName, model.AlbumDesc, userDto.Username, userDto.Username);


                // save 
                _albumData.Add(album);
                return Ok(album);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpPost("[action]"), DisableRequestSizeLimit]
        public IActionResult CreatePhotos(PhotoDto photoDto)
        {
          

            try
            {
                var userDto = photoDto.User;
                var model = photoDto.Model;

                //var album = new Photo(model.AlbumName, model.AlbumDesc, userDto.Username, userDto.Username);
                var photoFileList = photoDto.Files as IList<IFormFile> ?? photoDto.Files.ToList();
                // save 
                foreach (var file in photoFileList)
                {
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        //Assigning Unique Filename (Guid)
                        var uniquteFileName = Guid.NewGuid().ToString();

                        //Getting file Extension
                        var extension = System.IO.Path.GetExtension(file.FileName).ToLower();

                        // concating  FileName + FileExtension
                        var finalName = uniquteFileName + extension;

                        // Combines two strings into a path.
                        fileName = Path.Combine(_hostingEnvironment.WebRootPath, "GalleryImages") + $@"\{finalName}";

                        // if you want to store path of folder in database
                        var thumbPath = $"/GalleryImages/thumbs/{fileName}{extension}";
                        var imagePath = $"/GalleryImages/{fileName}{extension}";

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        var photo = new Photo(new Guid(model.AlbumId), model.PhotoDesc, imagePath, thumbPath, userDto.Username);
                        //Save to db
                        _photoData.Add(photo);

                        //string webRootPath = _hostingEnvironment.WebRootPath;
                        //string newPath = Path.Combine(webRootPath, folderName);
                        //if (!Directory.Exists(newPath))
                        //{
                        //    Directory.CreateDirectory(newPath);
                        //}
                        //if (file.Length > 0)
                        //{
                        //    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        //    string fullPath = Path.Combine(newPath, fileName);
                        //    using (var stream = new FileStream(fullPath, FileMode.Create))
                        //    {
                        //        file.CopyTo(stream);
                        //    }
                        //}

                    }
                }
                return Ok("successfully added all photos");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("[action]")]
        public IActionResult Edit(AlbumDto albumDto)
        {

            try
            {

                var userDto = albumDto.User;
                var model = albumDto.Model;


                if (albumDto.Guid == null) return Ok();
                var album = _albumData.Get(albumDto.Guid.Value);
                if (album == null)
                {
                    return BadRequest(new { message = "No Album Found." });
                }

                album.LastEditBy = userDto.Username;
                album.AlbumDesc = model.AlbumDesc;
                album.AlbumName = model.AlbumName;

                // save 
                _albumData.Edit(album);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpDelete("[action]")]
        public IActionResult Delete(DeleteDto dto)
        {
            try
            {
                var photos = _photoData.GetAllByAlbumId(new Guid(dto.Guid.Id));
                var photosDTo = _mapper.Map<IList<Photo>>(photos);
                return Ok(photosDTo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var model = _albumData.Get(new Guid(dto.Guid.Id));
            if (model == null)
            {
                return BadRequest(new { message = "Album does not exist." });
            }
            _albumData.Delete(model);
            return Ok(new { message = "Album deleted!"});

        }

        [HttpPost("[action]")]
        public ActionResult ShowPhotoAlbum(DeleteDto album)
        {
            try
            {
                string filter = null;
                int page = 1;
                int pageSize = 16;

                var photos = _photoData.GetAllByAlbumId(new Guid(album.Guid.Id));
                return Ok(photos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }

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
    
