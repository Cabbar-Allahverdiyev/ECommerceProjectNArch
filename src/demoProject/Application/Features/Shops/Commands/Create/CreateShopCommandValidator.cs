using FluentValidation;

namespace Application.Features.Shops.Commands.Create;

public class CreateShopCommandValidator : AbstractValidator<CreateShopCommand>
{
    public CreateShopCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
    }
}