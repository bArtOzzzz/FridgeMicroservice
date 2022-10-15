using FluentValidation;
using FridgeMicroservice.Models.Request;

namespace FridgeMicroservice.Validation
{
    public class FridgeProductModelUpdateValidator : AbstractValidator<FridgeProductModelUpdate>
    {
        public FridgeProductModelUpdateValidator()
        {
            RuleFor(fp => fp.ProductCount).NotNull()
                                          .NotEmpty()
                                          .ExclusiveBetween(0, 999);

            RuleFor(fp => fp.FridgeId).NotNull()
                                      .NotEmpty();

            RuleFor(fp => fp.ProductId).NotNull()
                                       .NotEmpty();
        }
    }
}
