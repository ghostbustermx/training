using FluentValidation;
using SS.GiftShop.Core;

namespace SS.GiftShop.Application.Examples.Commands
{
    public sealed class AddExampleModelValidator : AbstractValidator<AddExampleModel>
    {
        public AddExampleModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(AppConstants.StandardValueLength);

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(AppConstants.EmailLength);
        }
    }
}
