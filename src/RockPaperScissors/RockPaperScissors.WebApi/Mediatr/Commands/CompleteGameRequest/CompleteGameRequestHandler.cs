using MediatR;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data;

namespace RockPaperScissors.WebApi.Mediatr.Commands.CompleteGameRequest;

public class CompleteGameRequestHandler : IRequestHandler<CompleteGameRequest>
{
    private readonly GameDbInMemoryContext _context;

    public CompleteGameRequestHandler(GameDbInMemoryContext context)
    {
        _context = context;
    }
    public async Task Handle(CompleteGameRequest request, CancellationToken cancellationToken)
    {
        var game = await _context.Games.FirstAsync(g => g.Id.Equals(request.GameId), cancellationToken);

        game.IsCompleted = true;

        await _context.SaveChangesAsync(cancellationToken);
    }
}