using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Contracts
{
    public interface IContentRepository : IRepositoryBase<Content>
    {
        Content GetContentById(int contentId);
        Content GetContentByView(int viewId);
        Content GetOfficerContent();
        Content GetCommitteeContent();
        Content GetMembershipContent();
        Content GetScholarshipContent();
        Content GetAboutUsContent();
        Content GetContactUsContent();
        void UpdateContent(Content content, int accountId);
        void UpdateOfficerContent(Content content, int accountId);
        void UpdateCommitteeContent(Content content, int accountId);
        void UpdateMembershipContent(Content content, int accountId);
        void UpdateScholarshipContent(Content content, int accountId);
        void UpdateAboutUsContent(Content content, int accountId);
        void UpdateContactUsContent(Content content, int accountId);
    }
}
