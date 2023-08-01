using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data;
using RockPaperScissors.WebApi.Data.Enums;
using RockPaperScissors.WebApi.Data.Models;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Mediatr.Commands.TurnToGameRequest;

public class TurnToGameRequestHandler : IRequestHandler<TurnToGameRequest, TurnDto>
{
    private readonly GameDbInMemoryContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public TurnToGameRequestHandler(GameDbInMemoryContext context, IMapper mapper, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }
    public async Task<TurnDto> Handle(TurnToGameRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.Turns.AddAsync(
            new Turn { GameId = request.GameId, Option = Enum.Parse<Option>(request.Option), UserId = request.UserId },
            cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        var game = await _context.Games.Include(g => g.Turns).FirstAsync(g => g.Id.Equals(request.GameId), cancellationToken);
        
        if (game.Turns.Count == 10)
        {
            await _mediator.Send(new CompleteGameRequest.CompleteGameRequest { GameId = request.GameId }, cancellationToken);
        }

        var result = _mapper.Map<TurnDto>(entity.Entity);
        return result;
    }
}