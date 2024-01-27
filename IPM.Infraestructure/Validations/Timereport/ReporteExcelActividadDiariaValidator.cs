using IPM.Core.Dtos;
using FluentValidation;

namespace IPM.Infraestructure.Validations.Timereport;

public class ReporteExcelActividadDiariaValidator : AbstractValidator<CalendarioPorfechayUsuario>
{

    public ReporteExcelActividadDiariaValidator()
    {
        RuleFor(fechavalidar => fechavalidar.FechaInicio)
            .Must((calendario, fechaInicio)=> 
                   fechaInicio.Month == calendario.FechaFin.Month)
            .WithMessage("La Fechas deben tener el mismo mes.");
        
    }

}
