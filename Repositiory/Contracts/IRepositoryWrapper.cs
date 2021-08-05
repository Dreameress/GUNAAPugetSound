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
        ICommitteeManager CommitteeMember { get;  }
        IContentManager Content { get; }
        IEventManager Event { get;  }
        IOfficerManager Officer { get;  }
        IPhotoManager Photo { get;  }
        Task SaveAsync();
    }
}
