namespace Toolkit.Rules;

public static class ShuffleAlgorithm
{
    /// <summary>
    /// Shuffles the deck using the default Fisher-Yates shuffle algorithm.
    /// </summary>
    /// <param name="deck"></param>the deck to shuffle. 
    /// <param name="random"></param>the random number generator.
    public static void Default(Deck deck, Random random)
    {
        //Take every card out of the deck.
        var cards = deck.Deal(deck.Count);

        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
        
        //The deck is empty now, so top or bottom doesn't matter.
        deck.AddCardsOnBottom(cards);
    }

    public static void RiffleShuffle(Deck deck, Random random)
    {
        var left = deck.Split();   // top half
        var right = deck;          // bottom half
        List<Card> pile = [];      // empty pile to collect cards

        while (left.Count > 0 || right.Count > 0)
        {
            var card = right.DealOne();
            if (card is not null) pile.Add(card);
            
            card = left.DealOne();
            if (card is not null) pile.Add(card);
        }

        deck.AddCardsOnBottom(pile);
    }
    
}