using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {

        IAlbumManager Album { get; }
        IAccountManager Account { get; }
        IContentManager Content { get; set; }
        IEventManager Event { get; set; }
        IPhotoManager Photo { get; set; }
        void Save();
    }
}
