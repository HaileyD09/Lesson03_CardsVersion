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
    /// <summary>
    /// What the hands do:
    /// split in two,
    /// - interleave cards one at a time weighted by how many cards remain in each half,
    /// - push together
    /// Which lines match which step:
    /// Step 1: Split()
    /// Step 2: the while loop with random.Next(total)
    /// Step 3: AddCardsOnBottom(pile) 
    /// One place the code differs from a person:
    /// a real person can't calculate exact probabilities -- they just feel which thumb has more cards.
    /// The code uses random.Next(total) to weight the drop mathematically.
    /// </summary>
    /// <param name="deck"></param>
    /// <param name="random"></param>

    public static void RiffleShuffle(Deck deck, Random random)
    {
        var left = deck.Split();   // top half
        var right = deck;          // bottom half
        List<Card> pile = [];      // empty pile to collect cards

        while (left.Count > 0 || right.Count > 0)
        {
            var total = right.Count + left.Count;
            var pick = random.Next(total);

            if (pick < right.Count)
            {
                var card = right.DealOne();
                if (card is not null) pile.Add(card);
            }
            else
            {
                var card = left.DealOne();
                if (card is not null) pile.Add(card);
            }
        
        }

        deck.AddCardsOnBottom(pile);
    }
    
}