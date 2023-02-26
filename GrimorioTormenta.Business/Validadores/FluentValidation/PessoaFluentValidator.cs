using FluentValidation;
using GrimorioTormenta.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Business.Validadores.FluentValidation
{
    public class PessoaFluentValidator : AbstractValidator<PessoaDTO>
    {
        public PessoaFluentValidator() { 
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email não pode ser Vazio")
                .EmailAddress().WithMessage("Email precisa ser um email Valido");

            RuleFor(x => x.NickName)
                .NotEmpty().WithMessage("Nickname não pode ser Vazio")
                .MaximumLength(50).WithMessage("Nickname Não poder mais de 50 caracteres") ;

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Senha não pode ser Vazio")
                .Matches(@"[A-Z]+").WithMessage("Senha precisa conter pelo menos uma letra Maiuscula.")
                .Matches(@"[a-z]+").WithMessage("Senha precisa conter pelo menos uma letra Maiuscula.")
                .Matches(@"[0-9]+").WithMessage("Senha precisa conter pelo menos um numero");

        }
    }
}
