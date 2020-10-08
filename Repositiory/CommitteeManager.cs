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
    class CommitteeManager : RepositoryBase<CommitteeMember>, ICommitteeManager
    {
        public CommitteeManager(GUNAADbContext repositoryContext) : base(repositoryContext)
        {
        }

        public CommitteeMember GetCommitteeMemberById(int id)
        {
            return RepositoryContext.CommitteeMembers.Find(id);
        }
        public CommitteeMember GetCommitteeMemberByMemberId(int memberId)
        {
            return RepositoryContext.CommitteeMembers.SingleOrDefault(x => x.MemberId == memberId);
        }

        public IEnumerable<CommitteeMember> GetAllCommitteeMembers()
        {
            return RepositoryContext.CommitteeMembers;
        }

        public IEnumerable<CommitteeMember> GetActiveCommitteeMembers()
        {
            return RepositoryContext.CommitteeMembers.Where(o => o.Active);
        }

        public CommitteeMember CreateCommitteeMember(ref CommitteeMember member, int? accountId, int? memberId)
        {
            member.Created = DateTime.UtcNow;
            if (accountId != null)
            {
                member.CreatedBy = accountId;
            }

            if (memberId != null)
            {
                member.MemberId = memberId;
            }

            RepositoryContext.CommitteeMembers.Add(member);
            RepositoryContext.SaveChanges();
            return member;
        }

        public CommitteeMember UpdateCommitteeMember(ref CommitteeMember member, int accountId)
        {
            member.Updated = DateTime.UtcNow;
            member.UpdatedBy = accountId;
            RepositoryContext.CommitteeMembers.Update(member);
            RepositoryContext.SaveChanges();
            return member;
        }

        public void DeactivateCommitteeMember(ref CommitteeMember member, int accountId)
        {
            member.Active = false;
            member.Updated = DateTime.UtcNow;
            member.UpdatedBy = accountId;
            RepositoryContext.CommitteeMembers.Update(member);
            RepositoryContext.SaveChanges();
        }
    }
}