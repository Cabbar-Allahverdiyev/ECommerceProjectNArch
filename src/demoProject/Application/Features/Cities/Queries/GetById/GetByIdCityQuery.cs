using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Cities.Constants.CitiesOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cities.Queries.GetById;

public class GetByIdCityQuery : IRequest<GetByIdCityResponse>//, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCityQueryHandler : IRequestHandler<GetByIdCityQuery, GetByIdCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly CityBusinessRules _cityBusinessRules;

        public GetByIdCityQueryHandler(IMapper mapper, ICityRepository cityRepository, CityBusinessRules cityBusinessRules)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _cityBusinessRules = cityBusinessRules;
        }

        public async Task<GetByIdCityResponse> Handle(GetByIdCityQuery request, CancellationToken cancellationToken)
        {
            City? city = await _cityRepository.GetAsync(predicate: c => c.Id == request.Id,
                cancellationToken: cancellationToken,
                include:c=>c.Include(c=>c.Companies).Include(c=>c.Country)
                //enableTracking:false
                );
            await _cityBusinessRules.CityShouldExistWhenSelected(city);
            GetByIdCityResponse response = _mapper.Map<GetByIdCityResponse>(city);
            return response;
        }
    }
}