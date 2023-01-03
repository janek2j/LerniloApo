using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LerniloApo.ConsoleUI;

public class SqliteDbContext : DbContext
{
    public DbSet<Deck> Decks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO 
        // C:\Users\janek\source\repos\LerniloApo\LerniloApo.DAL\Data
        optionsBuilder.UseSqlite("FileName=..\\..\\..\\..\\LerniloApo.DAL\\Data\\lernilo.db", option =>
        {
            option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        });
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deck>().ToTable("Decks", "mainschema");
        modelBuilder.Entity<Deck>(entity =>
        {
            entity.HasKey(k => k.Id);
            entity.HasIndex(i => i.Name).IsUnique();
        });
    }
}
