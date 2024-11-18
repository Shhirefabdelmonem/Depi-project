using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LisbrarySystem.Models
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        public Context()
        {

        }

        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Buy> Buys { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /////////user-admin///////////
            //Seeding a  'Administrator' role to AspNetRoles table
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "540fa4db-060f-4f1b-b60a-dd199bfe4f0b", Name = "AdminsRole", NormalizedName = "ADMINSROLE" }, new IdentityRole { Id = "540fa4db-060f-4f1b-b60a-dd199bfe4111", Name = "UsersRole", NormalizedName = "USERSROLE" });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();


            //Seeding the User to AspNetUsers table
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "62fe5285-fd68-4711-ae93-673787f4ac66", // primary key
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@admin.com",
                    NormalizedEmail = "admin@admin.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "123"),
                    EmailConfirmed = true,
                    FirstName = "System",
                    LastName = "Admin" 
                },
                new ApplicationUser
                { // primary key
                    Id = "62fe5285-fd68-4711-ae93-673787f4a111",
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@user.com",
                    NormalizedEmail = "user@user.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "123"),
                    EmailConfirmed = true,
                    FirstName = "Regular",
                    LastName = "User" 

                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4f0b",
                    UserId = "62fe5285-fd68-4711-ae93-673787f4ac66"
                }, new IdentityUserRole<string>
                {
                    RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4111",
                    UserId = "62fe5285-fd68-4711-ae93-673787f4a111"
                }, new IdentityUserRole<string>
                {
                    RoleId = "540fa4db-060f-4f1b-b60a-dd199bfe4111",
                    UserId = "62fe5285-fd68-4711-ae93-673787f4ac66"
                }
            );
        }

        }

    }

