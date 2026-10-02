using Toolkit;
using Toolkit.Rules;
using Toolkit.Rules.War; //Behaviors: Verbs that an object /can do/ OR /have done to/ it
                        //I play war WITH a deck (an extension)
using Toolkit.Rules.BlackJack;

static void Show(string label, Deck deck)
{
    var cards = deck.Deal(deck.Count);
    Console.WriteLine($"{label} ({cards.Count}):  {string.Join(" ", cards)}");
    deck.AddCardsOnTop(cards);
}

var random = new Random(42);

var myDeck = Deck.CreateStandardDeck();


Show("before", myDeck);
myDeck.Shuffle(random, ShuffleAlgorithm.RiffleShuffle);
Show("after ", myDeck);

// shuffle doesn't care HOW it gets done, just THAT it gets done
myDeck.Shuffle(random, ShuffleAlgorithm.Default); //method with a noun for a name - a strategy for shuffling,
                                                  //tells you how to shuffle the cards

//myDeck.PlayWar(random);

//myDeck.PlayBlackJack(random);

