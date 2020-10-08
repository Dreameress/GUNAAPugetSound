using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities.Models;
using GUNAAPugetSound.Entities;
using GUNAAPugetSound.Entities.Enums;

namespace Repository
{
    class OfficerManager : RepositoryBase<Officer>, IOfficerManager  
    {
        public OfficerManager(GUNAADbContext repositoryContext) : base(repositoryContext)
        {
        }

        public bool OfficerWithRoleExists(OfficerRole role)
        {
            return RepositoryContext.Officers.Any(x => x.Role == role);
        }

        public Officer GetOfficerById(int id)
        {
            return RepositoryContext.Officers.Find(id);
        }
        public Officer GetOfficerByMemberId(int memberId)
        {
            return RepositoryContext.Officers.SingleOrDefault(x => x.MemberId == memberId);
        }

        public IEnumerable<Officer> GetAllOfficers()
        {
            return RepositoryContext.Officers;
        }

        public IEnumerable<Officer> GetActiveOfficers()
        {
            return RepositoryContext.Officers.Where(o => o.Active);
        }

        public Officer CreateOfficer(Officer officer, int? accountId, int? memberId)
        {
            officer.Created = DateTime.UtcNow;
            if (accountId != null)
            {
                officer.CreatedBy = accountId;
            }

            if (memberId != null)
            {
                officer.MemberId = memberId; 
            }

            RepositoryContext.Officers.Add(officer);
            RepositoryContext.SaveChanges();
            return officer;
        }

        public Officer UpdateOfficer(Officer officer, int accountId)
        {
            officer.Updated = DateTime.UtcNow;
            officer.UpdatedBy = accountId;
            RepositoryContext.Officers.Update(officer);
            RepositoryContext.SaveChanges();
            return officer;
        }

        public void DeactivateOfficer(Officer officer, int accountId)
        {
            officer.Active = false;
            officer.Updated = DateTime.UtcNow;
            officer.UpdatedBy = accountId;
            RepositoryContext.Officers.Update(officer);
            RepositoryContext.SaveChanges();
        }
    }
}
