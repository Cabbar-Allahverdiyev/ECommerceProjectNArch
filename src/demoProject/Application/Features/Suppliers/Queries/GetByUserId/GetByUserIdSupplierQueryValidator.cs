using FluentValidation;

namespace Application.Features.Suppliers.Queries.GetByUserId;

public class GetByUserIdSupplierQueryValidator : AbstractValidator<GetByUserIdSupplierQuery>
{
    public GetByUserIdSupplierQueryValidator() { RuleFor(s=>s.UserId); }
}