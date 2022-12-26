using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using SQLite;
using Microsoft.EntityFrameworkCore;
using LerniloApo;
using Microsoft.Extensions.Options;
using System.Reflection;
using LerniloApo.Config;
using Newtonsoft.Json;


Console.Title = "Lernilo Apo";
//ConsoleHelper.DisplayMenu();
ConsoleHelper.StartMenu();

//FileManager.ReadFiles();
//FileManager.WriteFiles();

List<Deck> deckList = new List<Deck>();


var deck = new Deck()
{
    Name = "Esperanto",
    Description = "Deck with words in esperanto",
    Cards = new List<Card>()
    {
        new Card()
        {
            Front = "front1",
            Back = "back1",
            CreatedOn = DateTime.Now,
            Tags = new List<string>() { "esperanto", "vivanta" }
        },
        new Card()
        {
            Front = "front2",
            Back = "back2",
            CreatedOn = DateTime.Now,
            Tags = new List<string>() { "esperanto", "vivanta" }
        },
        new Card()
        {
            Front = "front3",
            Back = "back3",
            CreatedOn = DateTime.Now,
            Tags = new List<string>() { "esperanto", "vivanta" }
        },
    }
};

// Serialization
string deckSerialized = JsonConvert.SerializeObject(deck);
File.WriteAllText(@"..\..\..\JSON\deckSerialized.json", deckSerialized);


string deckSerialized_2 = File.ReadAllText(@"..\..\..\JSON\deckSerialized.json");
Deck deck_2 = JsonConvert.DeserializeObject<Deck>(deckSerialized_2);

Console.WriteLine($"Deck: {deck_2.Name}, no. of cards in deck: {deck_2.Cards.Count}");



if (false)
{
    string create_card =
@"CREATE TABLE IF NOT EXISTS card (
            id INT PRIMARY KEY,
            front TEXT
            );";


    var dbName = AppConfig.DB_NAME;


    if (File.Exists(dbName))
    {
        File.Delete(dbName);
    }

    using var dbContext = new SqliteDbContext();
    dbContext.Database.EnsureCreated();
    dbContext.Products.AddRange(new Product[]
    {
    new Product() {ProductName = "Apple", Price = 10.99 },
    new Product() {ProductName = "Orange", Price = 7.69 },
    new Product() {ProductName = "Tomato", Price = 23.30 },
    });
    dbContext.SaveChanges();

    Console.WriteLine("getting database data");
    dbContext.Products?.ToList().ForEach(p =>
        Console.WriteLine($"{p.ProductName}  Price: {p.Price:C}")
    );

    //void CreateTable()
    //{
    //    //string dbfile = "URI=file:lernilo.db";
    //    string dbfile = @"Data Source=.\lernilo.db";
    //    //string dbfile = @".\lernilo.db";

    //    SqliteConnection connection = new SqliteConnection(dbfile);
    //    connection.Open();

    //    string sql = "CREATE TABLE IF NOT EXISTS Person (ID integer primary key, NAME text);";
    //    //string sql = create_card;
    //    SqliteCommand command = new SqliteCommand(sql, connection);
    //    command.ExecuteNonQuery();
    //    connection.Close();
    //}

}

// show menu
void ShowMenu()
{
    Console.WriteLine(@"
1. Show list of decks.
");

    string input = Console.ReadLine();

    switch(input)
    {
        case "1":
            Console.WriteLine("?????");
            break;

    }
}

void PrintDeckList()
{
    Console.WriteLine("--f_show_deck_list");
    foreach (var deck in deckList)
    {
        Console.WriteLine($"deck - {deck.Name}");
    }
}
