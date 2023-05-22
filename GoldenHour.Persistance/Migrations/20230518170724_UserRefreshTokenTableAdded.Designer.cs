﻿// <auto-generated />
using System;
using GoldenHour.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoldenHour.Persistance.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230518170724_UserRefreshTokenTableAdded")]
    partial class UserRefreshTokenTableAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GoldenHour.Domain.BloodGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("BloodGroups", "meta");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ebe5ba94-2c9d-46f4-8188-4ca1fc677d70"),
                            Name = "First — 0 (І)",
                            SequenceNumber = 1
                        },
                        new
                        {
                            Id = new Guid("89160257-98b1-4c69-bf39-fef973cad668"),
                            Name = "Second — A (ІІ)",
                            SequenceNumber = 2
                        },
                        new
                        {
                            Id = new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                            Name = "Third — B (ІІІ)",
                            SequenceNumber = 3
                        },
                        new
                        {
                            Id = new Guid("1daaa8e0-b24b-4a78-84f7-c0d5e958fccd"),
                            Name = "Fourth — AB (ІV)",
                            SequenceNumber = 4
                        });
                });

            modelBuilder.Entity("GoldenHour.Domain.Brigade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brigades");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            Department = "97",
                            Name = "14th Mechanized Brigade 'Roman the Great' (MU A2331), Volodymyr-Volynsky, Volyn Oblast",
                            ShortName = "14th MB"
                        },
                        new
                        {
                            Id = new Guid("cf2a2a3a-861f-45c9-9b35-456301093fa1"),
                            Department = "52",
                            Name = "24th Mechanized Brigade 'King Daniel' (MU A0998), Yavoriv, Lviv Oblast",
                            ShortName = "24th MB"
                        });
                });

            modelBuilder.Entity("GoldenHour.Domain.HelpPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IncidentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IncidentId");

                    b.ToTable("HelpPhotos");
                });

            modelBuilder.Entity("GoldenHour.Domain.Incident", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ServiceManId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MedicId");

                    b.HasIndex("ServiceManId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("GoldenHour.Domain.ServiceMan", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("BloodGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrigadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("BloodGroupId");

                    b.HasIndex("BrigadeId");

                    b.HasIndex("NickName")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "408aa945-3d84-4421-8342-7269ec64d949",
                            AccessFailedCount = 0,
                            BloodGroupId = new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                            BrigadeId = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            ConcurrencyStamp = "1d1b7e78-7d7b-49dc-b7c8-ae655edf7be7",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            FullName = "",
                            LockoutEnabled = false,
                            NickName = "admin",
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAECu7+j9sgu9cYPFucp/ixGW8jzH+qVKh9SK6A8/NM1Xjc6G9O6Ry3H4aS5kZpYBjKw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fb8e09d4-baf8-473f-a911-9ce711bc6ce0",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "3f4631bd-f907-4409-b416-ba356312e659",
                            AccessFailedCount = 0,
                            BloodGroupId = new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                            BrigadeId = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            ConcurrencyStamp = "f81ddda2-4dc0-4891-ba36-d853e87e5f9d",
                            Email = "medic@localhost.com",
                            EmailConfirmed = true,
                            FullName = "Bondar Volodymyr Ivanovych",
                            LockoutEnabled = false,
                            NickName = "Voan",
                            NormalizedEmail = "MEDIC@LOCALHOST.COM",
                            NormalizedUserName = "MEDIC",
                            PasswordHash = "AQAAAAEAACcQAAAAEGa31WakIQEsYDAIweEIeC2TzFiX7ikSkBdY4PvBqZZAPXHuBgE2Rli9s37N66uIsQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b72afc41-5316-4cf7-ad9e-e0694ead3269",
                            TwoFactorEnabled = false,
                            UserName = "medic"
                        },
                        new
                        {
                            Id = "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                            AccessFailedCount = 0,
                            BloodGroupId = new Guid("89160257-98b1-4c69-bf39-fef973cad668"),
                            BrigadeId = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            ConcurrencyStamp = "1e719da7-1d4f-422c-97c5-11d4558741af",
                            Email = "serviceman@localhost.com",
                            EmailConfirmed = true,
                            FullName = "Nazarenko Ivan Petrovych",
                            LockoutEnabled = false,
                            NickName = "Prometey",
                            NormalizedEmail = "SERVICEMAN@LOCALHOST.COM",
                            NormalizedUserName = "SERVICEMAN",
                            PasswordHash = "AQAAAAEAACcQAAAAEB5MoX+4qJ9bz2yNM1vyA5avdzQDzXE7CRNF/SPbT2opHaQKDDptgshLv6KGxPag2Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4aee0faa-3fde-4712-af9f-16dcecb9f2b6",
                            TwoFactorEnabled = false,
                            UserName = "serviceman"
                        });
                });

            modelBuilder.Entity("GoldenHour.Domain.UserRefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Expire")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceManId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceManId")
                        .IsUnique();

                    b.ToTable("UserRefreshTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                            ConcurrencyStamp = "9658c3ee-0895-425f-b8d5-09650855a590",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3306930e-624c-4790-984a-b95632753e8b",
                            ConcurrencyStamp = "4e7f83e5-c5eb-4fd5-a867-4ac177c673ec",
                            Name = "Medic",
                            NormalizedName = "MEDIC"
                        },
                        new
                        {
                            Id = "6c4f337a-ad38-47c5-83b2-e959d752f071",
                            ConcurrencyStamp = "941da4f5-dce3-4929-9568-06a4189116c4",
                            Name = "Military",
                            NormalizedName = "MILITARY"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "408aa945-3d84-4421-8342-7269ec64d949",
                            RoleId = "546bc2c7-db8d-4634-9bb9-a315bf9a2898"
                        },
                        new
                        {
                            UserId = "3f4631bd-f907-4409-b416-ba356312e659",
                            RoleId = "3306930e-624c-4790-984a-b95632753e8b"
                        },
                        new
                        {
                            UserId = "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                            RoleId = "6c4f337a-ad38-47c5-83b2-e959d752f071"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GoldenHour.Domain.HelpPhoto", b =>
                {
                    b.HasOne("GoldenHour.Domain.Incident", "Incident")
                        .WithMany("HelpPhotos")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("GoldenHour.Domain.Incident", b =>
                {
                    b.HasOne("GoldenHour.Domain.ServiceMan", "Medic")
                        .WithMany("HelpedIncidents")
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GoldenHour.Domain.ServiceMan", "ServiceMan")
                        .WithMany("Incidents")
                        .HasForeignKey("ServiceManId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Medic");

                    b.Navigation("ServiceMan");
                });

            modelBuilder.Entity("GoldenHour.Domain.ServiceMan", b =>
                {
                    b.HasOne("GoldenHour.Domain.BloodGroup", "BloodGroup")
                        .WithMany("ServiceMen")
                        .HasForeignKey("BloodGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldenHour.Domain.Brigade", "Brigade")
                        .WithMany("ServiceMen")
                        .HasForeignKey("BrigadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodGroup");

                    b.Navigation("Brigade");
                });

            modelBuilder.Entity("GoldenHour.Domain.UserRefreshToken", b =>
                {
                    b.HasOne("GoldenHour.Domain.ServiceMan", "ServiceMan")
                        .WithMany("UserRefreshTokens")
                        .HasForeignKey("ServiceManId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceMan");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GoldenHour.Domain.ServiceMan", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GoldenHour.Domain.ServiceMan", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldenHour.Domain.ServiceMan", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GoldenHour.Domain.ServiceMan", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GoldenHour.Domain.BloodGroup", b =>
                {
                    b.Navigation("ServiceMen");
                });

            modelBuilder.Entity("GoldenHour.Domain.Brigade", b =>
                {
                    b.Navigation("ServiceMen");
                });

            modelBuilder.Entity("GoldenHour.Domain.Incident", b =>
                {
                    b.Navigation("HelpPhotos");
                });

            modelBuilder.Entity("GoldenHour.Domain.ServiceMan", b =>
                {
                    b.Navigation("HelpedIncidents");

                    b.Navigation("Incidents");

                    b.Navigation("UserRefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}