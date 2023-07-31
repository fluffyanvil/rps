namespace RockPaperScissors.WebApi.Data.Models;

public class UserInGame
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public Guid GameId { get; set; }

    public UserInGame()
    {
        Id = Guid.NewGuid();
    }
}