using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using SQLite;
using Microsoft.EntityFrameworkCore;
using LerniloApo;
using Microsoft.Extensions.Options;
using System.Reflection;
using Newtonsoft.Json;
using LerniloApo.ConsoleUI;

Console.Title = "Lernilo Apo";
string create_card =
@"CREATE TABLE IF NOT EXISTS card (
            id INT PRIMARY KEY,
            front TEXT
            );";

var dbName = AppConfig.DB_NAME;

string pathLernilo = @"..\..\..\..\LerniloApo.DAL\Data\";

if (File.Exists(pathLernilo + dbName))
{
    File.Delete(pathLernilo + dbName);
}

using var dbContext = new SqliteDbContext();
dbContext.Database.EnsureCreated();

dbContext.Decks.AddRange(new Deck[]
{
    new Deck() {Name = "Esperanto", Description = ""},
});

dbContext.SaveChanges();

Console.WriteLine("Getting data from Lernilo database:");
dbContext.Decks?.ToList().ForEach(x =>
    Console.WriteLine($"{x.Id} {x.Name} {x.Description}")
);

CreateTable();

void CreateTable()
{
    //string dbfile = "URI=file:lernilo.db";
    //string dbfile = @"Data Source=.\lernilo2.db";
    string dbfile = @"Data Source=..\..\..\..\LerniloApo.DAL\Data\lernilo2.db";

    SqliteConnection connection = new(dbfile);
    connection.Open();

    string sql = "CREATE TABLE IF NOT EXISTS Person (ID integer primary key, NAME text);";
    SqliteCommand command = new(sql, connection);
    command.ExecuteNonQuery();

    string sql2 = create_card;
    SqliteCommand command2 = new(sql2, connection);
    command2.ExecuteNonQuery();

    connection.Close();
}
