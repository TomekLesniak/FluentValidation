using FluentValidation;
using OrdersLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentValidationWpf.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(order => order.Price)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0.0M).WithMessage("{PropertyName} can not be less than 0")
                .LessThan(1000).WithMessage("{PropertyName} can not be greater than 1000");

            RuleFor(order => order.Date)
                .Must(BeInThePast).WithMessage("{PropertyName} can`t be in the future!");

            RuleFor(order => order.Description)
                .MinimumLength(10).WithMessage("{PropertyName} must be at least 10 characters")
                .MaximumLength(1000).WithMessage("{PropertyName} is too long!");
        }

        private bool BeInThePast(DateTime date)
        {
            return date.CompareTo(DateTime.Now) <= 0;
        }
    }
}
