using MediatR;

namespace RockPaperScissors.WebApi.Mediatr.Commands.PlayWithCpuRequest;

public class PlayWithCpuRequest : IRequest
{
    public Guid GameId { get; set; }
}