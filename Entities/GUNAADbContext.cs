using System;
using Entities.Models;
using GUNAAPugetSound.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace GUNAAPugetSound.Entities
{
    public class GUNAADbContext : DbContext
    {
        public GUNAADbContext(DbContextOptions<GUNAADbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MigrationHistory> MigrationHistory { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<CommitteeMember> CommitteeMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AlbumId).ValueGeneratedNever();

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
                entity.Property(e => e.EventId).ValueGeneratedNever();

                entity.Property(e => e.End).IsRequired();

                entity.Property(e => e.Start).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<Member>(entity => { entity.Property(e => e.MemberId).ValueGeneratedNever(); });

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
                entity.Property(e => e.PhotoId).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description).HasDefaultValueSql("('')");

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.ThumbPath).IsRequired();
            });

            modelBuilder.Entity<Officer>()
                .HasData(
                    new Officer()
                    {
                        OfficerId = Guid.NewGuid(),
                        FirstName = "Charlene",
                        LastName = "Francisco",
                        Role = OfficerRole.President,
                        Active = true,
                        Created = DateTime.UtcNow
                    },
                    new Officer()
                    {
                        OfficerId = Guid.NewGuid(),
                        FirstName = "Jeanie",
                        LastName = "Nelson",
                        Role = OfficerRole.Secretary,
                        Active = true,
                        Created = DateTime.UtcNow
                    },
                    new Officer()
                    {
                        OfficerId = Guid.NewGuid(),
                        FirstName = "Eva",
                        LastName = "Edwards",
                        Role = OfficerRole.Treasurer,
                        Active = true,
                        Created = DateTime.UtcNow
                    },
                    new Officer()
                    {
                        OfficerId = Guid.NewGuid(),
                        FirstName = "Beverly",
                        LastName = "Hopkins",
                        Role = OfficerRole.VicePresident,
                        Active = true,
                        Created = DateTime.UtcNow
                    }
                );

            modelBuilder.Entity<CommitteeMember>()
                .HasData(
                    new CommitteeMember()
                    {
                        CommitteeId = Guid.NewGuid(),
                        FirstName = "Don",
                        LastName = "Paul",
                        Committee = CommitteeName.Fundraising,
                        Active = true,
                        Created = DateTime.UtcNow
                    },
                    new CommitteeMember()
                    {
                        CommitteeId = Guid.NewGuid(),
                        FirstName = "Tammy",
                        LastName = "Richardson",
                        Committee = CommitteeName.Membership,
                        Active = true,
                        Created = DateTime.UtcNow
                    },
                    new CommitteeMember()
                    {
                        CommitteeId = Guid.NewGuid(),
                        FirstName = "Eva",
                        LastName = "Edwards",
                        Committee = CommitteeName.Hospitality,
                        Active = true,
                        Created = DateTime.UtcNow
                    },
                    new CommitteeMember()
                    {
                        CommitteeId = Guid.NewGuid(),
                        FirstName = "Marcus",
                        LastName = "Dabney",
                        Committee = CommitteeName.ScholarshipChair,
                        Active = true,
                        Created = DateTime.UtcNow
                    }
                );

            modelBuilder.Entity<Content>()
                .HasData(
                    new Content()
                    {
                        ContentId = Guid.NewGuid(),

                        //Home Content
                        HomeMainHeader = "Welcome",
                        HomeSubHeader = "Welcome to the Home Site of the Puget Sound Chapter Of the Grambling University National Alumni Association",
                        HomeLine1 = "We would like to welcome all alumni and supporters living in and visiting the Seattle area. We welcome your support as we continue our mission of recruiting students to our alma mater. ",
                        HomeLine2 = "If you are in the Puget Sound area and interested in attending Grambling State University or currently attending Grambling State University, please reach out to us for information on the scholarships we provide.",
                        HomeLine3 = "Go Tigers!!!",
                        HomeLine4 = "Grambling, Where Everybody is Somebody",

                        //Calendar Content
                        CalendarMainHeader = "Calendar",
                        CalendarSubHeader = "Keeping you updated with Events, Meetings, and more from GUNAA Puget Sound",

                        //Officer Content
                        OfficersMainHeader = "Officers",
                        OfficersSubHeader = "Leaders of Grambling University National Alumni Association of Puget Sound",

                        //Committee Memeber Content
                        CommitteesMainHeader = "Committees",
                        CommitteesSubHeader = "Committee Chairs for Grambling University National Alumni Association of Puget Sound",

                        //Membership Content
                        MembershipMainHeader = "Membership",
                        MembershipSubHeader = "Alumni Association Dues Structure",
                        MemberShipName1 = "GUNAA",
                        Membership1Amount1 = "National Dues (Yearly) $70",
                        Membership1Amount2 = "Life Membership (Single) $500",
                        Membership1Amount3 = "Life Membership (Couples) $750",
                        MemberShipName2 = "GUNAA Puget Sound Chapter",
                        Membership2Amount1 = "Local Dues Regular Members $40",
                        Membership2Amount2 = "Local Dues Associate Members (family/friends) $35",

                        //Scholarship Content
                        ScholarshipMainHeader = "Scholarship",
                        ScholarshipSubHeader = "Scholarship Program",

                        //Photo Content
                        PhotoMainHeader = "Photos",
                        PhotoSubHeader = "Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more",

                        //About Us Content
                        AboutUsHeader = "About Us",
                        AboutUsSubHeader = "Mission",
                        AboutUsQuoteLine1 = "The purpose of the chapter is : (1) To maintain a working relationship with the University;",
                        AboutUsQuoteLine2 = "(2) To promote interest in the University among prospective students;",
                        AboutUsQuoteLine3 = "(3) To promote fellowship among the alumni; and",
                        AboutUsQuoteLine4 = "(4) To promote and maintain a positive image of the University in the community.",

                        //Contact Us Content
                        ContactUsHeader = "Contact Us",
                        ContactUsSubHeader = null,
                        ContactUsAddressName1 = "Grambling University National Alumni Association",
                        ContactUsAddressName2 = "Puget Sound Chapter",
                        ContactUsStreetAddress = "Post Office Box 18321",
                        ContactUsCity = "Seattle",
                        ContactUsState = "Washington",
                        ContactUsZipCode = "98118",

                        //Created 
                        Created = DateTime.UtcNow
                    }
                );
        }
    }
}
