using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DTOs.Photos;
using Entities.Models;
using GUNAAPugetSound.Entities;
using GUNAAPugetSound.Helpers;
using GUNAAPugetSound.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace GUNAAPugetSound.Services
{
    public interface IPhotoService
    {
        PhotosResponse GetPhotoById(Guid id);
        IEnumerable<PhotosResponse> GetPhotosByAlbumId(Guid albumId);
        IEnumerable<PhotosResponse> GetAllPhotos();
        PhotoAlbumResponse GetAlbumByAlbumId(Guid albumId);
        IEnumerable<PhotoAlbumResponse> GetAllAlbums();
        PhotosResponse CreatePhoto(AddPhotoRequest model, int accountId);
        IEnumerable<PhotosResponse> CreatePhotos(List<AddPhotoRequest> model, int accountId);
        PhotoAlbumResponse CreateAlbum(CreateAlbumRequest model, int accountId);
        PhotosResponse UpdatePhoto(int id,UpdatePhotosRequest model, int accountId);
        PhotoAlbumResponse UpdateAlbum(int id, UpdatePhotoAlbumRequest model, int accountId);
        void DeleteAlbum(Guid id);
        void DeletePhoto(Guid id);
    }

    public class PhotosService : IPhotoService
    {
        private readonly GUNAADbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PhotosService(
            GUNAADbContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService,
            IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
            _webHostEnvironment = env; 
        }
        public PhotosResponse GetPhotoById(Guid id)
        {
            var photo = getPhoto(id);
            return _mapper.Map<PhotosResponse>(photo);
        }

        public IEnumerable<PhotosResponse> GetPhotosByAlbumId(Guid albumId)
        {
            var photos = getPhotosByAlbumId(albumId);
            return _mapper.Map<List<PhotosResponse>>(photos);
        }

        public IEnumerable<PhotosResponse> GetAllPhotos()
        {
            var photos = _context.Photos;
            return _mapper.Map<IList<PhotosResponse>>(photos);
        }

        public PhotoAlbumResponse GetAlbumByAlbumId(Guid albumId)
        {
            var album = getAlbum(albumId);
            return _mapper.Map<PhotoAlbumResponse>(album);
        }

        public IEnumerable<PhotoAlbumResponse> GetAllAlbums()
        {
            var albums = _context.Albums;
            return _mapper.Map<IList<PhotoAlbumResponse>>(albums);
        }

        public PhotosResponse CreatePhoto(AddPhotoRequest model, int accountId)
        {
            // validate
            if (_context.Photos.Any(x => x.Id == model.Id))
                throw new AppException($"Photo has already been added.");

            var photo = createPhoto(model, accountId);
            return _mapper.Map<PhotosResponse>(photo);
        }

        public IEnumerable<PhotosResponse> CreatePhotos(List<AddPhotoRequest> model, int accountId)
        {
            var photos = createPhotos(model, accountId);
            return _mapper.Map<List<PhotosResponse>>(photos);
        }

        public PhotoAlbumResponse CreateAlbum(CreateAlbumRequest model, int accountId)
        {
            // validate
            if (_context.Albums.Any(x => x.Id == model.Id || x.Name == model.Name))
                throw new AppException($"Album has already been added.");

            var photo = createAlbum(model, accountId);
            return _mapper.Map<PhotoAlbumResponse>(photo);
        }

        public PhotosResponse UpdatePhoto(int id, UpdatePhotosRequest model, int accountId)
        {
            throw new NotImplementedException();
        }

        public PhotoAlbumResponse UpdateAlbum(int id, UpdatePhotoAlbumRequest model, int accountId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAlbum(Guid id)
        {
            //Get Photos related to album Id
            var photos = _context.Photos.Where(p => p.AlbumId == id);
            //Delete the list of photos
            foreach (var photo in photos)
            {
                _context.Photos.Remove(photo);
            }

            //_context.SaveChanges();

            //Delete Album Record 
            var album = getAlbum(id);
            _context.Albums.Remove(album);
            _context.SaveChanges();
        }

        public void DeletePhoto(Guid id)
        {
            var photo = getPhoto(id);
            _context.Photos.Remove(photo);
            _context.SaveChanges();
        }

        #region Helper Methods

        private Photo getPhoto(Guid id)
        {
            var photo = _context.Photos.Find(id);
            if(photo == null) throw new KeyNotFoundException("Photo could not be found.");
            return photo; 
        }

        private IEnumerable<PhotosResponse> getPhotosByAlbumId(Guid id)
        {
            var photos = _context.Photos.Where(p => p.AlbumId == id);
            return _mapper.Map<IList<PhotosResponse>>(photos);
        }

        private Album getAlbum(Guid id)
        {
            var album = _context.Albums.Find(id);
            if (album == null) throw new KeyNotFoundException("Album could not be found.");
            return album;
        }

        private async Task<Photo> createPhoto(AddPhotoRequest model, int accountId)
        {
            //Save image to wwwroot/image
            saveImageToRoot(model);
            //Insert record
            _context.Add(model);

            // map model to new account object
            var photo = _mapper.Map<Photo>(model);

            photo.Id = Randomness.Guid();
            photo.Created = DateTime.UtcNow;
            photo.AddedBy = accountId;

            // save photo
            await _context.Photos.AddAsync(photo);
            await _context.SaveChangesAsync();
            return photo; 
        }

        private List<Photo> createPhotos(List<AddPhotoRequest> photos, int accountId)
        {
            // map model to new account object
            var createdPhotos = _mapper.Map<List<Photo>>(photos);
            foreach (var photo in createdPhotos)
            {
                photo.Id = Randomness.Guid();
                photo.Created = DateTime.UtcNow;
                photo.AddedBy = accountId;
                _context.Photos.Add(photo);
            }

            // save photos
            _context.SaveChanges();
            return createdPhotos;
        }

        private Album createAlbum(CreateAlbumRequest model, int accountId)
        {
            // map model to new account object
            var album = _mapper.Map<Album>(model);
            album.Id = Randomness.Guid();
            album.Created = DateTime.UtcNow;
            album.CreatedBy = accountId;

            // save photo
            _context.Albums.Add(album);
            _context.SaveChanges();
            return album;
        }

        private async void saveImageToRoot(AddPhotoRequest model)
        {


            //// Combines two strings into a path.
            //fileName = Path.Combine(_iWebHostEnvironment.WebRootPath, "GalleryImages") + $@"\{finalName}";

            //// if you want to store path of folder in database
            //var thumbPath = $"/GalleryImages/thumbs/{fileName}{extension}";
            //var imagePath = $"/GalleryImages/{fileName}{extension}";

            //using (FileStream fs = System.IO.File.Create(fileName))
            //{
            //    file.CopyTo(fs);
            //    fs.Flush();
            //}

            //var photo = new Photo(new Guid(model.AlbumId), model.PhotoDesc, imagePath, thumbPath, userDto.Username);
            ////Save to db
            //_photoData.Create(photo);

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

        public Image GetReducedImage(int width, int height, Stream resourceImage)
        {
            try
            {
                Image image = Image.FromStream(resourceImage);
                Image thumb = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);

                return thumb;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private void addPhoto(AddPhotoRequest model)
        {


            //try
            //{

            //    //var album = new Photo(model.AlbumName, model.AlbumDesc, userDto.Username, userDto.Username);
            //    var photoFileList = photoDto.Files as IList<IFormFile> ?? photoDto.Files.ToList();
            //    // save 
            //    foreach (var file in photoFileList)
            //    {
            //        if (file.Length > 0)
            //        {
            //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

            //            //Assigning Unique Filename (Guid)
            //            var uniquteFileName = Guid.NewGuid().ToString();

            //            //Getting file Extension
            //            var extension = System.IO.Path.GetExtension(file.FileName).ToLower();

            //            // concating  FileName + FileExtension
            //            var finalName = uniquteFileName + extension;

            //            // Combines two strings into a path.
            //            fileName = Path.Combine(_iWebHostEnvironment.WebRootPath, "GalleryImages") + $@"\{finalName}";

            //            // if you want to store path of folder in database
            //            var thumbPath = $"/GalleryImages/thumbs/{fileName}{extension}";
            //            var imagePath = $"/GalleryImages/{fileName}{extension}";

            //            using (FileStream fs = System.IO.File.Create(fileName))
            //            {
            //                file.CopyTo(fs);
            //                fs.Flush();
            //            }

            //            var photo = new Photo(new Guid(model.AlbumId), model.PhotoDesc, imagePath, thumbPath, userDto.Username);
            //            //Save to db
            //            //_photoData.Create(photo);

            //            //string webRootPath = _hostingEnvironment.WebRootPath;
            //            //string newPath = Path.Combine(webRootPath, folderName);
            //            //if (!Directory.Exists(newPath))
            //            //{
            //            //    Directory.CreateDirectory(newPath);
            //            //}
            //            //if (file.Length > 0)
            //            //{
            //            //    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //            //    string fullPath = Path.Combine(newPath, fileName);
            //            //    using (var stream = new FileStream(fullPath, FileMode.Create))
            //            //    {
            //            //        file.CopyTo(stream);
            //            //    }
            //            //}

            //        }
            //    }
            //    return Ok("successfully added all photos");
            //}
            //catch (AppException ex)
            //{
            //    // return error message if there was an exception
            //    return BadRequest(new { message = ex.Message });
            //}
        }


        #endregion




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

        //        using (var img = System.Drawing..FromStream(file.InputStream))
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


        public Size NewImageSize(Size imageSize, Size newSize)
        {
            Size finalSize;
            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                double tempval;
                if (imageSize.Height > imageSize.Width)
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                else
                    tempval = newSize.Width / (imageSize.Width * 1.0);

                finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
            }
            else
                finalSize = imageSize; // image is already small size

            return finalSize;
        }

        //private void SaveToFolder(Image img, string fileName, string extension, Size newSize, string path)
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
