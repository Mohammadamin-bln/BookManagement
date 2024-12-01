using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Application.Features.Command;
using FluentValidation;

namespace BookManagement.Application.Validators
{
    public class SingupCommandValidator : AbstractValidator<SingupCommand>
    {
        public SingupCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("email should not be empty")
                .EmailAddress().WithMessage("Ivalid email format")
                .Must(email => email.EndsWith("@gmail.com"))
                .WithMessage("Email must end with @gmail.com");

            RuleFor(x => x.Age)
                .GreaterThan(10).WithMessage("if you are lower then 10 you cant  singup");

                
                
        }
    }
}
