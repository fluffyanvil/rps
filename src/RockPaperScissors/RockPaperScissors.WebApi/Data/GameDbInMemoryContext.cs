using Microsoft.EntityFrameworkCore;
using RockPaperScissors.WebApi.Data.Models;

namespace RockPaperScissors.WebApi.Data;

public class GameDbInMemoryContext : DbContext
{
    /// <summary>
    /// Все игры.
    /// </summary>
    public DbSet<Game> Games { get; set; }

    public DbSet<UserInGame> UsersInGames { get; set; }

    public DbSet<Turn> Turns { get; set; }

    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "RockPaperScissorsDb");
    }
}