using ProjektGenspil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public class GameSorting
    {
        // Method to perform quick sort on a list of games
        public List<Game> QuickSort(List<Game> games, int left, int right, string sortBy)
        {
            if (left < right)
            {
                int pivotIndex = QuickSortByProperty(games, left, right, sortBy);
                QuickSort(games, left, pivotIndex - 1, sortBy);
                QuickSort(games, pivotIndex + 1, right, sortBy);
            }
            return games;
        }

        // Method to sort games by a specific property
        private int QuickSortByProperty(List<Game> games, int left, int right, string property)
        {
            string pivot = GetProperty(games[right], property);
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (string.Compare(GetProperty(games[j], property), pivot) <= 0)
                {
                    i++;
                    Game temp = games[i];
                    games[i] = games[j];
                    games[j] = temp;
                }
            }

            Game tempPivot = games[i + 1];
            games[i + 1] = games[right];
            games[right] = tempPivot;

            return i + 1;
        }

        // Method to get a specific property of a game
        private string GetProperty(Game game, string property)
        {
            switch (property)
            {
                case "title":
                    return game.Title;
                case "genre":
                    return game.Genre;
                default:
                    throw new ArgumentException("Invalid property");
            }
        }
    }
}
