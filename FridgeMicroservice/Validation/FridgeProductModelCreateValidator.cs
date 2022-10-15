using FluentValidation;
using FridgeMicroservice.Models.Request;

namespace FridgeMicroservice.Validation
{
    public class FridgeProductModelCreateValidator : AbstractValidator<FridgeProductModelCreate>
    {
        public FridgeProductModelCreateValidator()
        {
            RuleFor(fp => fp.ProductId).NotNull()
                                       .NotEmpty();

            RuleFor(fp => fp.ProductCount).NotNull()
                                          .NotEmpty()
                                          .ExclusiveBetween(0, 999);
        }
    }
}
