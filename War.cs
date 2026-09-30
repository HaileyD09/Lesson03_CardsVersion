namespace Toolkit.Rules.War;

//finish writing code
public static class WarRules
{
    extension(Deck deck)
    {
        /// <summary>
        /// Play a game of War
        /// <param name = "random"> Inject your RNG here! </param>
        /// </summary>
        public void PlayWar(Random random)
        {
            deck.Shuffle(random);
            Deck player1 = deck.Split();
            Deck player2 = deck;
            while (player1.Count > 0 && player2.Count > 0)
            {
                Card card1 = player1.DealOne();
                Card card2 = player2.DealOne();
                if (card1.WarValue > card2.WarValue)
                {
                    player1.AddCard(card1);
                }
                else if (card2.WarValue > card1.WarValue)
                {
                    player1.AddCard(card2);
                }
                
            }
        }
    }
    
    extension(Card card)
    {
        public int WarValue => card.Value.Rank == 1 ? 14: 
        card.Value.Rank;
    }
}