using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data;
using RockPaperScissors.WebApi.Data.Models;
using RockPaperScissors.WebApi.Dto;

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
        var entity = await _context.UsersInGames.AddAsync(new UserInGame { GameId = request.GameId, UserName = request.UserName }, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var result = _mapper.Map<JoinUserToGameResponse>(entity.Entity);

        return result;
    }
}