using System;
using Conqueror.Logic.Interpreter;
namespace Conqueror.Logic;

public class Game {
    Language lg;
    Database db;

    public Game() {
        db = new Database();

        db.InitCards();
        db.InitCharacters();
        //game.CreateCard("Helbrand", "1.png", 1, 1, "Una carta de prueba", "Te malanguea");
        //game.CreateCard("Prueba 2", "1.png", 2, 1, "Una carta de prueba", "Te malanguea");
        //game.CreateCard("Prueba 4", "1.png", 4, 1, "Una carta de prueba", "Te malanguea");

        CreateCharacter("David", "photo101.png");
        CreateCharacter("Marian", "photo104.png");
    }   

    public Player[] NewGame() {

        Deck Mazo = new Deck();
        
        Character c1 = GetCharacter(1);
        Character c2 = GetCharacter(2);

        Player player1 = new Player(c1.Name, c1.UrlPhoto, c1.Id);
        Player player2 = new Player(c2.Name, c2.UrlPhoto, c2.Id);

        CreateDeck(Mazo.deckCards);

        for (int i = 0; i < 5; i++) {
            player1.Hand.AddCard(Mazo.Draw(Mazo.deckCards));
            player2.Hand.AddCard(Mazo.Draw(Mazo.deckCards));
        }

        Player[] aux = { player1, player2 };
        return aux;
    }

    public void CreateCard(string name, string url, int rarity, int charms, string text, string effect) {
        // obtengo los ultimos id, creo la nueva carta con el ultimo id + 1 y actulizo la base de datos
        Id id = db.GetLastId();

        Card card = new Card(name, url, id.Card + 1, rarity, charms, text, effect);
        
        db.StoreCard(card);

        db.UpdateId(id.Card + 1, id.Character);
    }

    public void UpdateCard(int id, Card card) {

    }

    public void CreateCharacter(string name, string url) {
        Id id = db.GetLastId();
        
        Character character = new Character(name, Config.pathImageCharacters + "/" + url, id.Character + 1);

        db.StoreCharacter(character);
        db.UpdateId(id.Card, id.Character + 1);
    }
    
    public Character GetCharacter(int id) {  
        return db.GetCharacter(id);
    } 

    public Card GetCard(int id) {  
        return db.GetCard(id);
    } 

    public void ActivateEffect(string effect, Player p1, Player p2, bool isP1) {
        Lexer lexer = new Lexer(effect); 
        Console.WriteLine(lg.Expr());

        //lg.Interpreter(effect, p1, p2, isP1);
    }

    public void CreateDeck(List<Card> deck) {
        foreach(Card card in db.Cards){
            for(int i = 0; i<card.Rarity; i++) {  
                deck.Add(card);    
            }
        }
    }
}