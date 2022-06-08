using System.Threading.Tasks;
using Application.Features.CardFeatures.Command;
using Application.Features.CardFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

[ApiVersion("1.0")]
public class CardController : BaseApiController
{
    /// <summary>
    /// Creates a New Product.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateCardCommand command)
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
        return Ok(await Mediator.Send(new GetAllCardsQuery()));
    }
    /// <summary>
    /// Gets Product Entity by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{cardNo}")]
    public async Task<IActionResult> GetByCardNo(string cardNo)
    {
        return Ok(await Mediator.Send(new GetCardQuery { CardNo = cardNo }));
    }
    /// <summary>
    /// Deletes Product Entity based on Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{cardNo}")]
    public async Task<IActionResult> Delete(string cardNo)
    {
        return Ok(await Mediator.Send(new DeleteCardCommand { CardNo = cardNo }));
    }
    /// <summary>
    /// Updates the Product Entity based on Id.   
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(string cardNo , UpdateCardCommand command)
    {
        if (cardNo != command.CardNo)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }


}