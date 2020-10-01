using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GUNAAPugetSound.Entities
{
    public class GUNAADbContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public GUNAADbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public GUNAADbContext(DbContextOptions<GUNAADbContext> options)
        //    : base(options)
        //{
        //}

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
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

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

                entity.Property(e => e.EndDate).IsRequired();

                entity.Property(e => e.StartDate).IsRequired();

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
