namespace Toolkit.Rules.War;

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
            var player1 = deck.Split();
            var player2 = deck;
            var round = 0;
            while (player1.Count > 0 && player2.Count > 0 && round < 1000)
            {
                //Console.WriteLine($"Player1: {player1.Count}, Player2: {player2.Count}");
                Card card1 = player1.DealOne();
                Card card2 = player2.DealOne();
                if (card1.WarValue > card2.WarValue)
                {
                    player1.AddCard(card1);
                    player1.AddCard(card2);
                }
                else if (card2.WarValue > card1.WarValue)
                {
                    player2.AddCard(card2);
                    player2.AddCard(card1);
                }
                else
                {
                    player1.AddCard(card1);
                    player2.AddCard(card2);
                }

                round++;

            }
            Console.WriteLine(
                player1.Count > player2.Count ? "Player 1 Wins!" :
                player2.Count > player1.Count ? "Player 2 Wins!" :
                "It's a draw!"
            );
        }
    }
    
    extension(Card card)
    {
        public int WarValue => card.Value.Rank == 1 ? 14: 
        card.Value.Rank;
    }
}