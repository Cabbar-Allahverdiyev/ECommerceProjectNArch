using Application.Features.Countries.Commands.Create;
using Application.Features.Countries.Commands.Delete;
using Application.Features.Countries.Commands.Update;
using Application.Features.Countries.Queries.GetById;
using Application.Features.Countries.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Countries.Queries.GetByName;
using Application.Features.Countries.Queries.GetListByDynamicCountry;
using Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCountryCommand createCountryCommand)
    {
        CreatedCountryResponse response = await Mediator.Send(createCountryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCountryCommand updateCountryCommand)
    {
        UpdatedCountryResponse response = await Mediator.Send(updateCountryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCountryResponse response = await Mediator.Send(new DeleteCountryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCountryResponse response = await Mediator.Send(new GetByIdCountryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCountryQuery getListCountryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCountryListItemDto> response = await Mediator.Send(getListCountryQuery);
        return Ok(response);
    }
    
    [HttpGet("GetByNameCountry")]
    public async Task<IActionResult> GetByNameCountry([FromQuery] GetByNameCountryQuery getByNameCountryQuery)
    {
        GetByNameCountryResponse response = await Mediator.Send(getByNameCountryQuery);
        return Ok(response);
    }
    
    [HttpGet("GetListByDynamicCountry")]
    public async Task<IActionResult> GetListByDynamicCountry([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
    {
        GetListByDynamicCountryQuery getListByDynamicCountryQuery = new(pageRequest, dynamicQuery);
        var response = await Mediator.Send(getListByDynamicCountryQuery);
        return Ok(response);
    }
}
