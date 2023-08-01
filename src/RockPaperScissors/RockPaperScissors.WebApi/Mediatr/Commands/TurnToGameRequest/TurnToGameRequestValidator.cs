using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data;

namespace RockPaperScissors.WebApi.Mediatr.Commands.TurnToGameRequest;

public class TurnToGameRequestValidator : AbstractValidator<TurnToGameRequest>
{
    private readonly GameDbInMemoryContext _context;

    public TurnToGameRequestValidator(GameDbInMemoryContext context)
    {
        _context = context;
        RuleFor(r => r.GameId)
            .Must(gameId =>
            {
                var exists = _context.Games.Any(g => g.Id.Equals(gameId));
                return exists;
            }).WithMessage(r => $"Игры с идентификатором {r.GameId} не существует.");

        RuleFor(r => r)
            .Must(r =>
            {
                var exists = _context.UsersInGames.Any(g =>
                    g.GameId.Equals(r.GameId) && g.UserName.ToLower().Equals(r.UserName.ToLower()));

                return exists;
            })
            .WithMessage(r => $"Пользователь {r.UserName} не существует в игре {r.GameId}.");

        RuleFor(r => r)
            .Must(r =>
            {
                var exists = _context.UsersInGames.Count(g =>
                    g.GameId.Equals(r.GameId));

                return exists == 2;
            })
            .WithMessage(r => $"В игре {r.GameId} недостаточно игроков.");

        RuleFor(req => req)
            .Must(req =>
            {
                var turns = _context.Turns.Where(r => r.GameId.Equals(r.GameId)).ToList();

                return turns.Count < 10;
            })
            .WithMessage(r => $"В игре {r.GameId} сыграны все раунды.");

        RuleFor(req => req)
            .Must(req =>
            {
                var game = _context
                    .Games
                    .Include(g => g.UsersInGame)
                    .Include(g => g.Turns)
                    .First(g => g.Id.Equals(req.GameId));

                var lastTurn = game.Turns.MaxBy(r => r.CreatedAt);

                if (lastTurn == null) return true;

                var otherPlayer = game.UsersInGame.First(u => !u.UserName.ToLower().Equals(req.UserName.ToLower()));

                return lastTurn.UserName.ToLower().Equals(otherPlayer.UserName.ToLower());
            })
            .WithMessage(r => $"Дождитесь хода другого игрока.");
    }
}