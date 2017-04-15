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
            RuleFor(login => login.Username).NotEmpty().WithMessage("Invalid username");
            RuleFor(login => login.Password).NotEmpty().WithMessage("Invalid password");
            RuleFor(login => login.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address");
        }

    }
}