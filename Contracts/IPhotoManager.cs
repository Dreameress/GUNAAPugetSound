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
        void CreatePhoto(ref Photo photo, int accountId);
        void CreatePhotos(ref IEnumerable<Photo> photos, int accountId);
        void DeletePhoto(Photo photo);
    }
}
