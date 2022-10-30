using System.Collections.Generic;

namespace Conqueror.Logic;

class Hand {
    
        public List<Card> hand;
    
    
        public Hand() {
            hand = new List<Card>();
        }
    
        public void AddCard(List<Card> deck) {
            hand.Add(Deck.Draw(deck));
            
        }
    
        public void RemoveCard(int id) {
           // hand.Remove(hand.id);
        }
    
    
}