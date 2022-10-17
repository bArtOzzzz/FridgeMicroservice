using FluentValidation;
using FridgeMicroservice.Models.Request;

namespace FridgeMicroservice.Models.Validation
{
    public class ModelModelValidator : AbstractValidator<ModelModel>
    {
        public ModelModelValidator()
        {
            RuleFor(m => m.Name).Length(2, 16)
                                .WithMessage("Length should be 2 to 16 characters");

            RuleFor(m => m.ProductionYear).InclusiveBetween(1913, 2022)
                                          .WithMessage("Years can include 1913 to 2022");
        }
    }
}
