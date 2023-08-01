using RockPaperScissors.WebApi.Data.Enums;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Helpers;

public static class WinnerHelper
{
    public static string RoundWinner(TurnDto turn1, TurnDto turn2)
    {
        return Beat(turn1.Option, turn2.Option) == Result.Win ? turn1.UserName : Beat(turn1.Option, turn2.Option) == Result.Draw ? "None" : turn2.UserName;
    }

    private static Result Beat(Option option1, Option option2)
    {
        switch (option1)
        {
            case Option.Rock:
                return option2 == Option.Paper ? Result.Lose : option2 == Option.Rock ? Result.Draw : Result.Win;
            case Option.Paper:
                return option2 == Option.Scissors ? Result.Lose : option2 == Option.Paper ? Result.Draw : Result.Win;
            case Option.Scissors:
                return option2 == Option.Rock ? Result.Lose : option2 == Option.Scissors ? Result.Draw : Result.Win;
            default:
                return Result.Draw;
        }
    }

    public static string GameWinner(List<RoundDto> rounds)
    {
        var result = rounds.GroupBy(x => x.Winner)
            .MaxBy(g => g.Count())
            ?.Key;
        return result;
    }
}