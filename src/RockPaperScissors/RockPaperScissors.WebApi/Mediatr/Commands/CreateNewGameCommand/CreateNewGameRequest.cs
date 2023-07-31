using MediatR;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Mediatr.Commands.CreateNewGameCommand;

public class CreateNewGameRequest : IRequest<GameDto>
{
    /// <summary>
    /// Пользователь, создающий игру
    /// </summary>
    public string? Creator { get; set; }
}