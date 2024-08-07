using Application.Features.Suppliers.Commands.Create;
using Application.Features.Suppliers.Commands.Delete;
using Application.Features.Suppliers.Commands.Update;
using Application.Features.Suppliers.Queries.GetById;
using Application.Features.Suppliers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Suppliers.Queries.GetByUserId;
using Application.Features.Suppliers.Queries.GetByCompanyId;
using Application.Features.Suppliers.Queries.GetListByDynamicSupplier;
using Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuppliersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSupplierCommand createSupplierCommand)
    {
        CreatedSupplierResponse response = await Mediator.Send(createSupplierCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSupplierCommand updateSupplierCommand)
    {
        UpdatedSupplierResponse response = await Mediator.Send(updateSupplierCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSupplierResponse response = await Mediator.Send(new DeleteSupplierCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSupplierResponse response = await Mediator.Send(new GetByIdSupplierQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSupplierQuery getListSupplierQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSupplierListItemDto> response = await Mediator.Send(getListSupplierQuery);
        return Ok(response);
    }
    
    [HttpGet("GetByUserIdSupplier")]
    public async Task<IActionResult> GetByUserIdSupplier([FromQuery] GetByUserIdSupplierQuery getByUserIdSupplierQuery)
    {
        GetByUserIdSupplierResponse response = await Mediator.Send(getByUserIdSupplierQuery);
        return Ok(response);
    }
    
    [HttpGet("GetByCompanyIdSuppier")]
    public async Task<IActionResult> GetByCompanyIdSuppier([FromQuery] GetByCompanyIdSupplierQuery getByCompanyIdSuppierQuery)
    {
        GetByCompanyIdSupplierResponse response = await Mediator.Send(getByCompanyIdSuppierQuery);
        return Ok(response);
    }
    
    [HttpGet("GetListByDynamicSupplier")]
    public async Task<IActionResult> GetListByDynamicSupplier([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
    {
        GetListByDynamicSupplierQuery getListByDynamicSupplierQuery = new(pageRequest, dynamicQuery);
        GetListResponse<GetListByDynamicSupplierItemDto> response = await Mediator.Send(getListByDynamicSupplierQuery);
        return Ok(response);
    }
}
