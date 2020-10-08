using Contracts;
using GUNAAPugetSound.Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly GUNAADbContext _repoContext;
        private IAccountManager _account;
        private IAlbumManager _album;
        private ICommitteeManager _committee;
        private IContentManager _content;
        private IEventManager _event;
        private IOfficerManager _officer;
        private IPhotoManager _photo;

        public IAccountManager Account => _account ??= new AccountManager(_repoContext);
 
        public IAlbumManager Album => _album ??= new AlbumManager(_repoContext);
        public ICommitteeManager CommitteeMember
        {
            get => _committee ??= new CommitteeManager(_repoContext);
            set { }
        }
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

        public IOfficerManager Officer
        {
            get => _officer ??= new OfficerManager(_repoContext);
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