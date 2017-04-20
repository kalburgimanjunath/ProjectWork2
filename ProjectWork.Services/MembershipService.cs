﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;
using ProjectWork.Data;
using ProjectWork.Data.Extensions;
using System.Security.Principal;

namespace ProjectWork.Services
{
    public class MembershipService : IMembershipService
    {
        #region Variables
        private readonly IEntityBaseRepository<User> _userRepository;
        private readonly IEntityBaseRepository<Role> _roleRepository;
        private readonly IEntityBaseRepository<UserRole> _userRoleRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSenderService _emailSenderService;
        #endregion
        public MembershipService(IEntityBaseRepository<User> userRepository, IEntityBaseRepository<Role> roleRepository, IEntityBaseRepository<UserRole> userRoleRepository, IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
            // _emailSenderService = emailSenderService;
        }

        #region Helper methods
        private void addUserToRole(User user, int roleId)
        {
            var role = _roleRepository.GetSingle(roleId); if (role == null) throw new ApplicationException("Role doesn't exist.");
            var userRole = new UserRole() { RoleId = role.ID, UserId = user.ID }; _userRoleRepository.Add(userRole);
        }
        private bool isPasswordValid(User user, string password) { return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword); }
        private bool isUserValid(User user, string password)
        {
            if (isPasswordValid(user, password)) { return !user.IsLocked; }
            return false;
        }
        #endregion

        #region IMembershipService Implementation

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = _userRepository.GetSingleByUsername(username);
            if (user != null && isUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.Username);
                membershipCtx.User = user;

                var identity = new GenericIdentity(user.Username);
                membershipCtx.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(x => x.Name).ToArray());
            }

            return membershipCtx;
        }
        public User CreateUser(string username, string email, string password, int[] roles)
        {
            var existingUser = _userRepository.FindBy(x => x.Username == username).Any<User>(); ;
            var existingEmailId = _userRepository.FindBy(x => x.Email == email).Any<User>();
            //var existingEmailId=_userRepository.a
            if (existingUser || existingEmailId)
            {
                throw new Exception("Username Or Email ID is already in use");
            }

            var passwordSalt = _encryptionService.CreateSalt();

            var user = new User()
            {
                Username = username,
                Salt = passwordSalt,
                Email = email,
                IsLocked = false,
                HashedPassword = _encryptionService.EncryptPassword(password, passwordSalt),
                DateCreated = DateTime.Now,
                EmailVerificationCode = Guid.NewGuid()
            };

            _userRepository.Add(user);

            _unitOfWork.Commit();

            if (roles != null || roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    addUserToRole(user, role);
                }
            }

            _unitOfWork.Commit();

            return user;
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetSingle(userId);
        }

        public List<Role> GetUserRoles(string username)
        {
            List<Role> _result = new List<Role>();

            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                foreach (var userRole in existingUser.UserRoles)
                {
                    _result.Add(userRole.Role);
                }
            }

            return _result.Distinct().ToList();
        }

        public bool ConfirmEmailAddress(string email, string validationCode)
        {
            var user = _userRepository.FindBy(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {
                 
                return String.Equals(user.EmailVerificationCode.ToString().ToUpper(), validationCode);

            }
            else
                return false;
       }
        #endregion

    }
}
