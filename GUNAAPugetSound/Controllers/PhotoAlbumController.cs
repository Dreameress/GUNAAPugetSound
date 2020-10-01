using System;
using System.Collections.Generic;
using GUNAAPugetSound.Entities.Enums;
using GUNAAPugetSound.Models.Photos;
using GUNAAPugetSound.Services;
using Microsoft.AspNetCore.Mvc;

namespace GUNAAPugetSound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoAlbumsController : BaseController
    {
        private readonly IPhotoService _photoService;
        public PhotoAlbumsController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        #region Get Photos & Albums
        [HttpGet]
        public ActionResult<PhotosResponse> GetPhotoById(Guid id)
        {
            PhotosResponse photo = _photoService.GetPhotoById(id);
            return Ok(photo);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PhotosResponse>> GetAllPhotos()
        {
            IEnumerable<PhotosResponse> photos = _photoService.GetAllPhotos();
            return Ok(photos);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PhotosResponse>> GetPhotosByAlbumId(Guid id)
        {
            IEnumerable<PhotosResponse> photos = _photoService.GetPhotosByAlbumId(id);
            return Ok(photos);
        }

        [HttpGet]
        public ActionResult<PhotoAlbumResponse> GetAllPhotoAlbums(Guid id)
        {
            PhotoAlbumResponse album = _photoService.GetAlbumByAlbumId(id);
            return Ok(album);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PhotoAlbumResponse>> GetAllPhotoAlbums()
        {
            IEnumerable<PhotoAlbumResponse> albums = _photoService.GetAllAlbums();
            return Ok(albums);
        }

        #endregion

        #region Create Albums & Add Photos

        [Helpers.Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<PhotoAlbumResponse> CreateAlbum(CreateAlbumRequest model)
        {
            // only admins can create albums
            var album = _photoService.CreateAlbum(model, Account.Id);
            return Ok(album);
        }

        [Helpers.Authorize(Role.Admin), DisableRequestSizeLimit]
        [HttpPost]
        public ActionResult<PhotosResponse> AddPhoto([Bind("ImageId,Title,ImageName")] AddPhotoRequest model)
        {
            // only admins can add a photo
            var account = _photoService.CreatePhoto(model, Account.Id);
            return Ok(account);
        }

        [Helpers.Authorize(Role.Admin), DisableRequestSizeLimit]
        [HttpPost]
        public ActionResult<PhotosResponse> AddPhotos(List<AddPhotoRequest> model)
        {
            // only admins can add photos
            var account = _photoService.CreatePhotos(model, Account.Id);
            return Ok(account);
        }
        #endregion

        #region Update Photos & Albums


        [Helpers.Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<PhotoAlbumResponse> UpdateAlbum(int id, UpdatePhotoAlbumRequest model)
        {
            // only admins can update albums
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _photoService.UpdateAlbum(id, model, Account.Id);
            return Ok(account);
        }


        [Helpers.Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<PhotosResponse> UpdatePhoto(int id, UpdatePhotosRequest model)
        {
            // only admins can update photos
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _photoService.UpdatePhoto(id, model, Account.Id);
            return Ok(account);
        }
        #endregion

        #region Delete Photos & Albums

        [Helpers.Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult DeletePhoto(Guid id)
        {
            // only admins can delete photos
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            _photoService.DeletePhoto(id);
            return Ok(new { message = "Photo deleted successfully" });
        }

        [Helpers.Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteAlbum(Guid id)
        {
            // only admins can delete albums
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            _photoService.DeleteAlbum(id);
            return Ok(new { message = "Photo Album deleted successfully" });
        }

        #endregion
    }
}
    
