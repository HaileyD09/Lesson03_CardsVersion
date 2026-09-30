using LanguageExt;

namespace Toolkit;

public record Deck
{
    public static Deck CreateStandardDeck() => new Deck();

    private List<Card> _cards;
    
    private Deck(List<Card> fromCards) => _cards = fromCards;

    private Deck()
    {
        _cards = new List<Card>();
        foreach (var suit in new[] { Suit.Hearts, Suit.Diamonds, Suit.Clubs, Suit.Spades })
        {
            foreach (var value in new[] { Value.Ace, Value.Two, Value.Three, Value.Four, Value.Five, Value.Six, Value.Seven, Value.Eight, Value.Nine, Value.Ten, Value.Jack, Value.Queen, Value.King })
            {
                _cards.Add(new Card(suit, value));
            }
        }
    }

    /// <summary>
    /// Shuffles the deck of cards!
    /// </summary>
    /// <param name="random">Inject your RNG here!</param>
    public void Shuffle(Random random)
    {
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
        }
    }

    public Deck Split()
    {
        Deck other = new Deck(_cards.Take(_cards.Count / 2).ToList());
        _cards.RemoveRange(0, _cards.Count / 2);
        return other;
    }

    public void Cut(int cutPosition)
    {
        // TODO: How is Cut different from Split?
        // It is one deck and puts top beneath bottom versus split returns two decks
        var reordered = _cards.Skip(cutPosition).Concat(_cards.Take(cutPosition)).ToList();
        _cards.Clear();
        _cards.AddRange(reordered);
    }

    public Deck Cut(Random random)
    {
        var cutPoint = random.Next(_cards.Count);
        var otherHalf = new Deck([.._cards[..cutPoint]]);
        // make cards equal to the part of cards that is after the cutPoint.
        // take away all the cards before cutpoint.
        // only use the cards /after/ cutPoint.
        _cards = [.. _cards[cutPoint..]];
        // _cards becomes....
        //      ^[ Collection Expression.
        //       ^.. take all the items in (below) one-by-one.
        //          ^_cards[  from _cards
        //                 ^cutpoint..] starting from index 'cutPoint' to the end.
        //                            ^] and that's all.
        return otherHalf;
        
    }

    public Card DealOne()
    {
        if (_cards.Count == 0)
            throw new InvalidOperationException("No cards left in the deck.");

        var card = _cards[0];
        _cards.RemoveAt(0);
        return card;
    }
    
    public void AddCard(Card card)
    {
        _cards.Add(card);
    }
    /// <summary>
    /// A new List of Cards containing the number of cards requested
    /// OR the number of cards remaining in this Deck.
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>

    public List<Card> Deal(int count)
    {
        var dealtCards = new List<Card>();
        for (int i = 0; i < count; i++)
        {
            var card = DealOne();
           if(card is not null)
               dealtCards.Add(card);
        }
        return dealtCards;
    }

    public void AddCardsOnTop(params List<Card> cards)
        => _cards = [.. cards, .. _cards];

    public void AddCardsOnBottom(params List<Card> cards)
        => _cards = [.. _cards, .. cards];

    public void InsertCardsRandomly(Random random, params List<Card>[] cards)
    {
        var otherHalf = Cut(random);
        // _cards get the value:
        // _ cards followed by the newly added 'cards' then the second half.
        _cards = [.. _cards, ..cards, ..otherHalf._cards];
    }

    public int Count => _cards.Count;
}