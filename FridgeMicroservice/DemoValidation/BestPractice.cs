using FluentValidation;

namespace FridgeMicroservice.NewFolder
{
    // Entity class
    public class User
    {
        public Guid Id { get; set; }    
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public Membership[]? Memberships { get; set; }
    }

    public record Membership(string Name);

    public class FakeValidator : AbstractValidator<User>
    {
        public FakeValidator()
        {
            Include(new UserSimpleValidator());
            Include(new UserComplexValidator());
        }
    }

    // Class for simple validation
    public class UserSimpleValidator : AbstractValidator<User>
    {
        public UserSimpleValidator()
        {
            // Name
            RuleFor(x => x.Name).NotEmpty()
                                .NotNull()
                                .Length(2, 22);

            // Email
            RuleFor(x => x.Email).NotEmpty()
                                 .EmailAddress();

            // Description
            RuleFor(x => x.Description).NotEmpty()
                                       .NotNull()
                                       .Length(0, 250);

            // ID
            RuleFor(x => x.Id).NotEmpty()
                              .NotNull();

            // Address
            RuleFor(u => u.Address).NotNull()
                                   .MaximumLength(10);
        }
    }

    // Class for difficult validation
    public class UserComplexValidator : AbstractValidator<User>
    {
        public UserComplexValidator()
        {
            // Age
            RuleFor(x => x.Age).NotEmpty()
                               .NotNull()
                               .Must(x => x > 18)
                               .WithMessage("Age should be more 18. Your access denied!");

            // Phone Number
            RuleFor(x => x.PhoneNumber).NotNull()
                                       .NotEmpty()
                                       .Matches("/^(\\+\\d{1,3}[- ]?)?\\d{10}$/")
                                       .MaximumLength(15);

            // Address
            RuleFor(u => u.Address).Must(a => a?.ToLower()
                                                .Contains("street") == true)
                                   .WithMessage("Address must contain 'street'");

            // Check validation for each element for 'Membership'

            // Option 1
            RuleForEach(u => u.Memberships).ChildRules(m =>
            {
                m.RuleFor(x => x.Name).NotEmpty()
                                      .NotNull();
            });

            // Option 2
            RuleForEach(u => u.Memberships).SetValidator(new MembershipValidator());
        }
    }

    public class MembershipValidator : AbstractValidator<Membership>
    {
        public MembershipValidator()
        {
            // Name
            RuleFor(x => x.Name).NotEmpty()
                                .NotNull()
                                .Length(2, 22);
        }
    }
}
