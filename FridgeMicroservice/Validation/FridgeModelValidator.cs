using FridgeMicroservice.Models.Request;
using FluentValidation;

namespace FridgeMicroservice.Models.Validation
{
    public class FridgeModelValidator : AbstractValidator<FridgeModel>
    {
        public FridgeModelValidator()
        {
            RuleFor(f => f.ModelId).NotNull()
                                   .WithMessage("Model can not be null")
                                   .NotEmpty()
                                   .WithMessage("Model can not be empty");

            RuleFor(f => f.Manufacturer).MinimumLength(2)
                                        .WithMessage("Minimum length 2 characters");

            RuleFor(f => f.OwnerName).Length(3, 22)
                                     .WithMessage("Length should be 3 to 22 characters");
        }
    }
}
