using MediatR;

namespace RockPaperScissors.WebApi.Mediatr.Queries.GetStatisticsRequest;

public class GetStatisticsRequest : IRequest<GetStatisticsResponse>
{
    public Guid GameId { get; set; }
}