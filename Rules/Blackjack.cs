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
            deck.Shuffle(random, ShuffleAlgorithm.Default);
            var playerHand = deck.Deal(2);
            var dealerHand = deck.Deal(2);
            Console.WriteLine($"Your hand: {string.Join(", ", playerHand)}");
            Console.WriteLine($"Dealer shows: {dealerHand[0]}");
            var playerTotal = playerHand.Sum(card => card.BlackjackValue);
            while (playerTotal > 21 && playerHand.Any(card => card.Value.Rank == 1))
            {
                playerTotal -= 10;
            }
            var dealerTotal = dealerHand.Sum(card => card.BlackjackValue);
            while (dealerTotal > 21 && dealerHand.Any(card => card.Value.Rank == 1))
            {
                dealerTotal -= 10;
            }
            Console.WriteLine($"Your total: {playerTotal}");
            
            var input = "h";
            while (input == "h" && playerTotal <= 21)
            {
                Console.WriteLine("Hit or Stand? (h/s)");
                input = Console.ReadLine();
                while (input != "h" && input != "s")
                {
                    Console.WriteLine("Invalid input! Please enter 'h' or 's'.");
                    input = Console.ReadLine();
                }
                
                if (input == "h")
                {
                    var newCard = deck.DealOne();         // deal one card
                    playerHand.Add(newCard);            // add it to the hand
                    playerTotal = playerHand.Sum(card => card.BlackjackValue);  // recalculate total
                    while (playerTotal > 21 && playerHand.Any(card => card.Value.Rank == 1))
                    {
                        playerTotal -= 10;
                    }
                    Console.WriteLine($"You drew: {newCard}");
                    Console.WriteLine($"Your total: {playerTotal}");
                    
                }
                
            }
            
            if (playerTotal > 21)
            {
                Console.WriteLine("Bust! You Lose!");
            }
            else
            {
                Console.WriteLine("Your final total: " + playerTotal);
                
                while (dealerTotal < 17)
                {
                    var newCard = deck.DealOne();
                    dealerHand.Add(newCard);
                    dealerTotal = dealerHand.Sum(card => card.BlackjackValue);
                    while (dealerTotal > 21 && dealerHand.Any(card => card.Value.Rank == 1))
                    {
                        dealerTotal -= 10;
                    }
                    Console.WriteLine($"Dealer drew: {newCard}");
                }
                Console.WriteLine("Dealer's total: " + dealerTotal);  
                
                if (dealerTotal > 21)
                {
                    Console.WriteLine("Dealer Busts. You Won!");
                }
                else if (playerTotal > dealerTotal)
                {
                    Console.WriteLine("Dealer's Total: " + dealerTotal);
                    Console.WriteLine("You Won!");
                }
                else if (dealerTotal > playerTotal)
                {
                    Console.WriteLine("Dealer's Total: " + dealerTotal);
                    Console.WriteLine("You Lost.");
                }
                else
                {
                    Console.WriteLine("It's a Tie!");
                }
            }
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