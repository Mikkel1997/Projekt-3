using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_3___Genspil
{
    public class Inventory
    {
        private List<Game> games;

        public Inventory()
        {
            games = new List<Game>();
        }

        public void AddGame(Game game)
        {
            games.Add(game);
        }

        public void RemoveGame(Game game)
        {
            games.Remove(game);
        }

        public void PrintInventory()
        {
            Console.Clear();
            Console.WriteLine("Inventory:");
            foreach (var game in games)
            {
                Console.WriteLine($"Name: {game.Name}, Genre: {game.Genre}, Age: {game.Age}, Players: {game.Players}, Condition: {game.Condition}, Price: {game.Price}");
            }
        }
    

    public IEnumerable<Game> SearchByName(string name)
        {
            return games.Where(g => g.Name.ToLower().Contains(name.ToLower()));
        }

        public IEnumerable<Game> SearchByGenre(string genre)
        {
            return games.Where(g => g.Genre.ToLower().Contains(genre.ToLower()));
        }

        public IEnumerable<Game> SearchByAge(int age)
        {
            return games.Where(g => g.Age == age);
        }

        public IEnumerable<Game> SearchByPlayers(int players)
        {
            return games.Where(g => g.Players == players);
        }

        public IEnumerable<Game> SearchByCondition(string condition)
        {
            return games.Where(g => g.Condition.ToLower().Contains(condition.ToLower()));
        }

        // Other methods for searching, sorting, etc.
    }
}
