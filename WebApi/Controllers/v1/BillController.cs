using System.Threading.Tasks;
using Application.Features.BillFeatures.Commands;
using Application.Features.BillFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

[ApiVersion("1.0")]
public class BillController : BaseApiController
{
    /// <summary>
    /// Creates a New Product.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateBillCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    /// <summary>
    /// Gets all Products.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllBillQuery()));
    }
    /// <summary>
    /// Gets Product Entity by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{cardNo}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetBillQuery { Id = id }));
    }
    /// <summary>
    /// Deletes Product Entity based on Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteBillCommand { Id = id }));
    }
    /// <summary>
    /// Updates the Product Entity based on Id.   
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(int id, UpdateBillCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }


}