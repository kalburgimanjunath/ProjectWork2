namespace ProjectWork.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectWork.Data.ProjectWorkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectWork.Data.ProjectWorkContext context)
        {
            // create roles
            context.RoleSet.AddOrUpdate(r => r.Name, GenerateRoles());

            // username: chsakell, password: homecinema
            context.UserSet.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
                    Email="galibgaurav@gmail.com",
                    Username="gaurav123",
                    HashedPassword ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                }
            });

            // // create user-admin for chsakell
            context.UserRoleSet.AddOrUpdate(new UserRole[] {
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 1  // chsakell
                }
            });
        }
        private Role[] GenerateRoles()
        {
            Role[] _roles = new Role[]{
                new Role()
                {
                    Name="Admin"
                }
            };

            return _roles;
        }
    }
}
