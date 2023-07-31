using MediatR;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.WebApi.Mediatr.Commands.CreateNewGameCommand;
using RockPaperScissors.WebApi.Mediatr.Commands.JoinUserToGameRequest;

namespace RockPaperScissors.WebApi.Controllers;

/// <summary>
/// Контроллер игр.
/// </summary>
[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    private readonly IMediator _mediator;

    public GamesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut("{gameId:guid}/join/{userName}")]
    public async Task<IActionResult> JoinAsync(Guid gameId, string userName)
    {
        var result = await _mediator.Send(new JoinUserToGameRequest { GameId = gameId, UserName = userName });
        return Ok(result);
    }

    [HttpPost("create/{userName}")]
    public async Task<IActionResult> PostAsync(string userName, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateNewGameRequest{ Creator = userName}, cancellationToken);
        return Ok(result);
    } 
}