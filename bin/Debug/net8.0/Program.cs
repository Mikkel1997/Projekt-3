
using System;
using ProjektGenspil;

public class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Create a new GameRepository object
        GameRepository gameRepository = new GameRepository();

        // Load games from file
        gameRepository.LoadGamesFromFile();

        // Create a new ConsoleUI object
        ConsoleUI consoleUI = new ConsoleUI(gameRepository);

        // Create a new GameSearch object
        GameSearch gameSearch = new GameSearch(gameRepository, consoleUI);

        // Setup the console window
        ConsoleUI.ConsoleWindowSetup();

        // Display the add/edit/remove menu
        consoleUI.AddEditRemoveMenu();
    }
}
