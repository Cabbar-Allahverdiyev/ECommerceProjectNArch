using FluentValidation;

namespace Application.Features.Shops.Commands.Update;

public class UpdateShopCommandValidator : AbstractValidator<UpdateShopCommand>
{
    public UpdateShopCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
    }
}