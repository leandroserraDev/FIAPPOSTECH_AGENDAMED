using AGENDAMED.Domain.Entities.user;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Validation.user
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(obj => obj.Name).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(obj => obj.Name).NotNull().WithMessage("Nome é obrigatório");

            RuleFor(obj => obj.LastName).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(obj => obj.LastName).NotNull().WithMessage("Nome é obrigatório");

            RuleFor(obj => obj.Email).NotEmpty().WithMessage("E-mail é obrigatório");
            RuleFor(obj => obj.Email).NotNull().WithMessage("E-mail é obrigatório");

        }
    }
}
