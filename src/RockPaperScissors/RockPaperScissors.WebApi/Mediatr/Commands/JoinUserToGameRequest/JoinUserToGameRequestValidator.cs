using FluentValidation;
using RockPaperScissors.WebApi.Data;

namespace RockPaperScissors.WebApi.Mediatr.Commands.JoinUserToGameRequest;

public class JoinUserToGameRequestValidator : AbstractValidator<JoinUserToGameRequest>
{
    private readonly GameDbInMemoryContext _context;

    public JoinUserToGameRequestValidator(GameDbInMemoryContext context)
    {
        _context = context;
        RuleFor(r => r.UserName)
            .NotEmpty()
            .WithMessage("Имя пользователя не должно быть пустым.");

        RuleFor(r => r.GameId).Must (gameId =>
        {
            var exists = _context.Games.Any(g => g.Id.Equals(gameId));
            return exists;
        }).WithMessage(r => $"Игры с идентификатором {r.GameId} не существует.");

        RuleFor(r => r)
            .Must(r =>
            {
                var exists = _context.UsersInGames.Count(g =>
                    g.GameId.Equals(r.GameId)) == 2;

                return !exists;
            })
            .WithMessage(r => $"В игре {r.GameId} достаточное количество игроков.");

        RuleFor(r => r)
            .Must(r =>
            {
                var exists = _context.UsersInGames.Any(g =>
                    g.GameId.Equals(r.GameId) && g.UserName.ToLower().Equals(r.UserName.ToLower()));

                return !exists;
            })
            .WithMessage(r => $"Пользователь {r.UserName} уже в игре {r.GameId}.");
    }
}