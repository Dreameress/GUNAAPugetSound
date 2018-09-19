﻿// <auto-generated />
using System;
using GUNAAPugetSound.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GUNAAPugetSound.Migrations
{
    [DbContext(typeof(GUNAADbContext))]
    [Migration("20180918050037_EventsUpdatev2")]
    partial class EventsUpdatev2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GUNAAPugetSound.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.Album", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("AlbumDesc")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(160);

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime");

                    b.Property<string>("LastEditBy");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.HasKey("LoginProvider", "ProviderKey", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.Property<string>("RoleId")
                        .HasMaxLength(128);

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTime?>("LockoutEndDateUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.Event", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<string>("EndDate")
                        .IsRequired();

                    b.Property<string>("EndTime");

                    b.Property<int>("MemberId");

                    b.Property<string>("StartDate")
                        .IsRequired();

                    b.Property<string>("StartTime");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.Member", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Address");

                    b.Property<string>("Committee");

                    b.Property<string>("Facebook");

                    b.Property<int>("GraduationYear");

                    b.Property<string>("Instagram");

                    b.Property<string>("LinkedIn");

                    b.Property<string>("NameFirst");

                    b.Property<string>("NameLast");

                    b.Property<string>("Phone");

                    b.Property<string>("Position");

                    b.Property<string>("Twitter");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.MigrationHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150);

                    b.Property<string>("ContextKey")
                        .HasMaxLength(300);

                    b.Property<byte[]>("Model")
                        .IsRequired();

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("MigrationId", "ContextKey");

                    b.ToTable("__MigrationHistory");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.Photo", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("AlbumId");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')");

                    b.Property<string>("ImagePath")
                        .IsRequired();

                    b.Property<string>("ThumbPath")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("GUNAAPugetSound.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GUNAAPugetSound.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("GUNAAPugetSound.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
