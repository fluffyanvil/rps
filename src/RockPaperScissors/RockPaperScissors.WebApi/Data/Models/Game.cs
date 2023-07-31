using System.ComponentModel.DataAnnotations;

namespace RockPaperScissors.WebApi.Data.Models;

/// <summary>
/// Игра.
/// </summary>
public class Game
{
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Пользователь, создавший игру.
    /// </summary>
    public string Creator { get; set; }

    public virtual List<UserInGame> UsersInGame { get; set; }
}