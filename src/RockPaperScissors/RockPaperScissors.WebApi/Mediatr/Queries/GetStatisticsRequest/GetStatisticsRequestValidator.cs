using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data;
using RockPaperScissors.WebApi.Data.Models;

namespace RockPaperScissors.WebApi.Mediatr.Queries.GetStatisticsRequest;

public class GetStatisticsRequestValidator : AbstractValidator<GetStatisticsRequest>
{
    private readonly GameDbInMemoryContext _context;

    public GetStatisticsRequestValidator(GameDbInMemoryContext context)
    {
        _context = context;
        RuleFor(r => r.GameId)
            .Must(gameId =>
            {
                var exists = _context.Games.Any(g => g.Id.Equals(gameId));
                return exists;
            }).WithMessage(r => $"Игры с идентификатором {r.GameId} не существует.");

        RuleFor(req => req)
            .Must(req =>
            {
                var game = _context.Games.First(g => g.Id.Equals(req.GameId));
                return game.IsCompleted;
            })
            .WithMessage(r => $"Игры {r.GameId} еще не завершилась.");
    }
}