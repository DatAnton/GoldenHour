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
    [Migration("20230503214504_AddedIncidentTable")]
    partial class AddedIncidentTable
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
                        .IsRequired()
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
                            ConcurrencyStamp = "3761fdac-534a-4f6a-a973-56d261d86ff8",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            FullName = "",
                            LockoutEnabled = false,
                            NickName = "admin",
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEKc0n0rsDoYCc2w2mZ8eRZt9yBrw0p//2qXOT4fzn05ww7uzdHPrqCjNcnd202hUkw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "543ba7d2-44d8-449f-947f-693ddf0ea4b0",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "3f4631bd-f907-4409-b416-ba356312e659",
                            AccessFailedCount = 0,
                            BloodGroupId = new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                            BrigadeId = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            ConcurrencyStamp = "d27a898f-1088-4b25-b8d9-4f9893bbc5e8",
                            Email = "medic@localhost.com",
                            EmailConfirmed = true,
                            FullName = "Bondar Volodymyr Ivanovych",
                            LockoutEnabled = false,
                            NickName = "Voan",
                            NormalizedEmail = "MEDIC@LOCALHOST.COM",
                            NormalizedUserName = "MEDIC",
                            PasswordHash = "AQAAAAEAACcQAAAAEByxMDfPN4Fb0YbvnAWUhq9puGLcmGM4qQH42PYC+aPuDB9T5h4i1QtgSafbBbBbcg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f8c9ac02-0173-4962-9070-1f12dfb01170",
                            TwoFactorEnabled = false,
                            UserName = "medic"
                        },
                        new
                        {
                            Id = "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                            AccessFailedCount = 0,
                            BloodGroupId = new Guid("89160257-98b1-4c69-bf39-fef973cad668"),
                            BrigadeId = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            ConcurrencyStamp = "67ebb246-baca-45db-a4c1-6b595d46123a",
                            Email = "serviceman@localhost.com",
                            EmailConfirmed = true,
                            FullName = "Nazarenko Ivan Petrovych",
                            LockoutEnabled = false,
                            NickName = "Prometey",
                            NormalizedEmail = "SERVICEMAN@LOCALHOST.COM",
                            NormalizedUserName = "SERVICEMAN",
                            PasswordHash = "AQAAAAEAACcQAAAAELSFRLFlPLZAWI0o6uhb0e76V8ck9HtE0b0jjVspeoeP9HDVXrLYeob73EGKk55mew==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0816ac4c-e317-46fc-b269-1b5ae14d02d3",
                            TwoFactorEnabled = false,
                            UserName = "serviceman"
                        });
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
                            ConcurrencyStamp = "be3395fc-7ace-4594-a034-c41275e60e52",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3306930e-624c-4790-984a-b95632753e8b",
                            ConcurrencyStamp = "c8c10746-1850-4ee3-8257-2183294183c6",
                            Name = "Medic",
                            NormalizedName = "MEDIC"
                        },
                        new
                        {
                            Id = "6c4f337a-ad38-47c5-83b2-e959d752f071",
                            ConcurrencyStamp = "ca66346b-8d4e-440d-bc4b-5800797a16ca",
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
                });
#pragma warning restore 612, 618
        }
    }
}