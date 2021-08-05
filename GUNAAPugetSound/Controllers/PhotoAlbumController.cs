using System;
using System.Collections.Generic;
using AutoMapper;
using Contracts;
using Entities.DTOs.Photos;
using Entities.Models;
using GUNAAPugetSound.Entities.Enums;
using GUNAAPugetSound.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GUNAAPugetSound.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoAlbumsController : BaseController
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public PhotoAlbumsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }


        #region Get Photos & Albums
        //[HttpGet("{id:Guid}")]
        //public ActionResult<PhotoResponse> GetPhotoById(Guid id)
        //{
        //    var photo = _mapper.Map<PhotoResponse>( _repository.Photo.GetPhotoById(id));
        //    _logger.LogInfo("Returned Photo from database");
        //    return Ok(photo);
        //}

        [HttpGet("photos")]
        public ActionResult<IEnumerable<PhotoResponse>> GetAllPhotos()
        {
            var photos = _mapper.Map<IEnumerable<PhotoResponse>>(_repository.Photo.GetAllPhotos());
            _logger.LogInfo("Returned a list of Photos from database");
            return Ok(photos);
        }

        //[HttpGet("{id:Guid}")]
        //public ActionResult<IEnumerable<PhotoResponse>> GetPhotosByAlbumId(Guid id)
        //{
        //    var photos = _mapper.Map<IEnumerable<PhotoResponse>>(_repository.Photo.GetPhotosByAlbumId(id));
        //    _logger.LogInfo("Returned all photos from album in database");
        //    return Ok(photos);
        //}

        //[HttpGet("{id:Guid}")]
        //public ActionResult<PhotoAlbumResponse> GetAlbumById(Guid id)
        //{
        //    var album = _mapper.Map<PhotoAlbumResponse>(_repository.Album.GetAlbumByAlbumId(id));
        //    _logger.LogInfo("Returned Album from database");
        //    return Ok(album);
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<PhotoAlbumResponse>> GetAllPhotoAlbums()
        //{
        //    var albums = _mapper.Map<IEnumerable<PhotoAlbumResponse>>(_repository.Album.GetAllAlbums());
        //    _logger.LogInfo("Returned a list of all Albums from database");
        //    return Ok(albums);
        //}

        #endregion

        #region Create Albums & Add Photos

        [Helpers.Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<PhotoAlbumResponse> CreateAlbum(CreatePhotoAlbumRequest model)
        {
            // only admins can create albums
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            if (_repository.Album.AlbumNameExists(model.Name))
                throw new AppException($"Album with this name already exists.");

            var album = _mapper.Map<Album>(model);
            _repository.Album.CreateAlbum(ref album, Account.Id);
            _logger.LogInfo("Created Photo Album");
            var photoAlbumResponse = _mapper.Map<PhotoAlbumResponse>(album);
            return Ok(photoAlbumResponse);
        }

        [Helpers.Authorize(Role.Admin), DisableRequestSizeLimit]
        [HttpPost]
        public ActionResult<PhotoResponse> AddPhoto([Bind("ImageId,Title,ImageName")] AddPhotoRequest model)
        {
            // only admins can create albums
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var photo = _mapper.Map<Photo>(model);
            _repository.Photo.CreatePhoto(ref photo, Account.Id);
            // only admins can create albums
            var photoResponse = _mapper.Map<PhotoResponse>(photo);
            _logger.LogInfo("Added Photo to Photo Album");
            return Ok(photoResponse);
        }

        [Helpers.Authorize(Role.Admin), DisableRequestSizeLimit]
        [HttpPost]
        public ActionResult<List<PhotoResponse>> AddPhotos(List<AddPhotoRequest> model)
        {
            // only admins can create albums
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });
            //map photos 
            var photos = _mapper.Map<IEnumerable<Photo>>(model);
            _repository.Photo.CreatePhotos(ref photos, Account.Id);

            // only admins can add photos
            var photosResponse = _mapper.Map<IEnumerable<PhotoResponse>>(photos);
            _logger.LogInfo("Added multiple photos to Photo Album");
            return Ok(photosResponse);
        }
        #endregion

        #region Update Photos & Albums
        [Helpers.Authorize]
        [HttpPut]
        public ActionResult<PhotoAlbumResponse> UpdateAlbum(UpdatePhotoAlbumRequest model)
        {
            // only admins can update albums
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var album = _repository.Album.GetAlbumByAlbumId(model.Id);
            // copy model to account and save
            _mapper.Map(model, album);

            _repository.Album.UpdateAlbum(ref album, Account.Id);
            _logger.LogInfo("Updated Photo Album");
            return Ok(album);
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

            var photo = _repository.Photo.GetPhotoById(id);
            _repository.Photo.DeletePhoto(photo);
            _logger.LogInfo("Deleted Photo from Album");
            return Ok(new { message = "Photo deleted successfully" });
        }

        [Helpers.Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteAlbum(Guid id)
        {
            // only admins can delete albums
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var album = _repository.Album.GetAlbumByAlbumId(id);
            _repository.Album.DeleteAlbum(album);
            _logger.LogInfo("Album deleted successfully");
            return Ok(new { message = "Photo Album deleted successfully" });
        }

        #endregion
    }
}
    
