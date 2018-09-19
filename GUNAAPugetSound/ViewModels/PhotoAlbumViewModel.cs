using System.Collections.Generic;
using GUNAAPugetSound.Models;
using GUNAAPugetSound.Utilities;

namespace GUNAAPugetSound.ViewModels
{
    public class PhotoAlbumViewModel
    {
        public IEnumerable<Album> PhotoAlbums { get; set; }

        public Album SelectedAlbum { get; set; }
        public IEnumerable<Photo> Photos { get; set; }

        public PagedList<Photo> Records;

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public bool NoPhotos { get; set; }
    }
}