using FluentValidation;

namespace Application.Features.Products.Queries.GetById;
public class GetByIdProductQueryValidator:AbstractValidator<GetByIdProductResponse>
{
    public GetByIdProductQueryValidator()
    {
        RuleFor(p=>p.Id).NotEmpty();
    }
}
