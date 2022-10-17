using FridgeMicroservice.Models.Request;
using FluentValidation;

namespace FridgeMicroservice.Models.Validation
{
    public class FridgeProductModelUpdateValidator : AbstractValidator<FridgeProductModelUpdate>
    {
        public FridgeProductModelUpdateValidator()
        {
            RuleFor(fp => fp.ProductCount).InclusiveBetween(0, 999)
                                          .WithMessage("Count can includes 0 to 999");

            RuleFor(fp => fp.FridgeId).NotNull()
                                      .WithMessage("Fridge can not be null")
                                      .NotEmpty()
                                      .WithMessage("Fridge can not be empty");

            RuleFor(fp => fp.ProductId).NotNull()
                                       .WithMessage("Product can not be null")
                                       .NotEmpty()
                                       .WithMessage("Product can not be empty");
        }
    }
}
