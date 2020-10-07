using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Contracts
{
    public interface IAlbumManager : IRepositoryBase<Album>
    {
        Album GetAlbumByAlbumId(Guid albumId);
        IEnumerable<Album> GetAllAlbums();
        void CreateAlbum(Album album, int accountId);
        void UpdateAlbum(Album album, int accountId);
        void DeleteAlbum(Album album);
    }
}
