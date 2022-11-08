using System.Collections.Generic;

namespace Conqueror.Logic;

public class Deck {
    public List<Card> deckCards;

    public Deck() {
        deckCards = new List<Card>();
    }        
    
    public List<Card> Shuffle (List<Card> deck) {
        // TODO: los nombres de las variables deberian comenzar por minusculas, mezclas unas mayusculas y otras minusculas
        // TODO: randomGenerator -> Yes
        // TODO: PositionsToShuffle, CopiaDeck, Added -> No
        // TODO: a -> No, es poco descriptivo, una sola letra solo se debe usar para los "loops" (for, while, ...)
        // TODO: y personalmente creo que PositionsToShuffle y randomGenerator son innecesariamente largos
        int[] positionsToShuffle = new int[deck.Count];
        Random randomGenerator = new Random();

        for (int i = 0; i < positionsToShuffle.Length; i++) { 
            
            bool added = false;

            while(!added) {
                int randomNumber = randomGenerator.Next(1, deck.Count + 1);

                if(!positionsToShuffle.Contains(randomNumber)) {
                    positionsToShuffle[i] = randomNumber;
                    added = true;
                }   
            }        
        }

        List<Card> copiaDeck = new();

        for (int i = 0; i < deck.Count; i++) {
            copiaDeck.Add(deck[i]);
        }

        for (int i = 0; i < deck.Count; i++) {
            deck[i] = copiaDeck[positionsToShuffle[i] - 1];
        }

        return deck;
    }

    //Para tomar la primera carta del mazo.
    public Card Draw (List<Card> deck) {
        deck = Shuffle(deck);

        return deck[0];
    }

    //Para cuando pide robar una carta en especifico.
    public Card Draw (List<Card> deck, Card card) {
        
        if(deck.Contains(card))
            return card;
        else
            Utils.Error("Esa carta no aparece en el deck");
        
        return null;
    }
}