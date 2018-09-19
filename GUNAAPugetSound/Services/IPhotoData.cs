using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUNAAPugetSound.Models;

namespace GUNAAPugetSound.Services
{
    public interface IPhotoData
    {
        IEnumerable<Photo> GetAll();
        IEnumerable<Photo> GetAllByAlbumId(Guid albumId);
        Photo Get(Guid id);
        void Add(Photo newPhoto);
        int Commit();
    }

    public class SqlPhotoData : IPhotoData
    {
        private readonly GUNAADbContext _context;

        public SqlPhotoData(GUNAADbContext context)
        {
            _context = context;
            Initialize();
        }

        public void Initialize()
        {

        }
        public IEnumerable<Photo> GetAll()
        {
            return _context.Photos.ToList();
        }

        public IEnumerable<Photo> GetAllByAlbumId(Guid albumGuid)
        {
            try
            {
                return _context.Photos.Where(r => r.AlbumId == albumGuid).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Photo Get(Guid id)
        {
            return _context.Photos.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Photo newPhoto)
        {
            _context.Photos.Add(newPhoto);
            _context.SaveChanges();
        }


        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
