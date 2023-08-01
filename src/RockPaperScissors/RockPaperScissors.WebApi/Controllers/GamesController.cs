﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.WebApi.Data.Enums;
using RockPaperScissors.WebApi.Mediatr.Commands.CreateNewGameCommand;
using RockPaperScissors.WebApi.Mediatr.Commands.JoinUserToGameRequest;
using RockPaperScissors.WebApi.Mediatr.Commands.TurnToGameRequest;
using RockPaperScissors.WebApi.Mediatr.Queries.GetStatisticsRequest;

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
    public async Task<IActionResult> JoinAsync(Guid gameId, string userName, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new JoinUserToGameRequest { GameId = gameId, UserName = userName }, cancellationToken);
        return Ok(result);
    }

    [HttpPost("create/{userName}")]
    public async Task<IActionResult> PostAsync(string userName, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateNewGameRequest{ Creator = userName}, cancellationToken);
        return Ok(result);
    }

    [HttpPost("{gameId:guid}/user/{userName}/{option}")]
    public async Task<IActionResult> TurnAsync(Guid gameId, Option option, string userName, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new TurnToGameRequest { GameId = gameId, Option = option, UserName = userName }, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{gameId:guid}/stat")]
    public async Task<IActionResult> StatAsync(Guid gameId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetStatisticsRequest { GameId = gameId }, cancellationToken);
        return Ok(result);
    }
}