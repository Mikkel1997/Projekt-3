using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Enter title or genre: ");
            string searchValue = Console.ReadLine();
            var gamesList = gameRepository.GetGamesList();
            var searchResults = GetSearchResults(searchValue, gamesList);
            consoleUI.ShowGames(searchResults);
        }

        // Method to get search results
        private List<Game> GetSearchResults(string searchValue, List<Game> gamesList)
        {
            List<Game> searchResults = new List<Game>();

            foreach (var game in gamesList)
            {
                if (game.Title.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    game.Genre.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    searchResults.Add(game);
                }
            }

            return searchResults;
        }

        // Method to display search criteria
        private void DisplaySearchCriteria()
        {
            Console.WriteLine("Available search criteria:\n");
            Console.WriteLine("1) Title");
            Console.WriteLine("2) Genre");
            Console.WriteLine("3) Players");
            Console.WriteLine("4) Condition (1-10)");
            Console.WriteLine("5) Price");
            Console.WriteLine("6) In stock");
            Console.WriteLine("7) Requested\n");
        }

        // Method to get search criteria
        private int GetSearchCriteria()
        {
            Console.Write("Enter search criteria (#): ");
            int.TryParse(Console.ReadLine(), out int criteria);
            return criteria;
        }

        // Method to get search value
        private string GetSearchValue(string[] criterias, int criteria)
        {
            Console.Write($"Enter search value for {criterias[criteria - 1]}: ");
            return Console.ReadLine().ToLower() ?? "";
        }

        // Method to get search results based on criteria
        private List<Game> GetSearchResults(int criteria, string searchValue, List<Game> gamesList)
        {
            List<Game> searchResults = new List<Game>();

            foreach (var game in gamesList)
            {
                if (criteria == 1 && game.Title.StartsWith(searchValue, StringComparison.OrdinalIgnoreCase))
                {
                    searchResults.Add(game);
                }
                else if (criteria == 2 && game.Genre.StartsWith(searchValue, StringComparison.OrdinalIgnoreCase))
                {
                    searchResults.Add(game);
                }
            }

            return searchResults;
        }

        // Method to display search results
        private void DisplaySearchResults(List<Game> searchResults)
        {
            if (searchResults.Count > 0)
            {
                Console.Clear();
                consoleUI.ShowGames(searchResults);
                return;
            }
            else
            {
                Console.WriteLine("No games found matching the search criteria. Press <enter> to try again.");
                Console.ReadLine();
                SearchGames();
            }
        }
    }
}
