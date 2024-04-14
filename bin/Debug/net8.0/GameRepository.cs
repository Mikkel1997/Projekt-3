using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjektGenspil;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Constructor
public class GameRepository
{
    private List<Game> gamesList;
    private string filePath;

    public GameRepository()
    {
        gamesList = new List<Game>();
        string directoryPath = @"C:\Users\Mikkel\Desktop\Datamatiker 2024\Code\Projekt 3 -Genspil v2\bin\Debug\net8.0";
        string fileName = "GenspilGames.txt";
        filePath = Path.Combine(directoryPath, fileName);
    }
    // Method to get the list of games
    public List<Game> GetGamesList()
    {
        return gamesList;
    }
    // Method to load games from a file
    public void LoadGamesFromFile()
    {
        gamesList.Clear();

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            if (parts.Length < 10)
            {
                continue;
            }

            int id;
            if (!int.TryParse(parts[0], out id))
            {
                continue;
            }

            string title = parts[1];
            string year = parts[2]; ;          
            string genre = parts[3];
            string players = parts[4];
            int condition;
            if (!int.TryParse(parts[5], out condition))
            {
                continue;
            }

            int price;
            if (!int.TryParse(parts[6], out price))
            {
                continue;
            }

            bool stock;
            if (!bool.TryParse(parts[7], out stock))
            {
                continue;
            }

            bool requested;
            if (!bool.TryParse(parts[8], out requested))
            {
                continue;
            }

            string requestedBy = parts[9];

            Game game = new Game(title, year, genre, players, condition, price, stock, requested, requestedBy);
            game.SetId(id);

            gamesList.Add(game);
        }
    }
    // Method to save the list of games to a file
    public void SaveToFileFromList()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Game game in gamesList)
                {
                    writer.WriteLine(game.ToString());
                }
            }

            Console.WriteLine("Games saved to file successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving games to file: {ex.Message}");
        }
    }

    // Method to add a new game
    public void AddGames()
    {
        Console.Write("Enter game title: ");
        string title = Console.ReadLine();

        Console.Write("Enter game year: ");
        string year = (Console.ReadLine());

        Console.Write("Enter game genre: ");
        string genre = Console.ReadLine();

        Console.Write("Enter game players: ");
        string players = Console.ReadLine();

        Console.Write("Enter game condition: ");
        int condition = int.Parse(Console.ReadLine());

        Console.Write("Enter game price: ");
        int price = int.Parse(Console.ReadLine());

        Console.Write("Is the game in stock? (true/false): ");
        bool stock = bool.Parse(Console.ReadLine());

        Console.Write("Is the game requested? (true/false): ");
        bool requested = bool.Parse(Console.ReadLine());

        Console.Write("Enter requested by: ");
        string requestedBy = Console.ReadLine();

        Game newGame = new Game(title, year, genre, players, condition, price, stock, requested, requestedBy);

        int newId = gamesList.Any() ? gamesList.Max(g => g.Id) + 1 : 1;
        newGame.SetId(newId);

        gamesList.Add(newGame);

        SaveToFileFromList();

        Console.WriteLine("Game added successfully!");
        Console.WriteLine("Press <enter> to return to the main menu.");
        Console.ReadLine();
    }
    // Method to update an existing game
    public void UpdateGame()
    {
        Console.Write("Please enter the ID of the game to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            return;
        }

        Game game = gamesList.FirstOrDefault(g => g.Id == id);

        if (game == null)
        {
            Console.WriteLine($"Game with ID {id} not found.");
            return;
        }

        Console.WriteLine($"Updating game with ID {id}:");
        Console.WriteLine("Enter the field to update (title/year/genre/players/condition/price/stock/requested/requestedBy): ");
        string field = Console.ReadLine();

        switch (field.ToLower())
        {
            case "title":
                Console.Write("Enter the new title: ");
                game.Title = Console.ReadLine();
                break;
            case "year":
                Console.Write("Enter the new year: ");
              game.Year = Console.ReadLine();
                break;
            case "genre":
                Console.Write("Enter the new genre: ");
                game.Genre = Console.ReadLine();
                break;
            case "players":
                Console.Write("Enter the new players: ");
                game.Players = Console.ReadLine();
                break;
            case "condition":
                Console.Write("Enter the new condition: ");
                if (int.TryParse(Console.ReadLine(), out int condition))
                {
                    game.Condition = condition;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric condition.");
                }
                break;
            case "price":
                Console.Write("Enter the new price: ");
                if (int.TryParse(Console.ReadLine(), out int price))
                {
                    game.Price = price;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric price.");
                }
                break;
            case "stock":
                Console.Write("Enter the new stock value (true/false): ");
                if (bool.TryParse(Console.ReadLine(), out bool stock))
                {
                    game.Stock = stock;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter either 'true' or 'false'.");
                }
                break;
            case "requested":
                Console.Write("Enter the new requested value (true/false): ");
                if (bool.TryParse(Console.ReadLine(), out bool requested))
                {
                    game.Requested = requested;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter either 'true' or 'false'.");
                }
                break;
            case "requestedby":
                Console.Write("Enter the new requested by value: ");
                game.RequestedBy = Console.ReadLine();
                break;
            default:
                Console.WriteLine("Invalid field. No changes were made.");
                break;
        }

        SaveToFileFromList();

        Console.WriteLine("Game updated successfully!");
        Console.WriteLine("Press <enter> to return to the main menu.");
        Console.ReadLine();
    }

    // Method to delete a game
    public void DeleteGame()
    {
        Console.Write("Please enter the ID of the game to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            return;
        }

        Game game = gamesList.FirstOrDefault(g => g.Id == id);

        if (game == null)
        {
            Console.WriteLine($"Game with ID {id} not found.");
            return;
        }

        gamesList.Remove(game);

        SaveToFileFromList();

        Console.WriteLine("Game deleted successfully!");
        Console.WriteLine("Press <enter> to return to the main menu.");
        Console.ReadLine();
    }

}

