using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Contracts
{
    public interface IContentManager : IRepositoryBase<Content>
    { 
        Content GetContent();
        Content UpdateContent(ref Content content, int accountId);
    }
}
