public class Game
{
    private static int nextId = 1;

    // Properties
    public int Id { get; private set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Genre { get; set; }
    public string Players { get; set; }
    public int Condition { get; set; }
    public int Price { get; set; }
    public bool Stock { get; set; }
    public bool Requested { get; set; }
    public string RequestedBy { get; set; }

    // Constructor
    public Game(string title, string year, string genre, string players, int condition, int price, bool stock, bool requested, string requestedBy)
    {
        Id = nextId++;
        Title = title;
        Year = year;
        Genre = genre;
        Players = players;
        Condition = condition;
        Price = price;
        Stock = stock;
        Requested = requested;
        RequestedBy = requestedBy;
    }

    // Method to set the Id
    public void SetId(int id)
    {
        Id = id;
        if (id >= nextId)
        {
            nextId = id + 1;
        }
    }

    // Method to convert the game object to a string
    public override string ToString()
    {
        return $"{Id},{Title},{Year},{Genre},{Players},{Condition},{Price},{Stock},{Requested},{RequestedBy}";
    }
}
