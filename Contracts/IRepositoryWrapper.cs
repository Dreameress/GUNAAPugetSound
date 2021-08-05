using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAlbumManager Album { get; }
        IAccountManager Account { get; }
        ICommitteeManager CommitteeMember { get; set; }
        IContentManager Content { get; set; }
        IEventManager Event { get; set; }
        IOfficerManager Officer { get; set; }
        IPhotoManager Photo { get; set; }
        Task SaveAsync();
    }
}
