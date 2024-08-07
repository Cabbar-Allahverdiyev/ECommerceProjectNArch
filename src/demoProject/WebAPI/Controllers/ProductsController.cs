using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Products.Queries.GetByName;
using Application.Features.Products.Queries.GetListByDynamicProduct;
using Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
    {
        CreatedProductResponse response = await Mediator.Send(createProductCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
    {
        UpdatedProductResponse response = await Mediator.Send(updateProductCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedProductResponse response = await Mediator.Send(new DeleteProductCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdProductResponse response = await Mediator.Send(new GetByIdProductQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductQuery getListProductQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductListItemDto> response = await Mediator.Send(getListProductQuery);
        return Ok(response);
    }
    
    [HttpGet("GetByNameProduct")]
    public async Task<IActionResult> GetByNameProduct([FromQuery] GetByNameProductQuery getByNameProductQuery)
    {
        GetByNameProductResponse response = await Mediator.Send(getByNameProductQuery);
        return Ok(response);
    }
    
    [HttpGet("GetListByDynamicProduct")]
    public async Task<IActionResult> GetListByDynamicProduct([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
    {
        GetListByDynamicProductQuery getListByDynamicProductQuery = new(pageRequest, dynamicQuery);
        var response = await Mediator.Send(getListByDynamicProductQuery);
        return Ok(response);
    }
}
