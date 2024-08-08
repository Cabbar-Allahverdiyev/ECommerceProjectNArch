using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Queries.GetById;
using Application.Features.Companies.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Companies.Queries.GetByName;
using Application.Features.Companies.Queries.GetListByDynamicCompany;
using Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCompanyCommand createCompanyCommand)
    {
        CreatedCompanyResponse response = await Mediator.Send(createCompanyCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand updateCompanyCommand)
    {
        UpdatedCompanyResponse response = await Mediator.Send(updateCompanyCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCompanyResponse response = await Mediator.Send(new DeleteCompanyCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCompanyResponse response = await Mediator.Send(new GetByIdCompanyQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCompanyQuery getListCompanyQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCompanyListItemDto> response = await Mediator.Send(getListCompanyQuery);
        return Ok(response);
    }
    
    [HttpGet("GetByNameCompany")]
    public async Task<IActionResult> GetByNameCompany([FromQuery] GetByNameCompanyQuery getByNameCompanyQuery)
    {
        GetByNameCompanyResponse response = await Mediator.Send(getByNameCompanyQuery);
        return Ok(response);
    }
    
    [HttpGet("GetListByDynamicCompany")]
    public async Task<IActionResult> GetListByDynamicCompany([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
    {
        GetListByDynamicCompanyQuery getListByDynamicCompanyQuery = new(pageRequest, dynamicQuery);
        var response = await Mediator.Send(getListByDynamicCompanyQuery);
        return Ok(response);
    }
}
