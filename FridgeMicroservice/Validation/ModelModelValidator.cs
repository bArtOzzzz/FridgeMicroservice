using FluentValidation;
using FridgeMicroservice.Models.Request;

namespace FridgeMicroservice.Validation
{
    public class ModelModelValidator : AbstractValidator<ModelModel>
    {
        public ModelModelValidator()
        {
            RuleFor(m => m.Name).NotNull()
                                .NotEmpty()
                                .Length(2, 16);

            RuleFor(m => m.ProductionYear).NotNull()
                                          .NotEmpty()
                                          .InclusiveBetween(1913, 2022);
        }
    }
}
