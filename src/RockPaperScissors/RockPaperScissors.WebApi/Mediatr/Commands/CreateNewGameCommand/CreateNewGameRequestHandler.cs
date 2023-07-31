using AutoMapper;
using MediatR;
using RockPaperScissors.WebApi.Data;
using RockPaperScissors.WebApi.Data.Models;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Mediatr.Commands.CreateNewGameCommand;

public class CreateNewGameRequestHandler : IRequestHandler<CreateNewGameRequest, GameDto>
{
    private readonly GameDbInMemoryContext _context;
    private readonly IMapper _mapper;

    public CreateNewGameRequestHandler(GameDbInMemoryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GameDto> Handle(CreateNewGameRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.Games.AddAsync(new Game { Creator = request.Creator, Id = Guid.NewGuid() }, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        var result = _mapper.Map<GameDto>(entity.Entity);
        return result;
    }
}