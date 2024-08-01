using Application.Features.Barcodes.Commands.Create;
using Application.Features.Barcodes.Commands.Delete;
using Application.Features.Barcodes.Commands.Update;
using Application.Features.Barcodes.Queries.GetById;
using Application.Features.Barcodes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Barcodes.Queries.GetByBarcodeNumber;
using Application.Features.Barcodes.Queries.GetListByDynamicBarcode;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BarcodesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBarcodeCommand createBarcodeCommand)
    {
        CreatedBarcodeResponse response = await Mediator.Send(createBarcodeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBarcodeCommand updateBarcodeCommand)
    {
        UpdatedBarcodeResponse response = await Mediator.Send(updateBarcodeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBarcodeResponse response = await Mediator.Send(new DeleteBarcodeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBarcodeResponse response = await Mediator.Send(new GetByIdBarcodeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBarcodeQuery getListBarcodeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBarcodeListItemDto> response = await Mediator.Send(getListBarcodeQuery);
        return Ok(response);
    }
    
    [HttpGet("GetByBarcodeNumber")]
    public async Task<IActionResult> GetByBarcodeNumber([FromQuery] GetByBarcodeNumberQuery getByBarcodeNumberQuery)
    {
        GetByBarcodeNumberResponse response = await Mediator.Send(getByBarcodeNumberQuery);
        return Ok(response);
    }
    
    [HttpGet("GetListByDynamicBarcode")]
    public async Task<IActionResult> GetListByDynamicBarcode([FromQuery] GetListByDynamicBarcodeQuery getListByDynamicBarcodeQuery)
    {
        GetListByDynamicBarcodeResponse response = await Mediator.Send(getListByDynamicBarcodeQuery);
        return Ok(response);
    }
}
