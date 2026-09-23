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
            Deck player1 = deck;
            Deck player2 = deck.Split();
        }
    }
}