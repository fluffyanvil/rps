using MediatR;

namespace RockPaperScissors.WebApi.Mediatr.Commands.CompleteGameRequest;

public class CompleteGameRequest : IRequest
{
    public Guid GameId { get; set; }
}