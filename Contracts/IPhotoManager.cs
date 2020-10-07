using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Contracts
{
    public interface IPhotoManager : IRepositoryBase<Photo>
    {
        Photo GetPhotoById(Guid id);
        IEnumerable<Photo> GetPhotosByAlbumId(Guid albumId);
        IEnumerable<Photo> GetAllPhotos();
        void CreatePhoto(Photo photo, int accountId);
        void CreatePhotos(List<Photo> photos, int accountId);
        void UpdatePhoto(Photo photo, int accountId);
        void DeletePhoto(Photo photo);
    }
}
