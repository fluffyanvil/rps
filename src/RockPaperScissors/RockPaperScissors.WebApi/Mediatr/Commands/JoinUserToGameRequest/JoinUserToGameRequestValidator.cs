using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
    }
}