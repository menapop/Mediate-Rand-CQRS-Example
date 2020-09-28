
using FluentValidation;
using MediateRCQRSExample.Commands;

namespace ExampleMediatR.Validation
{
    public class CreateCustomerOrderCommandValidator : AbstractValidator<CreateCustomerOrderCommand>
    {
        public CreateCustomerOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId Is Empty");
            
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId Is Empty");
        }
    }
}