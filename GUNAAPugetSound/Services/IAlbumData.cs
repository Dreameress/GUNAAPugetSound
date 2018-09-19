using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUNAAPugetSound.Models;

namespace GUNAAPugetSound.Services
{
    public interface IAlbumData
    {
        IEnumerable<Album> GetAll();
        Album Get(Guid id);
        void Add(Album newAlbum);
        void Delete(Album oldAlbum);
        void Edit(Album newAlbum);
        int Commit();
    }

    public class SqlAlbumData : IAlbumData
    {
        private readonly GUNAADbContext _context;

        public SqlAlbumData(GUNAADbContext context)
        {
            _context = context;
            Initialize();
        }

        public void Initialize()
        {
            if (_context.Albums.Any()) return;
            new[] {
                new Album
                    ("Gunaa Puget Sound General Album", "Everyday moments with Gunaa Puget Sound and our members!", "Sabrina Smith", "Sabrina Smith")
            }.ToList().ForEach(d => _context.Albums.Add(d));
            _context.SaveChanges();

        }
        public IEnumerable<Album> GetAll()
        {
            return _context.Albums.ToList();
        }


        public Album Get(Guid id)
        {
            return _context.Albums.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Album newAlbum)
        {
            _context.Albums.Add(newAlbum);
            _context.SaveChanges();
        }

        public void Edit(Album newAlbum)
        {
            _context.Albums.Update(newAlbum);
            _context.SaveChanges();
        }

        public void Delete(Album oldAlbum)
        {
            _context.Albums.Remove(oldAlbum);
            _context.SaveChanges();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
