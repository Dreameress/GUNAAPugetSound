using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GUNAAPugetSound.Entities
{
    public class GUNAADbContext : DbContext
    {
        public GUNAADbContext(DbContextOptions<GUNAADbContext> options)
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
        public DbSet<Officer> Officers { get; set; }
        public DbSet<CommitteeMember> CommitteeMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(160)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Modified).HasColumnType("datetime");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.End).IsRequired();

                entity.Property(e => e.Start).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description).HasDefaultValueSql("('')");

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.ThumbPath).IsRequired();
            });
        }
    }
}
