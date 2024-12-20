using Application.Features.Sellers.Commands.Create;
using Application.Features.Sellers.Commands.Delete;
using Application.Features.Sellers.Commands.Update;
using Application.Features.Sellers.Queries.GetById;
using Application.Features.Sellers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Sellers.Queries.GetByShopIdSeller;
using Application.Features.Sellers.Queries.GetByUserIdSeller;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SellersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSellerCommand createSellerCommand)
    {
        CreatedSellerResponse response = await Mediator.Send(createSellerCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSellerCommand updateSellerCommand)
    {
        UpdatedSellerResponse response = await Mediator.Send(updateSellerCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSellerResponse response = await Mediator.Send(new DeleteSellerCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSellerResponse response = await Mediator.Send(new GetByIdSellerQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSellerQuery getListSellerQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSellerListItemDto> response = await Mediator.Send(getListSellerQuery);
        return Ok(response);
    }
    
    [HttpGet("GetByShopIdSeller")]
    public async Task<IActionResult> GetByShopIdSeller([FromQuery] GetByShopIdSellerQuery getByShopIdSellerQuery)
    {
        GetByShopIdSellerResponse response = await Mediator.Send(getByShopIdSellerQuery);
        return Ok(response);
    }
    
    [HttpGet("GetByUserIdSeller")]
    public async Task<IActionResult> GetByUserIdSeller([FromQuery] GetByUserIdSellerQuery getByUserIdSellerQuery)
    {
        GetByUserIdSellerResponse response = await Mediator.Send(getByUserIdSellerQuery);
        return Ok(response);
    }
}
