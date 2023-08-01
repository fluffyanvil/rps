using FluentValidation;
using RockPaperScissors.WebApi.Data;

namespace RockPaperScissors.WebApi.Mediatr.Commands.CompleteGameRequest;

public class CompleteGameRequestValidator : AbstractValidator<CompleteGameRequest>
{
    private readonly GameDbInMemoryContext _context;

    public CompleteGameRequestValidator(GameDbInMemoryContext context)
    {
        _context = context;
        RuleFor(r => r.GameId).Must(gameId =>
        {
            var exists = _context.Games.Any(g => g.Id.Equals(gameId));
            return exists;
        }).WithMessage(r => $"Игры с идентификатором {r.GameId} не существует.");
    }
}