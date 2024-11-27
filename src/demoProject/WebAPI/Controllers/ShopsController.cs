using Application.Features.Shops.Commands.Create;
using Application.Features.Shops.Commands.Delete;
using Application.Features.Shops.Commands.Update;
using Application.Features.Shops.Queries.GetById;
using Application.Features.Shops.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Shops.Queries.GetListByCompanyName;
using Application.Features.Shops.Queries.GetByUserId;
using Application.Features.Shops.Queries.GetByCompanyId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShopsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShopCommand createShopCommand)
    {
        CreatedShopResponse response = await Mediator.Send(createShopCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateShopCommand updateShopCommand)
    {
        UpdatedShopResponse response = await Mediator.Send(updateShopCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedShopResponse response = await Mediator.Send(new DeleteShopCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdShopResponse response = await Mediator.Send(new GetByIdShopQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListShopQuery getListShopQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShopListItemDto> response = await Mediator.Send(getListShopQuery);
        return Ok(response);
    }
    
   
   
   [HttpGet("GetListByCompanyNameShopQuery/{companyName}")]
   public async Task<IActionResult> GetByCompanyNameShopQuery([FromRoute] string companyName,[FromQuery] PageRequest pageRequest)
   {
        GetListByCompanyNameShopQuery getListByCompanyNameShopQuery = new() {CompanyName =  companyName, PageRequest= pageRequest };
       GetListResponse<GetListByCompanyNameShopListItemDto> response = await Mediator.Send(getListByCompanyNameShopQuery);
       return Ok(response);
   }
   
   [HttpGet("GetByUserIdShop")]
   public async Task<IActionResult> GetByUserIdShop([FromQuery] GetByUserIdShopQuery getByUserIdShopQuery)
   {
       GetByUserIdShopResponse response = await Mediator.Send(getByUserIdShopQuery);
       return Ok(response);
   }
   
   [HttpGet("GetByCompanyIdShop")]
   public async Task<IActionResult> GetByCompanyIdShop([FromQuery] GetByCompanyIdShopQuery getByCompanyIdShopQuery)
   {
       GetByCompanyIdShopResponse response = await Mediator.Send(getByCompanyIdShopQuery);
       return Ok(response);
   }
}
