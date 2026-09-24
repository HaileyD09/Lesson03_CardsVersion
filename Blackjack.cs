namespace Toolkit.Rules.BlackJack;

public static class BlackjackRules
{
    extension(Deck deck)
    {
        /// <summary>
        /// Play a game of BlackJack
        /// <param name = "random"> Inject your RNG here! </param>
        /// </summary>
        public void PlayBlackJack(Random random)
        {
            deck.Shuffle(random);
            Deck player1 = deck;
            Deck player2 = deck.Split();
        }
    }
    
    extension(Card card)
    {
        public int BlackjackValue => card.Value.Rank switch
        {
            1 => 11,        // Ace
            11 => 10,       // Jack
            12 => 10,       // Queen
            13 => 10,       // King
            _ => card.Value.Rank   // everything else
        };
    }
}