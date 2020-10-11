using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Contracts
{
    public interface IAlbumManager : IRepositoryBase<Album>
    {
        bool AlbumNameExists(string name);
        Album GetAlbumByAlbumId(Guid albumId);
        IEnumerable<Album> GetAllAlbums();
        void CreateAlbum(ref Album album, int accountId);
        void UpdateAlbum(ref Album album, int accountId);
        void DeleteAlbum(Album album);
    }
}
