namespace LerniloApo.ConsoleUI;
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

    public static string[] menuOptions = {
            "Show list of decks", "Show list of cards", "Show list of users", "Add deck", "Add card", "Add user", "Search...", "Exit program" };

    public static int activePosition = 0;

    public static void StartMenu()
    {
        Console.CursorVisible = false;
        while (true)
        {
            DisplayMenu();
            SelectOption();
            RunOption();
        }
    }

    public static void DisplayMenu()
    {
        const ConsoleColor BG = ConsoleColor.Gray;
        const ConsoleColor BG_ACTIVE = ConsoleColor.DarkCyan;
        const ConsoleColor FG = ConsoleColor.DarkCyan;
        const ConsoleColor FG_ACTIVE = ConsoleColor.White;
        Console.BackgroundColor = BG;
        Console.Clear();
        Console.ForegroundColor = FG;

        string welcome = "Welcome to Lernilo Apo!";
        Console.WriteLine();
        Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
        Console.WriteLine(welcome);
        Console.WriteLine();
        Console.WriteLine("Choose your option:");
        Console.WriteLine();

        for (int i = 1; i <= _menuOptions.Count; i++)
        {
            if (activePosition == i)
            {
                Console.BackgroundColor = BG_ACTIVE;
                Console.ForegroundColor = FG_ACTIVE;
                Console.Write($"{i}. ");
                Console.WriteLine("{0,-35}", _menuOptions.ElementAt(i - 1).Value);
                Console.BackgroundColor = BG;
                Console.ForegroundColor = FG;
            }
            else
            {
                Console.Write($"{i}. ");
                Console.WriteLine(_menuOptions.ElementAt(i - 1).Value);
            }
        }
    }
    public static void SelectOption()
    {
        do
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                activePosition = activePosition > 1 ? --activePosition : _menuOptions.Count;
                DisplayMenu();
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                activePosition = activePosition % _menuOptions.Count + 1;
                DisplayMenu();
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                activePosition = _menuOptions.Count;
                break;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
            else
            {
                if (key.Key == ConsoleKey.D1) activePosition = 1;
                if (key.Key == ConsoleKey.D2) activePosition = 2;
                if (key.Key == ConsoleKey.D3) activePosition = 3;
                if (key.Key == ConsoleKey.D4) activePosition = 4;
                if (key.Key == ConsoleKey.D5) activePosition = 5;
                if (key.Key == ConsoleKey.D6) activePosition = 6;
                if (key.Key == ConsoleKey.D7) activePosition = 7;
                break;
            }
        } while (true);
    }

    public static void RunOption()
    {
        switch (activePosition)
        {
            case 1: Console.Clear(); Console.ReadKey(); break;
            case 2: Console.Clear(); Console.ReadKey(); break;
            case 3: Console.Clear(); Console.ReadKey(); break;
            case 4: Console.Clear(); Console.ReadKey(); break;
            case 5: Console.Clear(); Console.ReadKey(); break;
            case 6: Console.Clear(); Console.ReadKey(); break;
            case 7: Console.Clear(); Console.ReadKey(); break;
            case 8: Environment.Exit(0); break;
        }
    }
}
