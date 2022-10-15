using FluentValidation;
using FridgeMicroservice.Models.Request;

namespace FridgeMicroservice.Validation
{
    public class FridgeModelValidator : AbstractValidator<FridgeModel>
    {
        public FridgeModelValidator()
        {
            RuleFor(f => f.ModelId).NotNull().NotEmpty();
            RuleFor(f => f.Manufacturer).NotNull().Length(2, 22);
            RuleFor(f => f.OwnerName).NotNull().Length(3, 22);
        }
    }
}
