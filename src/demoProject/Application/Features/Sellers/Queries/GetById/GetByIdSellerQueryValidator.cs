using FluentValidation;

namespace Application.Features.Sellers.Queries.GetById;
public class GetByIdSellerQueryValidator:AbstractValidator<GetByIdSellerQuery>
{
    public GetByIdSellerQueryValidator()
    {
        RuleFor(s => s.Id).NotEmpty();
    }
}
