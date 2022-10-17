using FridgeMicroservice.Models.Request;
using FluentValidation;

namespace FridgeMicroservice.Models.Validation
{
    public class FridgeProductModelCreateValidator : AbstractValidator<FridgeProductModelCreate>
    {
        public FridgeProductModelCreateValidator()
        {
            RuleFor(fp => fp.ProductId).NotNull()
                                       .WithMessage("Product can not be null")
                                       .NotEmpty()
                                       .WithMessage("Product can not be empty");

            RuleFor(fp => fp.ProductCount).InclusiveBetween(0, 999)
                                          .WithMessage("Count can includes 0 to 999");
        }
    }
}
