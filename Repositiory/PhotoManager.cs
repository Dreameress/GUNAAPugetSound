using System;
using System.Collections.Generic;
using System.Text;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetPhotosByAlbumId(Guid albumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            throw new NotImplementedException();
        }

        public void CreatePhoto(Photo photo, int accountId)
        {
            throw new NotImplementedException();
        }

        public void CreatePhotos(List<Photo> photos, int accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePhoto(Photo photo, int accountId)
        {
            throw new NotImplementedException();
        }

        public void DeletePhoto(Photo photo)
        {
            throw new NotImplementedException();
        }
    }
}
