using Contracts;
using Entities;
using GUNAAPugetSound.Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly GUNAADbContext _repoContext;
        private IAccountManager _account;
        private IAlbumManager _album;
        private IContentManager _content;
        private IEventManager _event;
        private IPhotoManager _photo;
        private IEmailService _emailService;

        public IAccountManager Account => _account ??= new AccountManager(_repoContext);
        public IAlbumManager Album => _album ??= new AlbumManager(_repoContext);

        public IContentManager Content
        {
            get => _content ??= new ContentManager(_repoContext);
            set { }
        }

        public IEventManager Event
        {
            get => _event ??= new EventManager(_repoContext);
            set { }
        }

        public IPhotoManager Photo
        {
            get => _photo ??= new PhotoManager(_repoContext);
            set { }
        }


        public RepositoryWrapper(GUNAADbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}