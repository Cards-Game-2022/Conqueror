using System.Collections.Generic;

namespace Conqueror.Logic;

    public class Deck {


        public List<Card> deck;

         public Deck() {
            deck = new List<Card>();
        }        
        
       
        public List<Card> Shuffle (List<Card> deck) {

            
            int[] PositionsToShuffle = new int[deck.Count];
            Random randomGenerator = new Random();

            for(int i = 0; i < PositionsToShuffle.Length; i++) {
                
                bool Added = false;

                while(!Added) {

                    int a = randomGenerator.Next(1, deck.Count+1);

                    if(!PositionsToShuffle.Contains(a)) {
                    
                        PositionsToShuffle[i] = a;
                        Added = true;
                    }   
                
                }        
            }

            List<Card> CopiaDeck = new();
            for(int i = 0; i<deck.Count; i++)
            {
                CopiaDeck.Add(deck[i]);
            }

            for(int i=0; i < deck.Count; i++) {
                deck[i] = CopiaDeck[PositionsToShuffle[i]-1];

            }

                return deck;
        }

        public Card Draw (List<Card> deck) {

            deck = Shuffle(deck);
            return deck[0];
        
        }

        public Card Draw(List<Card> deck, Card card) {
            
            //Not all code paths return a value exception. Fix.
            
           // if(deck.Contains(card))
            return card;
           // else
           // Utils.Error("Esa carta no aparece en el deck");
        }
       
        
    }