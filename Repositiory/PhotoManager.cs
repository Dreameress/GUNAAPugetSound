using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Repository
{
    class PhotoManager : RepositoryBase<Photo>, IPhotoManager
    {
        public PhotoManager(GUNAADbContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public Photo GetPhotoById(Guid id)
        {
            return RepositoryContext.Photos.Find(id);
        }

        public IEnumerable<Photo> GetPhotosByAlbumId(Guid albumId)
        {
            return RepositoryContext.Photos.Where(p => p.AlbumId == albumId);
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            return RepositoryContext.Photos;
        }

        public void CreatePhoto(Photo photo, int accountId)
        {
            photo.Created = DateTime.UtcNow;
            photo.AddedBy = accountId;
            RepositoryContext.Photos.Add(photo);
            RepositoryContext.SaveChanges();
        }

        public void CreatePhotos(List<Photo> photos, int accountId)
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
        }
    }
}
