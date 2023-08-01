using RockPaperScissors.WebApi.Dto;
using RockPaperScissors.WebApi.Helpers;

namespace RockPaperScissors.WebApi.Mediatr.Queries.GetStatisticsRequest;

public class GetStatisticsResponse
{
    public Guid GameId { get; set; }

    public string Winner => WinnerHelper.GameWinner(Rounds);

    public List<RoundDto> Rounds { get; set; }
}