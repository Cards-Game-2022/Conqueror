using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conqueror.Logic;

public static class Actions {
    
    /// <summary>
    /// Aumenta en 1 tus charms
    /// </summary>
    /// <param name="playerStatus">Estado del jugador al que se le aumentan los charms</param>
    public static void AddCharms(PlayerStatus playerStatus) {   
        playerStatus.charms++;
    }
    
    /// <summary>
    /// Crea un deck nuevo
    /// </summary>
    /// <param name="deck">El deck que se va a rellenar</param>
    public static void CreateDeck(List<Card> deck) {
        Manager mg = new Manager();
        foreach (Card card in mg.db.Cards) {
            for (int i = 0; i<2*card.Rarity; i++) {  
                deck.Add(card);    
            }
        }
        Shuffle(deck); //barajar el deck pero que no aparezcan todas las cartas ordenadas cuando se crea
    }
    
    /// <summary>
    /// Crea una mano nueva
    /// </summary>
    /// <param name="hand">Mano que se va a rellenar</param>
    /// <param name="deck">Deck del que se obtienen las cartas de la mano</param>
    public static void CreateHand(List<Card> hand, List<Card> deck) {
        if (deck.Count >= Config.StartingCardsCount) {
            for (int i = 0; i < Config.StartingCardsCount; i++) {  
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
    
    /// <summary>
    /// Roba una carta
    /// </summary>
    /// <param name="state">Jugador al que se le agrega la carta</param>
    public static void Draw(PlayerStatus state) {
        if (state.playerDeck.Count > 0) {
            state.playerHand.Add(state.playerDeck[0]);
            RemoveCard(state.playerDeck, state.playerDeck[0]);
        } else {
            Console.WriteLine("El deck se encuentra vacio");
        }
    }
    
    /// <summary>
    /// Roba una carta especifica de un deck/mano
    /// </summary>
    /// <param name="ListOfCards">Lugar de donde se roba la carta</param>
    /// <param name="card">Carta a robar</param>
    /// <returns></returns>
    public static Card Draw(List<Card> ListOfCards, Card card) {        
        if (ListOfCards.Contains(card)) {        
            RemoveCard(ListOfCards, card);
            return card;
        } else {
            Console.WriteLine("Esa carta no aparece en el deck");
            return null;
        }
    }
    
    /// <summary>
    /// Elimina una carta
    /// </summary>
    /// <param name="listOfCards">Lugar de donde se va a eliminar la carta</param>
    /// <param name="card">carta a eliminar</param>
    public static void RemoveCard(List<Card> listOfCards, Card card) {
        if (listOfCards.Contains(card)) {
            listOfCards.Remove(card);
        }
        else {
            Console.WriteLine("No se puede eliminar esa carta.");
        }
    }
    
    /// <summary>
    /// Barajea un grupo de cartas
    /// </summary>
    /// <param name="listOfCards">Grupo de cartas a barajar</param>
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
