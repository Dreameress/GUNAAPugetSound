using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Repository
{
    class AlbumRepository : RepositoryBase<Album>, IAlbumRepository
    {
        public AlbumRepository(GUNAARepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public Album GetAlbumByAlbumId(Guid albumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            throw new NotImplementedException();
        }

        public void CreateAlbum(Album album, int accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAlbum(Album album, int accountId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAlbum(Album album)
        {
            throw new NotImplementedException();
        }
    }
}
