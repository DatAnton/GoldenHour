using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Persistance
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> contextOptions) : base(contextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "408aa945-3d84-4421-8342-7269ec64d949",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    EmailConfirmed = true
                },
                new IdentityUser
                {
                    Id = "3f4631bd-f907-4409-b416-ba356312e659",
                    Email = "medic@localhost.com",
                    NormalizedEmail = "MEDIC@LOCALHOST.COM",
                    NormalizedUserName = "MEDIC@LOCALHOST.COM",
                    UserName = "medic@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    EmailConfirmed = true
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
                }
            );
        }
    }
}
