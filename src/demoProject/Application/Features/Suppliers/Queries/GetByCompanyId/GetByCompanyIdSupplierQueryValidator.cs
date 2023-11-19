using FluentValidation;

namespace Application.Features.Suppliers.Queries.GetByCompanyId;

public class GetByCompanyIdSupplierQueryValidator : AbstractValidator<GetByCompanyIdSupplierQuery>
{
    public GetByCompanyIdSupplierQueryValidator() { RuleFor(s => s.CompanyId).NotEmpty(); }
}