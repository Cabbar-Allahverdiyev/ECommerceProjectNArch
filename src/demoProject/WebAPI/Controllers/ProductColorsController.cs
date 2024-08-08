using Application.Features.ProductColors.Commands.Create;
using Application.Features.ProductColors.Commands.Delete;
using Application.Features.ProductColors.Commands.Update;
using Application.Features.ProductColors.Queries.GetById;
using Application.Features.ProductColors.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.ProductColors.Queries.GetListByDynamicProductColor;
using Application.Features.ProductColors.Queries.GetByName;
using Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductColorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductColorCommand createProductColorCommand)
    {
        CreatedProductColorResponse response = await Mediator.Send(createProductColorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductColorCommand updateProductColorCommand)
    {
        UpdatedProductColorResponse response = await Mediator.Send(updateProductColorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedProductColorResponse response = await Mediator.Send(new DeleteProductColorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdProductColorResponse response = await Mediator.Send(new GetByIdProductColorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductColorQuery getListProductColorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductColorListItemDto> response = await Mediator.Send(getListProductColorQuery);
        return Ok(response);
    }

    [HttpGet("GetListByDynamicProductColor")]
    public async Task<IActionResult> GetListByDynamicProductColor([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
    {
        GetListByDynamicProductColorQuery getListByDynamicProductColorQuery = new(pageRequest, dynamicQuery);
        var response = await Mediator.Send(getListByDynamicProductColorQuery);
        return Ok(response);
    }

    [HttpGet("GetByNameProductColor")]
    public async Task<IActionResult> GetByNameProductColor([FromQuery] GetByNameProductColorQuery getByNameProductColorQuery)
    {
        GetByNameProductColorResponse response = await Mediator.Send(getByNameProductColorQuery);
        return Ok(response);
    }
}
