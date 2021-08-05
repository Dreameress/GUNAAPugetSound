using System.Threading.Tasks;
using Contracts;
using Data;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly GunaaDbContext _repoContext;
        private IAccountManager _account;
        private IAlbumManager _album;
        private ICommitteeManager _committee;
        private IContentManager _content;
        private IEventManager _event;
        private IOfficerManager _officer;
        private IPhotoManager _photo;

        public IAccountManager Account => _account ??= new AccountManager(_repoContext);

        public IAlbumManager Album => _album ??= new AlbumManager(_repoContext);
        public ICommitteeManager CommitteeMember => _committee ??= new CommitteeManager(_repoContext);

        public IContentManager Content => _content ??= new ContentManager(_repoContext);

        public IEventManager Event => _event ??= new EventManager(_repoContext);

        public IOfficerManager Officer => _officer ??= new OfficerManager(_repoContext);

        public IPhotoManager Photo => _photo ??= new PhotoManager(_repoContext);

        public RepositoryWrapper(GunaaDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }

    }
}