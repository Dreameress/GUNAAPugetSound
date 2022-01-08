using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class GunaaDbContext : DbContext
    {
        public GunaaDbContext(DbContextOptions<GunaaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MigrationHistory> MigrationHistory { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<CommitteeMember> CommitteeMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
