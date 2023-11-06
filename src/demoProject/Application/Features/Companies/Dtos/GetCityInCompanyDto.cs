using Core.Application.Dtos;


namespace Application.Features.Companies.Dtos;
public class GetCityInCompanyDto:IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
