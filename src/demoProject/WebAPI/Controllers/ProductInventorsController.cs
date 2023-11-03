using Application.Features.ProductInventors.Commands.Create;
using Application.Features.ProductInventors.Commands.Delete;
using Application.Features.ProductInventors.Commands.Update;
using Application.Features.ProductInventors.Queries.GetById;
using Application.Features.ProductInventors.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductInventorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductInventorCommand createProductInventorCommand)
    {
        CreatedProductInventorResponse response = await Mediator.Send(createProductInventorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductInventorCommand updateProductInventorCommand)
    {
        UpdatedProductInventorResponse response = await Mediator.Send(updateProductInventorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedProductInventorResponse response = await Mediator.Send(new DeleteProductInventorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdProductInventorResponse response = await Mediator.Send(new GetByIdProductInventorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductInventorQuery getListProductInventorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductInventorListItemDto> response = await Mediator.Send(getListProductInventorQuery);
        return Ok(response);
    }
}