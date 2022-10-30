using System.Collections.Generic;

namespace Conqueror.Logic;

    static class Deck {

        static List<Card> deck;

        static private void Shuffle (List<Card> deck) {

            

        }

        static public Card Draw (List<Card> deck) {

            Shuffle(deck);
            return deck[0];
        
        }
       
    }
    
