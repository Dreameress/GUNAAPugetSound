using System;
using System.Collections.Generic;
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

        public Content GetContentById(int contentId)
        {
            throw new NotImplementedException();
        }

        public Content GetContentByView(int viewId)
        {
            throw new NotImplementedException();
        }

        public Content GetOfficerContent()
        {
            throw new NotImplementedException();
        }

        public Content GetCommitteeContent()
        {
            throw new NotImplementedException();
        }

        public Content GetMembershipContent()
        {
            throw new NotImplementedException();
        }

        public Content GetScholarshipContent()
        {
            throw new NotImplementedException();
        }

        public Content GetAboutUsContent()
        {
            throw new NotImplementedException();
        }

        public Content GetContactUsContent()
        {
            throw new NotImplementedException();
        }

        public void UpdateContent(Content content, int accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOfficerContent(Content content, int accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCommitteeContent(Content content, int accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateMembershipContent(Content content, int accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateScholarshipContent(Content content, int accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAboutUsContent(Content content, int accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateContactUsContent(Content content, int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
