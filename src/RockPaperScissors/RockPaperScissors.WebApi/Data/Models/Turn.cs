using RockPaperScissors.WebApi.Data.Enums;

namespace RockPaperScissors.WebApi.Data.Models;

public class Turn : BaseEntity
{
    public Guid GameId { get; set; }
    public Option Option { get; set; }
    public Guid UserId { get; set; }
}