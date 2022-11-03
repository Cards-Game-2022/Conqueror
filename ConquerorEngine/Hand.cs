using System.Collections.Generic;

namespace Conqueror.Logic;

public class Hand {
    
        //Almacena las cartas
        public List<Card> hand;
    
    
        public Hand() {
            hand = new List<Card>();
        }
    
        public void AddCard(Card card) {
            
            hand.Add(card);
            
        }
    
        public void RemoveCard(Card card) {
            
            if(card.Id >= 0 && card.Id < hand.Count) {
                hand.Remove(card);
            }
        }
    
    
}