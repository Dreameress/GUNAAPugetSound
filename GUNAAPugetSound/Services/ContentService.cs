using System;
using AutoMapper;
using Entities.DTOs.Content;
using GUNAAPugetSound.Entities;
using GUNAAPugetSound.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace GUNAAPugetSound.Services
{
    public interface IContentService
    {
        ContentResponse GetContent(ContentRequest model);
        OfficerContentResponse GetOfficerContent(ContentRequest model);
        CommitteeContentResponse GetCommitteeContent(ContentRequest model);
        MembershipContentResponse GetMembershipContent(ContentRequest model);
        ScholarshipContentResponse GetScholarshipContent(ContentRequest model);
        AboutUsContentResponse GetAboutUsContent(ContentRequest model);
        ContactUsContentResponse GetContactUsContent(ContentRequest model);
        ContentResponse UpdateContent(int id, UpdateContentRequest model);
        ContentResponse UpdateOfficerContent(UpdateOfficerContentRequest model);
        ContentResponse UpdateCommitteeContent(UpdateCommitteeContentRequest model);
        ContentResponse UpdateMembershipContent(UpdateMembershipContentRequest model);
        ContentResponse UpdateScholarshipContent(UpdateScholarshipContentRequest model);
        ContentResponse UpdateAboutUsContent(UpdateAboutUsContentRequest model);
        ContentResponse UpdateContactUsContent(UpdateContactUsContentRequest model);
    }

    public class ContentService : IContentService
    {
        private readonly GUNAADbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _env;

        public ContentService(GUNAADbContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService,
            IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
            _env = env; 
        }

        public ContentResponse GetContent(ContentRequest model)
        {
            throw new NotImplementedException();
        }

        public OfficerContentResponse GetOfficerContent(ContentRequest model)
        {
            throw new NotImplementedException();
        }

        public CommitteeContentResponse GetCommitteeContent(ContentRequest model)
        {
            throw new NotImplementedException();
        }

        public MembershipContentResponse GetMembershipContent(ContentRequest model)
        {
            throw new NotImplementedException();
        }

        public ScholarshipContentResponse GetScholarshipContent(ContentRequest model)
        {
            throw new NotImplementedException();
        }

        public AboutUsContentResponse GetAboutUsContent(ContentRequest model)
        {
            throw new NotImplementedException();
        }
        public ContactUsContentResponse GetContactUsContent(ContentRequest model)
        {
            throw new NotImplementedException();
        }

        public ContentResponse UpdateContent(int id, UpdateContentRequest model)
        {
            throw new NotImplementedException();
        }

        public ContentResponse UpdateOfficerContent(UpdateOfficerContentRequest model)
        {
            throw new NotImplementedException();
        }

        public ContentResponse UpdateCommitteeContent(UpdateCommitteeContentRequest model)
        {
            throw new NotImplementedException();
        }

        public ContentResponse UpdateMembershipContent(UpdateMembershipContentRequest model)
        {
            throw new NotImplementedException();
        }

        public ContentResponse UpdateScholarshipContent(UpdateScholarshipContentRequest model)
        {
            throw new NotImplementedException();
        }

        public ContentResponse UpdateAboutUsContent(UpdateAboutUsContentRequest model)
        {
            throw new NotImplementedException();
        }
        public ContentResponse UpdateContactUsContent(UpdateContactUsContentRequest model)
        {
            throw new NotImplementedException();
        }

    }
}
