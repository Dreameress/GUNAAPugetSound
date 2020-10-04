using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {

        IAlbumRepository Album { get; }
        IAccountRepository Account { get; }
        IContentRepository Content { get; set; }
        IEventRepository Event { get; set; }
        IPhotoRepository Photo { get; set; }
        void Save();
    }
}
