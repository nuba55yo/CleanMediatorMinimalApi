using FluentValidation;
using CleanMediatorMinimalApi.Application.Products.Commands;

namespace CleanMediatorMinimalApi.Application.Products.Validators;

public class CreateProductValidator : AbstractValidator<CreateProduct>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}