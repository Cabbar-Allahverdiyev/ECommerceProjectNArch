using FluentValidation;

namespace Application.Features.ProductColors.Queries.GetByName;

public class GetByNameProductColorQueryValidator : AbstractValidator<GetByNameProductColorQuery>
{
    public GetByNameProductColorQueryValidator()
    {
        RuleFor(r=>r.Name).NotEmpty();
        RuleFor(r=>r.Name).NotNull();

    }
}