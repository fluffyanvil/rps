namespace RockPaperScissors.WebApi.Dto;

public class CollectionResultDto<T>
{
    public ICollection<T>? Result { get; set; }

    public int TotalCount { get; set; }
}