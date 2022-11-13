using System;
using Conqueror.Logic.Language;
namespace Conqueror.Logic;

public class Game {
    public Player Player1;
    public Player Player2;
    private Deck Deck;
    private Manager cq;
    public Game(int level) {
        cq = new Manager();

        Deck = new Deck();
        Character c1 = cq.GetCharacter(1);
        Character c2 = cq.GetCharacter(0);
        Player1 = new PlayerHuman(c1.Name, c1.UrlPhoto, c1.Id);
        if (level == 0) {
            Player2 = new PlayerHuman(c2.Name, c2.UrlPhoto, c2.Id);

        } else {
            Player2 = new PlayerIA(c2.Name, c2.UrlPhoto, c2.Id);
        }
        
        CreateDeck(Deck.mainDeck);
        for (int i = 0; i < 5; i++) {
            Player1.Hand.AddCard(Deck.Draw(Deck.mainDeck));
            Player2.Hand.AddCard(Deck.Draw(Deck.mainDeck));
        }
    }   
    
    public void Activate() {

        Dictionary<string, int> scope;
        scope = new Dictionary<string, int>();
        scope.Add("MyLife", Player1.Life);
        scope.Add("EnemyLife", Player2.Life);
        scope.Add("MyCharms", Player1.Charms);
        scope.Add("EnemyCharms", Player2.Charms);
        scope = Player1.Launch(scope); // metodo para seleccionar la carta a jugar
        if (Player1.Pos == -1) {
            return;
        }
        Player1.Life = scope["MyLife"];
        Player2.Life = scope["EnemyLife"];
        Player1.Charms = scope["MyCharms"]- Player1.Hand.CardsList[Player1.Pos].Charms;;
        Player2.Charms = scope["EnemyCharms"];

        Player1.RemoveCard();
        Player1.ResetPos();
    }
    public void ChangePlayers() {
        Player p1 = Player1;
        Player p2 = Player2;
        Player1 = p2;
        Player2 = p1;
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
    public void DrawCard() {
        Player1.Hand.AddCard(Deck.Draw(Deck.mainDeck));
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