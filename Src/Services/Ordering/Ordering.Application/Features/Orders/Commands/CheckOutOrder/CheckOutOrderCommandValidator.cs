using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CheckOutOrder
{
    public class CheckOutOrderCommandValidator : AbstractValidator<CheckOutOrderCommand>
    {
        public CheckOutOrderCommandValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("{UsreName} is required").NotNull().MaximumLength(50)
                .WithMessage("{UserName} must not exceed 50 characters");

            RuleFor(p => p.EmailAddress).NotEmpty().WithMessage("{EmailAddress} is required");
            RuleFor(p => p.TotalPrice).NotEmpty().WithMessage("{EmailAddress} is required")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero");
        }
    }
}
