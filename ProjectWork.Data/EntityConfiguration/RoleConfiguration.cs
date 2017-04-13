using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjectWork.Data
{
    public class RoleConfiguration:EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(r => r.Name).IsRequired().HasMaxLength(50);
           
        }
    }
}
