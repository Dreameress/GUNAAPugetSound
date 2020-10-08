using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Contracts
{
    public interface ICommitteeManager : IRepositoryBase<CommitteeMember>
    {
        CommitteeMember GetCommitteeMemberById(int id);
        CommitteeMember GetCommitteeMemberByMemberId(int accountId);
        IEnumerable<CommitteeMember> GetAllCommitteeMembers();
        IEnumerable<CommitteeMember> GetActiveCommitteeMembers();
        CommitteeMember CreateCommitteeMember(ref CommitteeMember member, int? accountId, int? memberId);
        CommitteeMember UpdateCommitteeMember(ref CommitteeMember member, int accountId);
        void DeactivateCommitteeMember(ref CommitteeMember member, int accountId);
    }
}
