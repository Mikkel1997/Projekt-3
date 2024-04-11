using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_3___Genspil
{
    public class Program
    {
        private static Inventory inventory = new Inventory();
        private static RequestManager requestManager = new RequestManager();

        public static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Board Game Inventory System");
                Console.WriteLine("1. Search Games");
                Console.WriteLine("2. Add Game");
                Console.WriteLine("3. Remove Game");
                Console.WriteLine("4. Add Customer Request");
                Console.WriteLine("5. Remove Customer Request");
                Console.WriteLine("6. Print Inventory");
                Console.WriteLine("7. Print Customer Request");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SearchGames();
                        break;
                    case "2":
                        AddGame();
                        break;
                    case "3":
                        RemoveGame();
                        break;
                    case "4":
                        AddCustomerRequest();
                        break;
                    case "5":
                        RemoveCustomerRequest();
                        break;
                    case "6":
                        inventory.PrintInventory();
                        break;
                    case "7":
                        requestManager.PrintRequests();
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static void SearchGames()
        {
            Console.Clear();
            Console.WriteLine("Search Games");
            Console.WriteLine("1. By Name");
            Console.WriteLine("2. By Genre");
            Console.WriteLine("3. By Age");
            Console.WriteLine("4. By Players");
            Console.WriteLine("5. By Condition");
            Console.WriteLine("6. Back");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SearchByName();
                    break;
                case "2":
                    SearchByGenre();
                    break;
                case "3":
                    SearchByAge();
                    break;
                case "4":
                    SearchByPlayers();
                    break;
                case "5":
                    SearchByCondition();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static void SearchByName()
        {
            Console.Clear();
            Console.Write("Enter name to search for: ");
            string name = Console.ReadLine();
            var games = inventory.SearchByName(name);
            DisplayGames(games);
        }

        private static void SearchByGenre()
        {
            Console.Clear();
            Console.Write("Enter genre to search for: ");
            string genre = Console.ReadLine();
            var games = inventory.SearchByGenre(genre);
            DisplayGames(games);
        }

        private static void SearchByAge()
        {
            Console.Clear();
            Console.Write("Enter age to search for: ");
            int age = int.Parse(Console.ReadLine());
            var games = inventory.SearchByAge(age);
            DisplayGames(games);
        }

        private static void SearchByPlayers()
        {
            Console.Clear();
            Console.Write("Enter number of players to search for: ");
            int players = int.Parse(Console.ReadLine());
            var games = inventory.SearchByPlayers(players);
            DisplayGames(games);
        }

        private static void SearchByCondition()
        {
            Console.Clear();
            Console.Write("Enter condition to search for: ");
            string condition = Console.ReadLine();
            var games = inventory.SearchByCondition(condition);
            DisplayGames(games);
        }

        // Similar methods for other search criteria

        private static void DisplayGames(IEnumerable<Game> games)
        {
            Console.Clear();
            Console.WriteLine("Search Results:");
            foreach (var game in games)
            {
                Console.WriteLine($"Name: {game.Name}, Genre: {game.Genre}, Age: {game.Age}, Players: {game.Players}, Condition: {game.Condition}, Price: {game.Price}");
            }
        }

        private static void AddGame()
        {
            Console.Clear();
            Console.WriteLine("Add Game");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter players: ");
            int players = int.Parse(Console.ReadLine());
            Console.Write("Enter condition: ");
            string condition = Console.ReadLine();
            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Game game = new Game
            {
                Name = name,
                Genre = genre,
                Age = age,
                Players = players,
                Condition = condition,
                Price = price
            };

            inventory.AddGame(game);
            Console.WriteLine("Game added successfully.");
        }

        private static void RemoveGame()
        {
            Console.Clear();
            Console.WriteLine("Remove Game");
            Console.Write("Enter name of game to remove: ");
            string name = Console.ReadLine();
            Game game = inventory.SearchByName(name).FirstOrDefault();
            if (game != null)
            {
                inventory.RemoveGame(game);
                Console.WriteLine("Game removed successfully.");
            }
            else
            {
                Console.WriteLine("Game not found.");
            }
        }

        private static void AddCustomerRequest()
        {
            Console.Clear();
            Console.WriteLine("Add Customer Request");
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter requested game: ");
            string requestedGame = Console.ReadLine();

            CustomerRequest request = new CustomerRequest
            {
                CustomerName = customerName,
                RequestedGame = requestedGame
            };

            requestManager.AddRequest(request);
            Console.WriteLine("Customer request added successfully.");
        }

        private static void RemoveCustomerRequest()
        {
            Console.Clear();
            Console.WriteLine("Remove Customer Request");
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter requested game: ");
            string requestedGame = Console.ReadLine();

            CustomerRequest request = new CustomerRequest
            {
                CustomerName = customerName,
                RequestedGame = requestedGame
            };

            requestManager.RemoveRequest(request);
            Console.WriteLine("Customer request removed successfully.");
        }
    }
}
