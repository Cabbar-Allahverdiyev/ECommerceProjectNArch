using Application.Features.ProductBrands.Commands.Create;
using Application.Features.ProductBrands.Commands.Delete;
using Application.Features.ProductBrands.Commands.Update;
using Application.Features.ProductBrands.Queries.GetById;
using Application.Features.ProductBrands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.ProductBrands.Queries.GetByName;
using Application.Features.ProductBrands.Queries.GetListByDynamicProductBrand;
using Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductBrandsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductBrandCommand createProductBrandCommand)
    {
        CreatedProductBrandResponse response = await Mediator.Send(createProductBrandCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductBrandCommand updateProductBrandCommand)
    {
        UpdatedProductBrandResponse response = await Mediator.Send(updateProductBrandCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedProductBrandResponse response = await Mediator.Send(new DeleteProductBrandCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdProductBrandResponse response = await Mediator.Send(new GetByIdProductBrandQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductBrandQuery getListProductBrandQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductBrandListItemDto> response = await Mediator.Send(getListProductBrandQuery);
        return Ok(response);
    }
    
    [HttpGet("GetByName")]
    public async Task<IActionResult> GetByName([FromQuery] GetByNameProductBrandQuery getByNameQuery)
    {
        GetByNameProductBrandResponse response = await Mediator.Send(getByNameQuery);
        return Ok(response);
    }
    
    [HttpGet("GetListByDynamicProductBrand")]
    public async Task<IActionResult> GetListByDynamicProductBrand([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
    {
        GetListByDynamicProductBrandQuery getListByDynamicProductBrandQuery = new(pageRequest, dynamicQuery);
        var response = await Mediator.Send(getListByDynamicProductBrandQuery);
        return Ok(response);
    }
}
