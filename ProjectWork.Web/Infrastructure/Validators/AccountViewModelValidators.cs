using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using ProjectWork.Web.Models;

namespace ProjectWork.Web.Infrastructure.Validators
{
    public class LoginViewModelValidators:AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidators()
        {
            RuleFor(login => login.Username).NotEmpty().WithMessage("Invalid username");
            RuleFor(login => login.Password).NotEmpty().WithMessage("Invalid password");
        }

    }

    public class RegisterViewModelValidators : AbstractValidator<RegistrationViewModel>
    {
        public RegisterViewModelValidators()
        {
            //RuleFor(login => login.Username).NotEmpty().Length(6,25).Must(login=>!login.All(c=>char.IsWhiteSpace(c))).WithMessage("Invalid username. Usernames must be of length 6 to 25, and no white space character is alllowed.");
            //RuleFor(login => login.Password).NotEmpty().Length(6, 15).WithMessage("Invalid password. Password must be of length 6 to 25");
            //RuleFor(login => login.Email).NotEmpty().EmailAddress().Length(3, 30).WithMessage("Invalid email address");
            RuleFor(login => login.Username).NotEmpty().WithMessage("Invalid username.");
            RuleFor(login => login.Password).NotEmpty().WithMessage("Invalid password.");
            RuleFor(login => login.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address");

        }

    }
}