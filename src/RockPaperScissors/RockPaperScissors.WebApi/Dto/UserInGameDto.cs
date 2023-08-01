namespace RockPaperScissors.WebApi.Dto;

public class UserInGameDto
{
    public Guid GameId { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
}