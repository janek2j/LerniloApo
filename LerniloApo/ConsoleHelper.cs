using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerniloApo
{
    public static class ConsoleHelper
    {
        private static readonly Dictionary<ConsoleKey, string> _menuOptions = new()
        {
            {ConsoleKey.D1, "Show list of decks"},
            {ConsoleKey.D2, "Show list of cards"},
            {ConsoleKey.D3, "Show list of users"},
            {ConsoleKey.D4, "Add deck"},
            {ConsoleKey.D5, "Add card"},
            {ConsoleKey.D6, "Add user"},
            {ConsoleKey.D7, "Search..."},
            {ConsoleKey.Escape, "Quit program"},
        };
        public static void DisplayMenu()
        {
            Console.Clear();

            string welcome = "Welcome to Lernilo Apo!";
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
            Console.WriteLine(welcome);
            Console.WriteLine();
            Console.WriteLine("Choose your option:");

            for (int i = 0; i < _menuOptions.Count; i++)
            {
                if (i + 1 == 8)
                {
                    Console.WriteLine($"ESC. {_menuOptions.ElementAt(i).Value}");
                }
                Console.WriteLine($"{i + 1}. {_menuOptions.ElementAt(i).Value}");
            }
        }
    }
}