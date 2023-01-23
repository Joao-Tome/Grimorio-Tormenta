using FluentValidation;
using GrimorioTormenta.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Business.Validadores
{
    public class GrupoValidator : AbstractValidator<GrupoDTO>
    {
        public GrupoValidator() {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome é requerido")
                .NotEmpty().WithMessage("Nome é requerido")
                .MaximumLength(50).WithMessage("Nome não pode ter mais de 50 Caracteres");
            
        }
    }
}
