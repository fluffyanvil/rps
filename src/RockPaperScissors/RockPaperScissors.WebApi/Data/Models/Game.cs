using System.ComponentModel.DataAnnotations;

namespace RockPaperScissors.WebApi.Data.Models;

/// <summary>
/// Игра.
/// </summary>
public class Game : BaseEntity
{
    /// <summary>
    /// Пользователь, создавший игру.
    /// </summary>
    public string Creator { get; set; }

    public virtual List<UserInGame> UsersInGame { get; set; }

    public virtual List<Turn> Turns { get; set; }
}