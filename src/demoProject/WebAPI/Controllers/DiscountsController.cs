using Application.Features.Discounts.Commands.Create;
using Application.Features.Discounts.Commands.Delete;
using Application.Features.Discounts.Commands.Update;
using Application.Features.Discounts.Queries.GetById;
using Application.Features.Discounts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDiscountCommand createDiscountCommand)
    {
        CreatedDiscountResponse response = await Mediator.Send(createDiscountCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDiscountCommand updateDiscountCommand)
    {
        UpdatedDiscountResponse response = await Mediator.Send(updateDiscountCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedDiscountResponse response = await Mediator.Send(new DeleteDiscountCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdDiscountResponse response = await Mediator.Send(new GetByIdDiscountQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDiscountQuery getListDiscountQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListDiscountListItemDto> response = await Mediator.Send(getListDiscountQuery);
        return Ok(response);
    }
}