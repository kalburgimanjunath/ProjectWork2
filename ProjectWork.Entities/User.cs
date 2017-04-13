using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Entities
{
    public class User: IEntityBase
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateCreated { get; set; }

        //Navigation Property
        //Gaurav-Navigation properties are typically defined as virtual so that they can take advantage of  certain Entity Framework functionality.
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
