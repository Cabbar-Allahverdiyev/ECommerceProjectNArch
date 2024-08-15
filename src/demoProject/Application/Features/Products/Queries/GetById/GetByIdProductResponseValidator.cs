using FluentValidation;

namespace Application.Features.Products.Queries.GetById;
public class GetByIdProductResponseValidator:AbstractValidator<GetByIdProductResponse>
{
    public GetByIdProductResponseValidator()
    {
        RuleFor(p=>p.Id).NotEmpty();
    }
}
