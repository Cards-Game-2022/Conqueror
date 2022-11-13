using System.Collections.Generic;

namespace Conqueror.Logic;

public class Hand {
        public List<Card> CardsList;
    
        public Hand() {
            CardsList = new List<Card>();
        }
    
        public void AddCard(Card card) {
            CardsList.Add(card);
        }
    
        public void RemoveCard(Card card) {
            if(card.Id >= 0 && card.Id < CardsList.Count) {
                CardsList.Remove(card);
            }
        }
}