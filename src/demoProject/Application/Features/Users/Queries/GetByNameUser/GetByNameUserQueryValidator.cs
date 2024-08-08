using FluentValidation;

namespace Application.Features.Users.Queries.GetByNameUser;

public class GetByNameUserQueryValidator : AbstractValidator<GetByNameUserQuery>
{
    public GetByNameUserQueryValidator() { }
}