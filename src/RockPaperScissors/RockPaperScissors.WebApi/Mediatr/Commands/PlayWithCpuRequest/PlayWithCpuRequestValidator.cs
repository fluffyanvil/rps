using FluentValidation;
using RockPaperScissors.WebApi.Data;

namespace RockPaperScissors.WebApi.Mediatr.Commands.PlayWithCpuRequest;

public class PlayWithCpuRequestValidator : AbstractValidator<PlayWithCpuRequest>
{
    private readonly GameDbInMemoryContext _context;

    public PlayWithCpuRequestValidator(GameDbInMemoryContext context)
    {
        _context = context;
        RuleFor(r => r.GameId).Must(gameId =>
        {
            var exists = _context.Games.Any(g => g.Id.Equals(gameId));
            return exists;
        }).WithMessage(r => $"Игры с идентификатором {r.GameId} не существует.");

        RuleFor(r => r.GameId).Must(gameId =>
        {
            var game = _context.Games.First(g => g.Id.Equals(gameId));
            return !game.PlayWithCpu;
        }).WithMessage(r => $"Компьютер уже подключился.");
    }
}