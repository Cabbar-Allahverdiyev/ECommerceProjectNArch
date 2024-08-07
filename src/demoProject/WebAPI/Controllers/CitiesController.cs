using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cities.Queries.GetByName;
using Application.Features.Cities.Queries.GetListByDynamicCity;
using Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCityCommand createCityCommand)
    {
        CreatedCityResponse response = await Mediator.Send(createCityCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCityCommand updateCityCommand)
    {
        UpdatedCityResponse response = await Mediator.Send(updateCityCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCityResponse response = await Mediator.Send(new DeleteCityCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCityResponse response = await Mediator.Send(new GetByIdCityQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCityQuery getListCityQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCityListItemDto> response = await Mediator.Send(getListCityQuery);
        return Ok(response);
    }
    
   
    
    [HttpGet("GetByNameCity")]
    public async Task<IActionResult> GetByNameCity([FromQuery] GetByNameCityQuery getByNameCityQuery)
    {
        GetByNameCityResponse response = await Mediator.Send(getByNameCityQuery);
        return Ok(response);
    }
   
   [HttpGet("GetListByDynamicCity")]
   public async Task<IActionResult> GetListByDynamicCity([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery )
   {
        GetListByDynamicCityQuery getListByDynamicCityQuery = new() { PageRequest=pageRequest,DynamicQuery=dynamicQuery};
       GetListResponse<GetListByDynamicCityItemDto> response = await Mediator.Send(getListByDynamicCityQuery);
       return Ok(response);
   }
}
