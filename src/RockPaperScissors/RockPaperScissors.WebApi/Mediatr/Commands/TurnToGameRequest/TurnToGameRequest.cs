using MediatR;
using RockPaperScissors.WebApi.Data.Enums;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Mediatr.Commands.TurnToGameRequest;

public class TurnToGameRequest : IRequest<TurnDto>
{
    public Guid GameId { get; set; }

    public Guid UserId { get; set; }

    public string Option { get; set; }
}