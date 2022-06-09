using System.Threading.Tasks;
using Application.Features.LinkFeatures.LinkQueries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

[ApiVersion("1.0")]
public class LinkController : BaseApiController
{
    


    
    [HttpGet("{CampsiteVacationSpotID}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetLinksByCampsite { CampsiteVacationSpotID = id }));
    }
   

    
}