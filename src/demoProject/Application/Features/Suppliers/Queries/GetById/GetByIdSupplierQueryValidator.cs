using FluentValidation;

namespace Application.Features.Suppliers.Queries.GetById;
public class GetByIdSupplierQueryValidator:AbstractValidator<GetByIdSupplierQuery>
{
    public GetByIdSupplierQueryValidator()
    {
        RuleFor(s=>s.Id).NotEmpty();
    }
}
