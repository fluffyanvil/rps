namespace RockPaperScissors.WebApi.Mediatr.Commands.JoinUserToGameRequest;

public class JoinUserToGameResponse
{
    public JoinUserToGameResponse(string[] users)
    {
        Users = users;
    }

    public Guid GameId { get; set; }

    public string[] Users { get; set; }
}