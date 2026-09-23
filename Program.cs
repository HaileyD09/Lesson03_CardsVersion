using Toolkit; 
using Toolkit.Rules.War; //Behaviors: Verbs that an object /can do/ OR /have done to/ it
                        //I play war WITH a deck (an extension)

//go fish for hw

var random = new Random();

var myDeck = Deck.CreateStandardDeck();

myDeck.Shuffle(random);

myDeck.PlayWar(random);
