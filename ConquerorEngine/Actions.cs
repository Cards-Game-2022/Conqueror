using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conqueror.Logic;

public static class Actions {
    public static void AddCharms(PlayerStatus playerStatus) {   
        playerStatus.charms++;
    }
    public static void ReduceCharms(PlayerStatus playerStatus) {
        if (playerStatus.charms > 0) {
            playerStatus.charms--;
        }
        else {
            Utils.Error("No se pueden disminuir los charms");
        }
    }
    public static void CreateDeck(List<Card> deck) {
        Manager mg = new Manager();
        foreach (Card card in mg.db.Cards) {
            for (int i = 0; i<2*card.Rarity; i++) {  
                deck.Add(card);    
            }
        }
        Shuffle(deck); //barajar el deck pero que no aparezcan todas las cartas ordenadas cuando se crea
    }
    public static void CreateHand(List<Card> hand, List<Card> deck) {
        if (deck.Count >= 5) {
            for (int i = 0; i<5; i++) {  
                hand.Add(deck[0]);
                deck.Remove(deck[0]);   
            }
        }
        else {
            foreach (Card card in deck) {
                hand.Add(card);
            }
            deck.Clear();
        }
    }
    public static void Draw(PlayerStatus state) {
        if (state.playerDeck.Count > 0) {
            state.playerHand.Add(state.playerDeck[0]);
            RemoveCard(state.playerDeck[0], state.playerDeck);
        } else {
            Utils.Error("El deck se encuentra vacio");
        }
    }
    public static Card Draw(List<Card> deck, Card card) {        
        if (deck.Contains(card)) {        
            RemoveCard(card, deck);
            return card;
        } else {
            Utils.Error("Esa carta no aparece en el deck");
            return null;
        }
    }
    public static void RemoveCard(Card card, List<Card> listOfCards) {
        if (listOfCards.Contains(card)) {
            listOfCards.Remove(card);
        }
        else {
            Utils.Error("No se puede eliminar esa carta.");
        }
    }
    public static void Shuffle(List<Card> listOfCards) {

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
    }
}
