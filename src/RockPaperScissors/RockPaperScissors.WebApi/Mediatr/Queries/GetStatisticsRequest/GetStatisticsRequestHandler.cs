using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Mediatr.Queries.GetStatisticsRequest;

public class GetStatisticsRequestHandler : IRequestHandler<GetStatisticsRequest, GetStatisticsResponse>
{
    private readonly GameDbInMemoryContext _context;
    private readonly IMapper _mapper;

    public GetStatisticsRequestHandler(GameDbInMemoryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetStatisticsResponse> Handle(GetStatisticsRequest request, CancellationToken cancellationToken)
    {
        var game = await _context.Games.Include(g => g.Turns)
            .SingleAsync(g => g.Id.Equals(request.GameId), cancellationToken);

        var turns = game.Turns.OrderBy(t => t.CreatedAt).ToList();

        var rounds = new List<RoundDto>();
        
        for (int i = 0; i < rounds.Count - (rounds.Count % 2); i++)
        {
            var roundTurns = _mapper.Map<List<TurnDto>>(turns.Skip(i * 2).Take(2).ToList());
            var round = new RoundDto{Number = i+1, Turn1 = roundTurns[0], Turn2 = roundTurns[1] };
            rounds.Add(round);
        }


        var result = new GetStatisticsResponse { GameId = request.GameId, Rounds = rounds };
        return result;
    }
}