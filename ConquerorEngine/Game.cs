using System;
using Conqueror.Logic.Interpreter;
namespace Conqueror.Logic;

public class Game {
    Language lg;
    Database db;
    public Game() {
        
        db = new Database();

        db.LoadCards();
        //game.CreateCard("Helbrand", "1.png", 1, 1, "Una carta de prueba", "Te malanguea");
        //game.CreateCard("Prueba 2", "1.png", 2, 1, "Una carta de prueba", "Te malanguea");
        //game.CreateCard("Prueba 4", "1.png", 4, 1, "Una carta de prueba", "Te malanguea");

        CreateCharacter("David", "foto1");
        CreateCharacter("Marian", "foto2");
        

    }

    public void NewGame() {
        Deck Mazo = new Deck();

        Character C1 = GetCharacter(0);
        Character C2 = GetCharacter(1);

        db.LoadCharacters();

        Player player1 = new Player(C1.Name, C1.UrlPhoto, C1.Id);
        Player player2 = new Player(C2.Name, C2.UrlPhoto, C2.Id);


        CreateDeck(Mazo.deck);

        for(int i = 0; i < 5; i++) {
            player1.hand.AddCard(Mazo.Draw(Mazo.deck));
            player2.hand.AddCard(Mazo.Draw(Mazo.deck));
        }
        Console.WriteLine(player1.Id);
        Console.WriteLine(player2.Id);

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
        return db.Characters[id];
    } 

    public Card GetCard(int id) {
        return db.Cards[id];
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