using System.ComponentModel.DataAnnotations;

namespace RockPaperScissors.WebApi.Data.Models;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTimeOffset.Now;
    }
}