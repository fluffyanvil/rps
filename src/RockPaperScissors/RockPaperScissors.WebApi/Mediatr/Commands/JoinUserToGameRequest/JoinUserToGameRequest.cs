using MediatR;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Mediatr.Commands.JoinUserToGameRequest;

public class JoinUserToGameRequest : IRequest<JoinUserToGameResponse>
{
    public Guid GameId { get; set; }

    public string UserName { get; set; } = string.Empty;
}