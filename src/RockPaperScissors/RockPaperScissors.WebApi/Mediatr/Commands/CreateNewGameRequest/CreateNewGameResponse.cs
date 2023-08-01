namespace RockPaperScissors.WebApi.Mediatr.Commands.CreateNewGameCommand;

public class CreateNewGameResponse
{
    public Guid GameId { get; set; }

    public Guid UserId { get; set; }
}