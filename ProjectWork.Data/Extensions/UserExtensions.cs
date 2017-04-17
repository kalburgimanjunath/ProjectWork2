﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;

namespace ProjectWork.Data.Extensions
{
    public static class UserExtensions
    {
        public static User GetSingleByUsername(this IEntityBaseRepository<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Username == username);
        }

        public static User GetSingleByEmail(this IEntityBaseRepository<User> userRepository, string username,string email)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Email == email);
        }

    }
}
