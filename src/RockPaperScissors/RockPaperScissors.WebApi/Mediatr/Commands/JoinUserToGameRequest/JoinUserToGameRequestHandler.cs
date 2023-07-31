using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data;

namespace RockPaperScissors.WebApi.Mediatr.Commands.JoinUserToGameRequest;

public class JoinUserToGameRequestHandler : IRequestHandler<JoinUserToGameRequest, JoinUserToGameResponse>
{
    private readonly GameDbInMemoryContext _context;
    private readonly IMapper _mapper;

    public JoinUserToGameRequestHandler(GameDbInMemoryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<JoinUserToGameResponse> Handle(JoinUserToGameRequest request, CancellationToken cancellationToken)
    {
        var game = await _context.Games.FirstOrDefaultAsync(g => g.Id.Equals(request.GameId), cancellationToken);

        return new JoinUserToGameResponse(new[] { "" });
    }
}