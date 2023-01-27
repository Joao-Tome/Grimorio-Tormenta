using FluentValidation;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Business.Validadores.FluentValidation
{
    public class GrupoFluentValidator : AbstractValidator<GrupoDTO>
    {
        public GrupoFluentValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome é requerido")
                .NotEmpty().WithMessage("Nome é requerido")
                .MaximumLength(50).WithMessage("Nome não pode ter mais de 50 Caracteres");

        }
    }
}
