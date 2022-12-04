using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using SQLite;
using Microsoft.EntityFrameworkCore;
using LerniloApo;
using Microsoft.Extensions.Options;
using System.Reflection;

Console.WriteLine("LerniloApo");

//FileManager.ReadFiles();
//FileManager.WriteFiles();

string create_card =
    @"CREATE TABLE IF NOT EXISTS card (
            id INT PRIMARY KEY,
            front TEXT
            );";


var dbName = "lernilo.db";
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


// show menu
