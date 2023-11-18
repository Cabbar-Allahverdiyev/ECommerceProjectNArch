using FluentValidation;

namespace Application.Features.ProductInventors.Queries.GetById;
public class GetByIdProductInventorQueryValidator:AbstractValidator<GetByIdProductInventorQuery>
{
    public GetByIdProductInventorQueryValidator()
    {
        RuleFor(i=>i.Id).NotEmpty();
    }
}
