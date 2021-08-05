using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Data;
using Entities.Models;
using GUNAAPugetSound.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    class PhotoManager : RepositoryBase<Photo>, IPhotoManager
    {
        public PhotoManager(GunaaDbContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public Photo GetPhotoById(Guid id)
        {
            return FindByCondition(photo => photo.PhotoId.Equals(id))
                .FirstOrDefault();
        }

        public IEnumerable<Photo> GetPhotosByAlbumId(Guid albumId)
        {
            return RepositoryContext.Photos.Where(p => p.AlbumId == albumId);
        }

        IEnumerable<Photo> IPhotoManager.GetAllPhotos()
        {
            return FindAll().OrderBy(p => p.PhotoId);
        }

        public async Task<IEnumerable<Photo>> GetAllPhotosAsync()
        {
            return await GetAllPhotosAsync(); 
        }

        public void CreatePhoto(ref Photo photo, int accountId)
        {
            photo.Created = DateTime.UtcNow;
            photo.AddedBy = accountId;
            RepositoryContext.Photos.Add(photo);
            RepositoryContext.SaveChanges();
        }

        public void CreatePhotos(ref IEnumerable<Photo> photos, int accountId)
        {
            foreach (var photo in photos)
            {
                photo.Created = DateTime.UtcNow;
                photo.AddedBy = accountId;
                RepositoryContext.Photos.Add(photo);
            }

            RepositoryContext.SaveChanges();
        }

        public void DeletePhoto(Photo photo)
        {
            RepositoryContext.Photos.Remove(photo);
            RepositoryContext.SaveChanges();
        }
    }
}
