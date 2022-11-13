using System.Collections.Generic;

namespace Conqueror.Logic;

public class Deck {
    public List<Card> mainDeck;

    public Deck() {
        mainDeck = new List<Card>();
    }        
    
    public List<Card> Shuffle (List<Card> listOfCards) {

        int[] shuffledPositions = new int[listOfCards.Count];
        Random randomGenerator = new Random();

        for (int i = 0; i < shuffledPositions.Length; i++) { 
            bool added = false;

            while (!added) {
                int randomNumber = randomGenerator.Next(1, listOfCards.Count + 1);

                if (!shuffledPositions.Contains(randomNumber)) {
                    shuffledPositions[i] = randomNumber;
                    added = true;
                }   
            }        
        }

        List<Card> copiedList = new();

        for (int i = 0; i < listOfCards.Count; i++) {
            copiedList.Add(listOfCards[i]);
        }
        for (int i = 0; i < listOfCards.Count; i++) {
            listOfCards[i] = copiedList[shuffledPositions[i] - 1];
        }

        return listOfCards;
    }

    public Card Draw (List<Card> deck) {

        deck = Shuffle(deck);
        return deck[0];
    }

    public Card Draw(List<Card> deck, Card card) {
        
        if (deck.Contains(card))
            return card;
        else {
            Utils.Error("Esa carta no aparece en el deck");
            return null;
        }
    }
}