using RockPaperScissors.WebApi.Data.Enums;

namespace RockPaperScissors.WebApi.Dto;

public class TurnDto
{
    public Guid GameId { get; set; }

    public string UserName { get; set; }

    public Option Option { get; set; }
}