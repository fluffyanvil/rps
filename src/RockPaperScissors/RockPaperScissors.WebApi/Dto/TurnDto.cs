using RockPaperScissors.WebApi.Data.Enums;

namespace RockPaperScissors.WebApi.Dto;

public class TurnDto
{
    public Guid GameId { get; set; }
    public Guid UserId { get; set; }
    public Option Option { get; set; }
    public string OptionName => Option.ToString();
}