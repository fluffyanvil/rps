using MediatR;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data;

namespace RockPaperScissors.WebApi.Mediatr.Commands.PlayWithCpuRequest;

public class PlayWithCpuRequestHandler : IRequestHandler<PlayWithCpuRequest>
{
    private readonly GameDbInMemoryContext _context;
    private readonly IMediator _mediator;

    public PlayWithCpuRequestHandler(GameDbInMemoryContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    public async Task Handle(PlayWithCpuRequest request, CancellationToken cancellationToken)
    {
        var game = await _context.Games.FirstAsync(g => g.Id.Equals(request.GameId), cancellationToken);

        var joinUserToGameResponse = await _mediator.Send(
            new JoinUserToGameRequest.JoinUserToGameRequest { GameId = request.GameId, UserName = "CPU" },
            cancellationToken);

        game.PlayWithCpu = true;
        game.CpuId = joinUserToGameResponse.UserId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}