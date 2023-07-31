using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data;
using RockPaperScissors.WebApi.Data.Models;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Mediatr.Commands.CreateNewGameCommand;

public class CreateNewGameRequestHandler : IRequestHandler<CreateNewGameRequest, GameDto>
{
    private readonly GameDbInMemoryContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CreateNewGameRequestHandler(GameDbInMemoryContext context, IMapper mapper, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }
    public async Task<GameDto> Handle(CreateNewGameRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.Games.AddAsync(new Game { Creator = request.Creator, Id = Guid.NewGuid() }, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);

        var result = await _mediator.Send(new JoinUserToGameRequest.JoinUserToGameRequest
            { GameId = entity.Entity.Id, UserName = entity.Entity.Creator }, cancellationToken);

        return result;
    }
}