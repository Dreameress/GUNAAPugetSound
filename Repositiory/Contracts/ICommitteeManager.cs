using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Contracts
{
    public interface ICommitteeManager : IRepositoryBase<CommitteeMember>
    {
        CommitteeMember GetCommitteeMemberById(Guid id);
        CommitteeMember GetCommitteeMemberByMemberId(int accountId);
        IEnumerable<CommitteeMember> GetAllCommitteeMembers();
        IEnumerable<CommitteeMember> GetActiveCommitteeMembers();
        CommitteeMember CreateCommitteeMember(ref CommitteeMember member, int? accountId, int? memberId);
        CommitteeMember UpdateCommitteeMember(ref CommitteeMember member, int accountId, int? memberId);
        void DeactivateCommitteeMember(ref CommitteeMember member, int accountId);
    }
}
