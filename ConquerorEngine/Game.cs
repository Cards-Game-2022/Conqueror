using System;
using Conqueror.Logic.Interpreter;
namespace Conqueror.Logic;

public class Game {
    Language lg;
    Database db;
    public Game() {
        db = new Database();

        db.LoadCards();
        db.LoadCharacters();
    }

    public void NewGame() {
    }

    public void CreateCard(string name, string text) {
        // obtengo los ultimos id, creo la nueva carta con el ultimo id + 1 y actulizo la base de datos
        Id id = db.GetLastId();

        Card card = new Card(name, text, id.Card + 1, 5, 4, "s", "1dpdadadadadadadad");
        
        db.StoreCard(card);

        db.UpdateId(id.Card + 1, id.Character);
    }

    public void UpdateCard(int id, Card card) {

    }

    public void CreateCharacter(string name, string url) {
        Character character = new Character(name, Config.pathImageCharacters + url);

        db.StoreCharacter(character);
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
}