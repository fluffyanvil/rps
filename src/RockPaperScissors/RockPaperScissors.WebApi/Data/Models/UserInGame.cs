namespace RockPaperScissors.WebApi.Data.Models;

public class UserInGame : BaseEntity
{
    public string UserName { get; set; }
    public Guid GameId { get; set; }
    public Guid UserId { get; set; }

    public UserInGame()
    {
        UserId = Guid.NewGuid();
    }
}