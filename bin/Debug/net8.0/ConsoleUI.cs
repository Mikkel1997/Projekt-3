using System;
using System.Collections.Generic;
using ProjektGenspil;

public class ConsoleUI
{
    private readonly GameRepository gameRepository;
    private readonly GameSearch gameSearch;
    // Constructor
    public ConsoleUI(GameRepository gameRepository)
    {
        this.gameRepository = gameRepository;
        this.gameSearch = new GameSearch(gameRepository, this);
    }
    // Method to setup the console window
    public static void ConsoleWindowSetup()
    {
        Console.Title = "Genspil Inventory System";
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
    }

    // Method to display the main menu
    public void AddEditRemoveMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Main Menu:\n");
            Console.WriteLine("1) Show inventory");
            Console.WriteLine("2) Search games");
            Console.WriteLine("3) Add, edit, or remove games");
            Console.WriteLine("4) Sort inventory");
            Console.WriteLine("5) Exit");

            Console.Write("\nPlease select an option (#): ");
            if (!int.TryParse(Console.ReadLine(), out int menuChoice))
            {
                Console.WriteLine("Invalid option. Please enter a number.");
                continue;
            }

            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    ShowGames(gameRepository.GetGamesList());
                    break;
                case 2:
                    Console.Clear();
                    SearchGamesSubMenu();
                    break;
                case 3:
                    Console.Clear();
                    AddEditRemoveSubMenu();
                    break;
                case 4:
                    Console.Clear();
                    SortInventorySubMenu();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Thank you for using the service. You may close the program now.");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }
    }
    // Method to display the submenu for adding, editing, and removing games
    private void AddEditRemoveSubMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Submenu:\n");
            Console.WriteLine("1) Add a new game");
            Console.WriteLine("2) Update a game");
            Console.WriteLine("3) Remove a game");
            Console.WriteLine("4) Exit to main menu.");

            Console.Write("\nPlease select an option: (#) ");
            if (!int.TryParse(Console.ReadLine(), out int crudMenuChoice))
            {
                Console.WriteLine("Invalid option. Please enter a number.");
                continue;
            }

            switch (crudMenuChoice)
            {
                case 1:
                    Console.Clear();
                    gameRepository.AddGames();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    gameRepository.UpdateGame();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    gameRepository.DeleteGame();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }
    }

    // Method to display a list of games
    public void ShowGames(List<Game> gamesToDisplay)
    {
        if (gamesToDisplay == null)
        {
            return;
        }

        if (gamesToDisplay.Count == 0)
        {
            Console.WriteLine("The last was not empty in ShowGames... but here it prints anyway.");
            Console.ReadLine();
        }

        // Print names for columns with width formatting.
        Console.WriteLine($"{"Id",-8} {"Title",-50} {"Year",-8} {"Genre",-15} {"Players",-8} {"Condition",-8} {"Price",-8} {"Stock",-10} {"Requested",-10} {"Requested By",-10}");

        // Print game data in columns with width formatting.
        foreach (Game game in gamesToDisplay)
        {
            Console.WriteLine($"{game.Id,-8} {game.Title,-50} {game.Year,-7} {game.Genre,-15} {game.Players,-9} {game.Condition,-9} {game.Price,-8} {(game.Stock ? "\u001b[32mYes\u001b[0m" : "\u001b[31mNo\u001b[0m"),-19} {(game.Requested ? "Yes" : "No"),-10} {(game.Requested ? game.RequestedBy : ""),-10}");
        }

        Console.WriteLine("\nGames found: {0}\n", gamesToDisplay.Count);
        Console.Write("Press <enter> to continue.");
        Console.ReadLine();
    }

    // Method to print the stock
    public void PrintStock(List<Game> gamesToSort)
    {
        Console.Clear();
        Console.WriteLine("Stock List:\n");

        foreach (Game game in gamesToSort)
        {
            if (game.Stock)
            {
                GameSummary(game);
                Console.WriteLine();
            }
        }

        Console.WriteLine("Press <enter> to return to the main menu.");
        Console.ReadLine();
    }

    // Method to print a summary of a game
    public void GameSummary(Game game)
    {
        Console.WriteLine($"ID: {game.Id}");
        Console.WriteLine($"Title: {game.Title}");
        Console.WriteLine($"Year: {game.Year}");
        Console.WriteLine($"Genre: {game.Genre}");
        Console.WriteLine($"Players: {game.Players}");
        Console.WriteLine($"Condition: {game.Condition}");
        Console.WriteLine($"Price: {game.Price}");
        Console.WriteLine($"Stock: {(game.Stock ? "Yes" : "No")}");
        Console.WriteLine($"Requested: {(game.Requested ? "Yes" : "No")}");
        if (game.Requested)
        {
            Console.WriteLine($"Requested by: {game.RequestedBy}");
        }
    }

    private void SortInventorySubMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Sort Inventory Submenu:\n");
            Console.WriteLine("1) Sort by title");
            Console.WriteLine("2) Sort by year");
            Console.WriteLine("3) Sort by genre");
            Console.WriteLine("4) Sort by players");
            Console.WriteLine("5) Sort by condition");
            Console.WriteLine("6) Sort by price");
            Console.WriteLine("7) Sort by stock");
            Console.WriteLine("8) Sort by requested");
            Console.WriteLine("9) Sort by requested by");
            Console.WriteLine("10) Exit to main menu.");

            Console.Write("\nPlease select an option: (#) ");
            if (!int.TryParse(Console.ReadLine(), out int sortMenuChoice))
            {
                Console.WriteLine("Invalid option. Please enter a number.");
                continue;
            }

            string property = null;
            switch (sortMenuChoice)
            {
                case 1:
                    property = "title";
                    break;
                case 2:
                    property = "year";
                    break;
                case 3:
                    property = "genre";
                    break;
                case 4:
                    property = "players";
                    break;
                case 5:
                    property = "condition";
                    break;
                case 6:
                    property = "price";
                    break;
                case 7:
                    property = "stock";
                    break;
                case 8:
                    property = "requested";
                    break;
                case 9:
                    property = "requestedby";
                    break;
                case 10:
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Please select a valid option");
                    continue;
            }

            Console.Clear();
            GameSorting gameSorting = new GameSorting();
            List<Game> sortedGames = gameSorting.QuickSort(gameRepository.GetGamesList(), 0, gameRepository.GetGamesList().Count - 1, property);
            ShowGames(sortedGames);
        }
    }
    private void SearchGamesSubMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Search Games Submenu:\n");
            Console.WriteLine("1) Search by title");
            Console.WriteLine("2) Search by year");
            Console.WriteLine("3) Search by genre");
            Console.WriteLine("4) Search by players");
            Console.WriteLine("5) Search by condition");
            Console.WriteLine("6) Search by price");
            Console.WriteLine("7) Search by stock");
            Console.WriteLine("8) Search by requested");
            Console.WriteLine("9) Search by requested by");
            Console.WriteLine("10) Exit to main menu.");

            Console.Write("\nPlease select an option: (#) ");
            if (!int.TryParse(Console.ReadLine(), out int searchMenuChoice))
            {
                Console.WriteLine("Invalid option. Please enter a number.");
                continue;
            }

            string property = null;
            switch (searchMenuChoice)
            {
                case 1:
                    property = "title";
                    break;
                case 2:
                    property = "year";
                    break;
                case 3:
                    property = "genre";
                    break;
                case 4:
                    property = "players";
                    break;
                case 5:
                    property = "condition";
                    break;
                case 6:
                    property = "price";
                    break;
                case 7:
                    property = "stock";
                    break;
                case 8:
                    property = "requested";
                    break;
                case 9:
                    property = "requestedby";
                    break;
                case 10:
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Please select a valid option");
                    continue;
            }

            Console.Clear();
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();
            List<Game> searchResults = gameSearch.GetSearchResults(searchTerm, gameRepository.GetGamesList(), property);
            ShowGames(searchResults);
        }
    }
}

