using System.Collections.Generic;

namespace Conqueror.Logic;

public class Hand {
    public List<Card> handCards;
    
        public Hand() {
            handCards = new List<Card>();
        }
    
        public void AddCard(Card card) {
            handCards.Add(card);
        }
    
        public void RemoveCard(Card card) {
            if(card.Id >= 0) {
                foreach(Card item in handCards){
                    if(item.Id == card.Id){
                        handCards.Remove(item);
                    }
                }
            }
        }

    //TODO: Fix this. Recieves player and player hand.
    //TODO: Should be in class Card
    //TODO: Remove Card should be in class Hand.
        public void InvoqueCard(Card card) {
           //Card.ActivateEffect(card);
            RemoveCard(card);
            
        }
        
}