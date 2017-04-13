using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjectWork.Data
{
   public class ProjectWorkContext :DbContext
    {
        public ProjectWorkContext():
            base("ProjectWork")
        {
            Database.SetInitializer<ProjectWorkContext>(null);
        }
        #region Entity Sets
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
        }
    }
}
