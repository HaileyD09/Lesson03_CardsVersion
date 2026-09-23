namespace Toolkit;

public record Suit
{
    public string Name { get; }
    public string Symbol { get; }
    public ConsoleColor Color { get; }

    public static readonly Suit Hearts = new("Hearts", "♥", ConsoleColor.Red);
    public static readonly Suit Diamonds = new("Diamonds", "♦", ConsoleColor.Red);
    public static readonly Suit Clubs = new("Clubs", "♣", ConsoleColor.Black);
    public static readonly Suit Spades = new("Spades", "♠", ConsoleColor.Black);

    private Suit(string name, string symbol, ConsoleColor color)
    {
        Name = name;
        Symbol = symbol;
        Color = color;
    }
}
public record Value
{
    public string Label { get; }
    public int Rank { get; }

    public static readonly Value Ace = new("A", 1);
    public static readonly Value Two = new("2", 2);
    public static readonly Value Three = new("3", 3);
    public static readonly Value Four = new("4", 4);
    public static readonly Value Five = new("5", 5);
    public static readonly Value Six = new("6", 6);
    public static readonly Value Seven = new("7", 7);
    public static readonly Value Eight = new("8", 8);
    public static readonly Value Nine = new("9", 9);
    public static readonly Value Ten = new("10", 10);
    public static readonly Value Jack = new("J", 11);
    public static readonly Value Queen = new("Q", 12);
    public static readonly Value King = new("K", 13);

    private Value(string label, int rank)
    {
        Label = label;
        Rank = rank;
    }
}

public record Card(Suit Suit, Value Value)
{
    public override string ToString() => $"{Value.Label}{Suit.Symbol}";
}