using MediatR;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Mediatr.Commands.CreateNewGameCommand;

public class CreateNewGameRequest : IRequest<CreateNewGameResponse>
{
    /// <summary>
    /// Пользователь, создающий игру
    /// </summary>
    public string? Name { get; set; }
}