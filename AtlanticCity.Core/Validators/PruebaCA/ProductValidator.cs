using AtlanticCity.Core.DTOs.PruebaCA;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.Validators.PruebaCA
{
    public class ProductInsertValidator : AbstractValidator<ProductInsertDTO>
    {
        public ProductInsertValidator()
        {

            RuleFor(p => p.ProductName).NotNull().WithMessage("El campo de nombre no debe ser nulo")
                                    .NotEmpty().WithMessage("No permite vacio")
                                    .Length(5, 200).WithMessage("Ingrese minimo 5 caracteres");

            RuleFor(p => p.UnitPrice).NotNull().WithMessage("El campo de nombre no debe ser nulo")
                                     .GreaterThan(0).WithMessage("Number of trainings must be greater than 0.");
        }
    }

    public class ProductUpdateValidator : AbstractValidator<ProductUpdateDTO>
    {
        public ProductUpdateValidator()
        {
            
        }
    }

}
