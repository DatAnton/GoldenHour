﻿// <auto-generated />
using System;
using GoldenHour.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoldenHour.Persistance.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BloodGroups", "meta");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ebe5ba94-2c9d-46f4-8188-4ca1fc677d70"),
                            Name = "First — 0 (І)"
                        },
                        new
                        {
                            Id = new Guid("89160257-98b1-4c69-bf39-fef973cad668"),
                            Name = "Second — A (ІІ)"
                        },
                        new
                        {
                            Id = new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                            Name = "Third — B (ІІІ)"
                        },
                        new
                        {
                            Id = new Guid("1daaa8e0-b24b-4a78-84f7-c0d5e958fccd"),
                            Name = "Fourth — AB (ІV)"
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brigades");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            Department = "97",
                            Name = "14th Mechanized Brigade 'Roman the Great' (MU A2331), Volodymyr-Volynsky, Volyn Oblast"
                        },
                        new
                        {
                            Id = new Guid("cf2a2a3a-861f-45c9-9b35-456301093fa1"),
                            Department = "52",
                            Name = "24th Mechanized Brigade 'King Daniel' (MU A0998), Yavoriv, Lviv Oblast"
                        });
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
                        .HasColumnType("nvarchar(max)");

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
                            ConcurrencyStamp = "9167e0b5-de33-49a2-b29c-8f0569872d39",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            FullName = "",
                            LockoutEnabled = false,
                            NickName = "admin",
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEF0KQZoe1Hr93a3b16Rnp68neIxzZl1cKC8iVJCWoNvjZuaIb5Ali5qI2d7+x7QiRg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c601e864-6841-41f4-a132-6e9c201645c5",
                            TwoFactorEnabled = false,
                            UserName = "admin@localhost.com"
                        },
                        new
                        {
                            Id = "3f4631bd-f907-4409-b416-ba356312e659",
                            AccessFailedCount = 0,
                            BloodGroupId = new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                            BrigadeId = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            ConcurrencyStamp = "6004bab2-7f98-4473-9bc0-21a9dbab3582",
                            Email = "medic@localhost.com",
                            EmailConfirmed = true,
                            FullName = "Bondar Volodymyr Ivanovych",
                            LockoutEnabled = false,
                            NickName = "Voan",
                            NormalizedEmail = "MEDIC@LOCALHOST.COM",
                            NormalizedUserName = "MEDIC@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEG190lt35mMfapd+fWA4tZTsAaI7pIZJtkbOzNYhQRgRyK42Wr4CQWh6Fd03jvmheQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6ee57ce8-b013-4abf-8b3b-2540780676ec",
                            TwoFactorEnabled = false,
                            UserName = "medic"
                        },
                        new
                        {
                            Id = "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                            AccessFailedCount = 0,
                            BloodGroupId = new Guid("89160257-98b1-4c69-bf39-fef973cad668"),
                            BrigadeId = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            ConcurrencyStamp = "dcc9c6ce-3591-4fc8-b0d6-d474a5a67e62",
                            Email = "serviceman@localhost.com",
                            EmailConfirmed = true,
                            FullName = "Nazarenko Ivan Petrovych",
                            LockoutEnabled = false,
                            NickName = "Prometey",
                            NormalizedEmail = "SERVICEMAN@LOCALHOST.COM",
                            NormalizedUserName = "SERVICEMAN",
                            PasswordHash = "AQAAAAEAACcQAAAAEDOz1kVDYR2Y0QVfA22owMe4ly7Zd+aJF+Ld6H+3fXWQuQb1Nc4R3qs/BskWIlk/XQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e225c222-b7f2-4a56-8ead-aa4a30aff1bd",
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
                            ConcurrencyStamp = "729ae95a-454d-4b2c-84a0-9f96d5224ef8",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3306930e-624c-4790-984a-b95632753e8b",
                            ConcurrencyStamp = "977e5c99-5960-4ff3-8255-4dfd0281729d",
                            Name = "Medic",
                            NormalizedName = "MEDIC"
                        },
                        new
                        {
                            Id = "6c4f337a-ad38-47c5-83b2-e959d752f071",
                            ConcurrencyStamp = "7d0e443c-8ce7-485f-b9e2-83c85f1a620d",
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
#pragma warning restore 612, 618
        }
    }
}
