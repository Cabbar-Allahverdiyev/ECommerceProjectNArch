using FluentValidation;

namespace Application.Features.ProductColors.Queries.GetById;
public class GetByIdProductColorQueryValidator : AbstractValidator<GetByIdProductColorQuery>
{
    public GetByIdProductColorQueryValidator()
    {
        RuleFor(r => r.Id).NotNull();
        RuleFor(r => r.Id).NotEmpty();
    }
}