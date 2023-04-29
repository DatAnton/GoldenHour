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
    [Migration("20230429134618_AddedShortNameForBrigade")]
    partial class AddedShortNameForBrigade
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

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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
                            ConcurrencyStamp = "b4f3cb66-56b5-46c8-8690-01d7d14e9563",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            FullName = "",
                            LockoutEnabled = false,
                            NickName = "admin",
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEAwLJ2n2LW4Gyj2HmB2dZcTzm0eq3casXCyfKu4m8al3S5nNjigOtNThReWHXmEF5Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3381a8c3-805f-4e81-9c19-c8d2f9a28a6d",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "3f4631bd-f907-4409-b416-ba356312e659",
                            AccessFailedCount = 0,
                            BloodGroupId = new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                            BrigadeId = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            ConcurrencyStamp = "026e71d0-49ff-4328-ba23-08d1d8370d83",
                            Email = "medic@localhost.com",
                            EmailConfirmed = true,
                            FullName = "Bondar Volodymyr Ivanovych",
                            LockoutEnabled = false,
                            NickName = "Voan",
                            NormalizedEmail = "MEDIC@LOCALHOST.COM",
                            NormalizedUserName = "MEDIC",
                            PasswordHash = "AQAAAAEAACcQAAAAEOW2t4UJNZSpgPZHiX6+J+a2d3fZBlOw+NLxePQ6KuicnQc8jfiPGNABgS++fX17LQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d7187d7f-f27e-45bb-b576-b02ecf140b71",
                            TwoFactorEnabled = false,
                            UserName = "medic"
                        },
                        new
                        {
                            Id = "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                            AccessFailedCount = 0,
                            BloodGroupId = new Guid("89160257-98b1-4c69-bf39-fef973cad668"),
                            BrigadeId = new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                            ConcurrencyStamp = "4fbe4b2c-5782-462f-a9fb-2b1e80f21119",
                            Email = "serviceman@localhost.com",
                            EmailConfirmed = true,
                            FullName = "Nazarenko Ivan Petrovych",
                            LockoutEnabled = false,
                            NickName = "Prometey",
                            NormalizedEmail = "SERVICEMAN@LOCALHOST.COM",
                            NormalizedUserName = "SERVICEMAN",
                            PasswordHash = "AQAAAAEAACcQAAAAEEACMEUWvcqOs13TMytwKJwbHD/TCy8Y3wEq6PQyMqhTsuG5w15eC83zhTsmEy2dwg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "dbfe36b7-76b4-42ec-aa35-323995b9b753",
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
                            ConcurrencyStamp = "d3103057-7b4e-4d63-acfd-fdc45a3f4dc9",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3306930e-624c-4790-984a-b95632753e8b",
                            ConcurrencyStamp = "95c4b7b5-f56d-42fb-a828-c8bdf9cb07cc",
                            Name = "Medic",
                            NormalizedName = "MEDIC"
                        },
                        new
                        {
                            Id = "6c4f337a-ad38-47c5-83b2-e959d752f071",
                            ConcurrencyStamp = "0f80fb69-d021-48fb-9078-5f6618d82e83",
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
