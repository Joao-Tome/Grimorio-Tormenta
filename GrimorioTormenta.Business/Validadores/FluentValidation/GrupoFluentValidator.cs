using FluentValidation;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Enums;
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

            RuleFor(x => x.Tipo)
                .NotNull().WithMessage("Tipo é requerido")
                .IsEnumName(typeof(TiposGrupo)).WithMessage("Tipo Precisa ser valido");

            RuleFor(x => x.Status).IsInEnum().WithMessage("Status Precisa ser Valido");
        }
    }
}
