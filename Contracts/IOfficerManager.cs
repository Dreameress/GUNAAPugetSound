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
        Officer GetOfficerById(Guid id);
        Officer GetOfficerByMemberId(int memberId);
        IEnumerable<Officer> GetAllOfficers();
        IEnumerable<Officer> GetActiveOfficers();
        Officer AddOfficer(ref Officer officer, int? accountId, int? memberId);
        Officer UpdateOfficer(ref Officer officer, int accountId, int? memberId);
        void DeactivateOfficer(Officer officer, int accountId);
    }
}
