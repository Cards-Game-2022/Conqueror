using System.Collections.Generic;

namespace Conqueror.Logic;

public class Hand {
    
        //Almacena los ids de las cartas
        public static List<int> hand;
    
    
        public Hand() {
            hand = new List<int>();
        }
    
        public static void AddCard(List<Card> deck) {
            
            hand.Add(Deck.Draw(deck).Id);
            
        }
    
        public static void RemoveCard(int id) {
            
            try{
            hand.Remove(id);
            }
            catch{}
        }
    
    
}