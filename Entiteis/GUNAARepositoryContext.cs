using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GUNAAPugetSound.Entities
{
    public class GUNAARepositoryContext : DbContext
    {
        //public GUNAARepositoryContext(DbContextOptions options)
        //    : base(options)
        //{
        //}

        //private readonly IConfiguration Configuration;
        //public GUNAARepositoryContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public GUNAARepositoryContext(DbContextOptions<GUNAARepositoryContext> options)
            : base(options)
        {
        }

        public  DbSet<Album> Albums { get; set; }
        public  DbSet<Photo> Photos { get; set; }
        public  DbSet<Event> Events { get; set; }
        public  DbSet<Member> Members { get; set; }
        public  DbSet<MigrationHistory> MigrationHistory { get; set; }
        public  DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Content> Content { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
    }
}
