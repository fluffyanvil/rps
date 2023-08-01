using RockPaperScissors.WebApi.Helpers;

namespace RockPaperScissors.WebApi.Dto;

public class RoundDto
{
    public int Number { get; set; }
    public string Winner => WinnerHelper.RoundWinner(Turn1, Turn2);
    public TurnDto Turn1 { get; set; }
    public TurnDto Turn2 { get; set; }
}