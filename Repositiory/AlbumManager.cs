using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Repository
{
    class AlbumManager : RepositoryBase<Album>, IAlbumManager
    {
        public AlbumManager(GUNAADbContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public bool AlbumNameExists(string name)
        {
            return RepositoryContext.Albums.Any(a => a.Name == name);
        }

        public Album GetAlbumByAlbumId(Guid albumId)
        {
            return RepositoryContext.Albums.Find(albumId);
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return RepositoryContext.Albums;
        }

        public void CreateAlbum(ref Album album, int accountId)
        {
            album.Created = DateTime.UtcNow;
            album.CreatedBy = accountId;
            RepositoryContext.Albums.Add(album);
            RepositoryContext.SaveChanges();
        }

        public void UpdateAlbum(ref Album album, int accountId)
        {
            album.Modified = DateTime.UtcNow;
            album.ModifiedBy = accountId;
            RepositoryContext.Albums.Update(album);
            RepositoryContext.SaveChanges();
        }

        public void DeleteAlbum(Album album)
        {
            RepositoryContext.Albums.Remove(album);
            RepositoryContext.SaveChanges();
        }
    }
}
