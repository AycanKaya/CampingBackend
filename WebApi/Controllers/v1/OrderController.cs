using System.Threading.Tasks;
using Application.Features.OrderFeatures.Commands;
using Application.Features.OrderFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

[ApiVersion("1.0")]
public class OrderController : BaseApiController
{
    /// <summary>
    /// Creates a New Product.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand command)
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
        return Ok(await Mediator.Send(new GetAllOrdersQuery()));
    }
    /// <summary>
    /// Gets Product Entity by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetOrderQuery { Id = id }));
    }
    /// <summary>
    /// Deletes Product Entity based on Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int İd)
    {
        return Ok(await Mediator.Send(new DeleteOrderCommand { Id = İd }));
    }
    /// <summary>
    /// Updates the Product Entity based on Id.   
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(int id, UpdateOrderCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }


}