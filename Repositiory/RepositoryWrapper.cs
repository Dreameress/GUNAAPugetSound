using Contracts;
using Entities;
using GUNAAPugetSound.Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly GUNAARepositoryContext _repoContext;
        private IAccountRepository _account;
        private IAlbumRepository _album;
        private IContentRepository _content;
        private IEventRepository _event;
        private IPhotoRepository _photo;

        public IAccountRepository Account => _account ??= new AccountRepository(_repoContext);
        public IAlbumRepository Album => _album ??= new AlbumRepository(_repoContext);

        public IContentRepository Content
        {
            get => _content ??= new ContentRepository(_repoContext);
            set { }
        }

        public IEventRepository Event
        {
            get => _event ??= new EventRepository(_repoContext);
            set { }
        }

        public IPhotoRepository Photo
        {
            get => _photo ??= new PhotoRepository(_repoContext);
            set { }
        }

        public RepositoryWrapper(GUNAARepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}