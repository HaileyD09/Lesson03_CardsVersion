using Toolkit;
using Toolkit.Rules;
using Toolkit.Rules.War; //Behaviors: Verbs that an object /can do/ OR /have done to/ it
                        //I play war WITH a deck (an extension)
using Toolkit.Rules.BlackJack;

//go fish for hw

var random = new Random();

var myDeck = Deck.CreateStandardDeck();

// shuffle doesn't care HOW it gets done, just THAT it gets done
myDeck.Shuffle(random, ShuffleAlgorithm.Default); //method with a noun for a name - a strategy for shuffling,
                                                  //tells you how to shuffle the cards

myDeck.PlayWar(random);

myDeck.PlayBlackJack(random);
