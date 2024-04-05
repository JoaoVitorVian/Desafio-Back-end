using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O Nome não pode ser Nulo.")

                .NotEmpty()
                .WithMessage("O Nome não pode ser Vazio.")

                .MinimumLength(3)
                .WithMessage("O Nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O Nome deve ter nom máximo 80 caracteres.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O Email não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O Email não pode ser vazio.")

                .MinimumLength(10)
                .WithMessage("O Email deve ter no mínimo 10 caracteres")

                .MaximumLength(180)
                .WithMessage("O Email deve ter no máximo 180 caracteres")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O Email informado não é válido");

            RuleFor(x => x.Password)
               .NotNull()
               .WithMessage("A Senha não pode ser nulo.")

               .NotEmpty()
               .WithMessage("A Senha não pode ser vazio.")

               .MinimumLength(6)
               .WithMessage("A Senha deve ter no mínimo 6 caracteres")

               .MaximumLength(30)
               .WithMessage("A Senha deve ter no máximo 30 caracteres");
        }
    }
}
