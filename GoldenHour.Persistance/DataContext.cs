using GoldenHour.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Persistance
{
    public class DataContext : IdentityDbContext<ServiceMan>
    {
        public DataContext(DbContextOptions<DataContext> contextOptions) : base(contextOptions)
        {
            
        }

        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<Brigade> Brigades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BloodGroup>().ToTable("BloodGroups", "meta")
                .HasData(new List<BloodGroup>
                {
                    new BloodGroup
                    {
                        Id = Guid.Parse("ebe5ba94-2c9d-46f4-8188-4ca1fc677d70"),
                        Name = "First — 0 (І)",
                    },
                    new BloodGroup
                    {
                        Id = Guid.Parse("89160257-98b1-4c69-bf39-fef973cad668"),
                        Name = "Second — A (ІІ)",
                    },
                    new BloodGroup
                    {
                        Id = Guid.Parse("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                        Name = "Third — B (ІІІ)",
                    },
                    new BloodGroup
                    {
                        Id = Guid.Parse("1daaa8e0-b24b-4a78-84f7-c0d5e958fccd"),
                        Name = "Fourth — AB (ІV)"
                    },
                });

            builder.Entity<Brigade>().HasData(new List<Brigade>
            {
                new Brigade
                {
                    Id = Guid.Parse("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                    Name = "14th Mechanized Brigade 'Roman the Great' (MU A2331), Volodymyr-Volynsky, Volyn Oblast",
                    Department = "97"
                },
                new Brigade
                {
                    Id = Guid.Parse("cf2a2a3a-861f-45c9-9b35-456301093fa1"),
                    Name = "24th Mechanized Brigade 'King Daniel' (MU A0998), Yavoriv, Lviv Oblast",
                    Department = "52"
                }
            });

            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "3306930e-624c-4790-984a-b95632753e8b",
                    Name = "Medic",
                    NormalizedName = "MEDIC"
                },
                new IdentityRole
                {
                    Id = "6c4f337a-ad38-47c5-83b2-e959d752f071",
                    Name = "Military",
                    NormalizedName = "MILITARY"
                }
            });

            var hasher = new PasswordHasher<ServiceMan>();

            builder.Entity<ServiceMan>().HasData(
                new ServiceMan
                {
                    Id = "408aa945-3d84-4421-8342-7269ec64d949",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN",
                    UserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    EmailConfirmed = true,
                    NickName = "admin",
                    FullName = "",
                    BloodGroupId = Guid.Parse("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                    BrigadeId = Guid.Parse("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a")
                },
                new ServiceMan
                {
                    Id = "3f4631bd-f907-4409-b416-ba356312e659",
                    Email = "medic@localhost.com",
                    NormalizedEmail = "MEDIC@LOCALHOST.COM",
                    NormalizedUserName = "MEDIC",
                    UserName = "medic",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    EmailConfirmed = true,
                    NickName = "Voan",
                    FullName = "Bondar Volodymyr Ivanovych",
                    BloodGroupId = Guid.Parse("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                    BrigadeId = Guid.Parse("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a")
                },
                new ServiceMan
                {
                    Id = "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                    Email = "serviceman@localhost.com",
                    NormalizedEmail = "SERVICEMAN@LOCALHOST.COM",
                    NormalizedUserName = "SERVICEMAN",
                    UserName = "serviceman",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    EmailConfirmed = true,
                    NickName = "Prometey",
                    FullName = "Nazarenko Ivan Petrovych",
                    BloodGroupId = Guid.Parse("89160257-98b1-4c69-bf39-fef973cad668"),
                    BrigadeId = Guid.Parse("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a")
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                    UserId = "408aa945-3d84-4421-8342-7269ec64d949"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "3306930e-624c-4790-984a-b95632753e8b",
                    UserId = "3f4631bd-f907-4409-b416-ba356312e659"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "6c4f337a-ad38-47c5-83b2-e959d752f071",
                    UserId = "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d"
                }
            );
        }
    }
}
