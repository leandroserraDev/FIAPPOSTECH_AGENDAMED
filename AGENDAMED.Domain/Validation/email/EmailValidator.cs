using AGENDAMED.Domain.Interface.Services.email.emailBase;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Validation.email
{
    public class EmailValidator : AbstractValidator<EmailBase>
    {
        public EmailValidator()
        {
            RuleFor(obj => obj.SendTO).NotNull().WithMessage("Destinatário é obrigatório");
            RuleFor(obj => obj.SendTO).NotEmpty().WithMessage("Destinatário é obrigatório");

            RuleFor(obj => obj.Body).NotNull().WithMessage("Body é obrigatório");
            RuleFor(obj => obj.Body).NotEmpty().WithMessage("Body é obrigatório");

            RuleFor(obj => obj.Subject).NotNull().WithMessage("Body é obrigatório");
            RuleFor(obj => obj.Subject).NotEmpty().WithMessage("Body é obrigatório");


        }
    }
}
