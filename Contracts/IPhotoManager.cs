using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Contracts
{
    public interface IPhotoManager : IRepositoryBase<Photo>
    {
        Photo GetPhotoByIdAsync(Guid id);
        IEnumerable<Photo> GetPhotosByAlbumId(Guid albumId);
        IEnumerable<Photo> GetAllPhotosAsync();

        Task<Photo> GetPhotoByIdAsync(Guid id);
        Task<IEnumerable<Photo>> GetPhotosByAlbumIdAsync(Guid albumId);
        Task<IEnumerable<Photo>> GetAllPhotosAsync();
        void CreatePhoto(ref Photo photo, int accountId);
        void CreatePhotos(ref IEnumerable<Photo> photos, int accountId);
        void DeletePhoto(Photo photo);
    }
}
