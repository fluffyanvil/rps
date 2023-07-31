namespace RockPaperScissors.WebApi.Dto;

public class GameDto
{
    public Guid Id { get; set; }

    public string Creator { get; set; }

    public string[] Users { get; set; }
}