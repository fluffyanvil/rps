using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data;
using RockPaperScissors.WebApi.Data.Models;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Mediatr.Commands.TurnToGameRequest;

public class TurnToGameRequestHandler : IRequestHandler<TurnToGameRequest, TurnDto>
{
    private readonly GameDbInMemoryContext _context;
    private readonly IMapper _mapper;

    public TurnToGameRequestHandler(GameDbInMemoryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<TurnDto> Handle(TurnToGameRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.Turns.AddAsync(
            new Turn { GameId = request.GameId, Option = request.Option, UserId = request.UserId },
            cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        var result = _mapper.Map<TurnDto>(entity.Entity);
        return result;
    }
}