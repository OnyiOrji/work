using System;
using System.Collections.Generic;

public interface IGameAble
{
    void Add(Game game);
    List<Game> Search(string query);
    void Delete(string name);
    void Display();
}

public class Game
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public int YearPublished { get; set; }
    public string Publisher { get; set; }
    public string Ratings { get; set; }

    public override string ToString()
    {
        return $"{Name} ({YearPublished}) by {Publisher}, Rated {Ratings}, Price: {Price:C}, Discount: {Discount}%";
    }

    public void Display()
    {
        Console.WriteLine(this.ToString());
    }
}

public class GameStore : IGameAble
{
    private List<Game> games = new List<Game>();

    public void Add(Game game)
    {
        games.Add(game);
        Console.WriteLine($"Game {game.Name} added successfully!");
    }

    public List<Game> Search(string query)
    {
        List<Game> results = new List<Game>();
        foreach (Game game in games)
        {
            if (game.Name.ToLower().Contains(query.ToLower()))
            {
                results.Add(game);
            }
        }

        if (results.Count == 0)
        {
            Console.WriteLine($"No games found for search query: {query}");
        }
        else if (results.Count == 1)
        {
            Console.WriteLine("Game found:");
            results[0].Display();
        }
        else
        {
            Console.WriteLine($"Multiple games found for search query: {query}");
            foreach (Game game in results)
            {
                game.Display();
            }
        }

        return results;
    }

    public void Delete(string name)
    {
        for (int i = 0; i < games.Count; i++)
        {
            if (games[i].Name.ToLower() == name.ToLower())
            {
                games.RemoveAt(i);
                Console.WriteLine($"Game {name} deleted successfully!");
                return;
            }
        }

        Console.WriteLine($"Game {name} not found, cannot delete.");
    }

    public void Display()
    {
        if (games.Count == 0)
        {
            Console.WriteLine("No games added yet!");
        }
        else
        {
            foreach (Game game in games)
            {
                game.Display();
            }
        }
    }
}

public class Program
{
	public static void Main(string[] args)
	{
		GameStore store = new GameStore();

        while (true)
        {
            Console.WriteLine("\nWelcome to the Game Store App! What would you like to do?");
            Console.WriteLine("1. Add a game to the store.");
            Console.WriteLine("2. Search for a game in the store.");
            Console.WriteLine("3. Display all games in the store.");
            Console.WriteLine("4. Delete a game from the store.");
            Console.WriteLine("5. Exit the app.");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice, please try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nAdding a game to the store. Please enter the following details:");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Price: ");
                    decimal price;
                    if (!decimal.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Invalid price, please try again.");
                        continue;
                    }
                    Console.Write("Discount: ");
                    decimal discount;
                    if (!decimal.TryParse(Console.ReadLine(), out discount))
                    {
                        Console.WriteLine("Invalid discount, please try again.");
                        continue;
                    }
                    Console.Write("Year Published: ");
                    int yearPublished;
                    if (!int.TryParse(Console.ReadLine(), out yearPublished))
                    {
                        Console.WriteLine("Invalid year, please try again.");
                        continue;
                    }
                    Console.Write("Publisher: ");
                    string publisher = Console.ReadLine();
                    Console.Write("Ratings: ");
                    string ratings = Console.ReadLine();
                    Game gameToAdd = new Game
                    {
                        Name = name,
                        Price = price,
                        Discount = discount,
                        YearPublished = yearPublished,
                        Publisher = publisher,
                        Ratings = ratings
                    };
                    store.Add(gameToAdd);
                    break;

                case 2:
                    Console.WriteLine("\nSearching for a game in the store. Please enter a search query:");
                    string query = Console.ReadLine();
                    store.Search(query);
                    break;

                case 3:
                    Console.WriteLine("\nDisplaying all games in the store:");
                    store.Display();
                    break;

                case 4:
                    Console.WriteLine("\nDeleting a game from the store. Please enter the name of the game to delete:");
                    string gameNameToDelete = Console.ReadLine();
                    store.Delete(gameNameToDelete);
                    break;

                case 5:
                    Console.WriteLine("\nThank you for using the Game Store App. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
	}
}
