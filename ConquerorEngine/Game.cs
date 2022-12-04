using System;
using Conqueror.Logic.Language;
namespace Conqueror.Logic;

public class Game {
    public static Player Player1;
    public static Player Player2;
    public static List<Card> Player1Deck = new();
    public static List<Card> Player2Deck = new();
    public static List<Card> Player1Hand = new();
    public static List<Card> Player2Hand = new();

    private Manager cq;

    public Game(){

    }
    public Game(int level) {
        cq = new Manager();

        Character c1 = cq.GetCharacter(1);
        Character c2 = cq.GetCharacter(0);
        Player1 = new PlayerHuman(c1.Name, c1.UrlPhoto, c1.Id);
        if (level == 0) {
            Player2 = new PlayerHuman(c2.Name, c2.UrlPhoto, c2.Id);

        } else {
            Player2 = new PlayerIA(c2.Name, c2.UrlPhoto, c2.Id);
        }
        
        CreateDeck(Player1Deck);
        CreateDeck(Player2Deck);
        for (int i = 0; i < 5; i++) {
            Player1Hand.Add(ListOfCards.Draw(Player1Deck));
            Player2Hand.Add(ListOfCards.Draw(Player2Deck));
        }

    }      
    public void Activate() {

        Dictionary<string, int> scope;
        scope = new Dictionary<string, int>();
        scope.Add("MyLife", Player1.Life);
        scope.Add("EnemyLife", Player2.Life);
        scope.Add("MyCharms", Player1.Charms);
        scope.Add("EnemyCharms", Player2.Charms);
        scope = Player1.Launch(scope, Player1Hand); // metodo para seleccionar la carta a jugar
        if (Player1.Pos == -1) {
            return;
        }
        Player1.Life = scope["MyLife"];
        Player2.Life = scope["EnemyLife"];
        Player1.Charms = scope["MyCharms"] - Player1Hand[Player1.Pos].Charms;
        Player2.Charms = scope["EnemyCharms"];

        Player1.RemoveCard(Player1Hand);
        Player1.ResetPos();
    }
    public void ChangePlayers() {
        Player p1 = Player1;
        Player p2 = Player2;
        Player1 = p2;
        Player2 = p1;

        List<Card> deck1 = Player1Deck;
        List<Card> deck2 = Player2Deck;
        Player1Deck = deck2;
        Player2Deck = deck1;

        List<Card> hand1 = Player1Hand;
        List<Card> hand2 = Player2Hand;
        Player1Hand = hand2;
        Player2Hand = hand1;


    }
    public string IsGameEnd() {
        if (Player1.Life <= 0 && Player2.Life <= 0) {
            return "Ninguno";
        } else {
            if (Player1.Life <= 0) {
                return Player2.Name;
            } 
            if (Player2.Life <= 0) { 
                return Player1.Name;
            }
        }
        return null;
    }
    public void AddCharms() {   
        Player1.Charms ++;
    }
    public void CreateDeck(List<Card> deck) {
        foreach(Card card in cq.db.Cards){
            for(int i = 0; i<card.Rarity; i++) {  
                deck.Add(card);    
            }
        }
    }
    public bool IsValid(int pos) {
        if (pos >= 0) {
            if (Player1Hand.Count > pos && Player1Hand[pos].Charms <= Player1.Charms) {
                return true;
            }
        }
        return false;
    }    
    
    public void DrawCard() {
        Player1Hand.Add(ListOfCards.Draw(Player1Deck));
    }
    /*
    TODO: Hacer que cuando se active una carta, se verifique si se puede
          poner por los charms. Si no se puede, mostrar error.
    TODO: Editar el cartel del ganador
    TODO: Hacer una IA que ataque por la carta mas fuerte
    TODO: Hacer muchas mas cartas == Hacer mas metodos
    TODO: Buscar un gif para el efecto de daño
    TODO: Poner un cuadrito con la carta que se jugo y un tiempo de espera
          para cuando este jugando la IA
    TODO: Crear un mazo para cada player    
    */
}