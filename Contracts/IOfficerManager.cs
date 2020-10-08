using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using GUNAAPugetSound.Entities;
using GUNAAPugetSound.Entities.Enums;

namespace Contracts
{
    public interface IOfficerManager : IRepositoryBase<Officer>
    {
        bool OfficerWithRoleExists(OfficerRole role);
        Officer GetOfficerById(int id);
        Officer GetOfficerByMemberId(int memberId);
        IEnumerable<Officer> GetAllOfficers();
        IEnumerable<Officer> GetActiveOfficers();
        Officer CreateOfficer(Officer officer, int? accountId, int? memberId);
        Officer UpdateOfficer(Officer officer, int accountId);
        void DeactivateOfficer(Officer officer, int accountId);
    }
}
