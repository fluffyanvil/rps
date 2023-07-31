namespace RockPaperScissors.WebApi.Data.Models;

/// <summary>
/// Игра.
/// </summary>
public class Game
{
    public Guid Id { get; set; }

    /// <summary>
    /// Пользователь, создавший игру.
    /// </summary>
    public string Creator { get; set; }
}