using System;
using System.Collections.Generic;

namespace ProjektGenspil
{
    public class GameSearch
    {
        private readonly GameRepository gameRepository;
        private readonly ConsoleUI consoleUI;

        // Constructor
        public GameSearch(GameRepository gameRepository, ConsoleUI consoleUI)
        {
            this.gameRepository = gameRepository;
            this.consoleUI = consoleUI;
        }

        // Method to search for games
        public void SearchGames()
        {
            Console.WriteLine("Enter search criteria (title, year, genre, players, condition, price, stock, requested, requestedby): ");
            string property = Console.ReadLine();
            Console.WriteLine($"Enter search value for {property}: ");
            string searchValue = Console.ReadLine();
            var gamesList = gameRepository.GetGamesList();
            var searchResults = GetSearchResults(searchValue, gamesList, property);
            consoleUI.ShowGames(searchResults);
        }

        // Method to get search results
        public List<Game> GetSearchResults(string searchValue, List<Game> gamesList, string property)
        {
            List<Game> searchResults = new List<Game>();

            foreach (var game in gamesList)
            {
                string gameProperty = GetProperty(game, property);
                if (gameProperty.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    searchResults.Add(game);
                }
            }

            return searchResults;
        }

        // Method to get a specific property of a game
        private string GetProperty(Game game, string property)
        {
            switch (property)
            {
                case "title":
                    return game.Title;
                case "year":
                    return game.Year.ToString();
                case "genre":
                    return game.Genre;
                case "players":
                    return game.Players;
                case "condition":
                    return game.Condition.ToString();
                case "price":
                    return game.Price.ToString();
                case "stock":
                    return game.Stock.ToString();
                case "requested":
                    return game.Requested.ToString();
                case "requestedby":
                    return game.RequestedBy;
                default:
                    throw new ArgumentException("Invalid property");
            }
        }
    }
}