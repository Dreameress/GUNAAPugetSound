using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Repository
{
    class ContentManager : RepositoryBase<Content>, IContentManager
    {
        public ContentManager(GUNAADbContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public Content GetContent()
        {
            return RepositoryContext.Content.FirstOrDefault();
        }

        public Content UpdateContent(ref Content content, int accountId)
        {
            content.Updated = DateTime.UtcNow;
            content.LastUpdatedUserId = accountId;
            RepositoryContext.Update(content);
            RepositoryContext.SaveChanges();
            return content;
        }
    }
}
