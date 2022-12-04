namespace Conqueror.Logic;

public class Manager {
    public Database db;
    public Manager() {
        db = new Database();
        db.InitCards();
        db.InitCharacters();
    }
    public void CreateCard(string name, string url, int rarity, int charms, string text, string effect) {
        // obtengo los ultimos id, creo la nueva carta con el ultimo id + 1 y actulizo la base de datos
        Utils.InterpretEffect(Utils.CreateScope(), effect);
        Id id = db.GetLastId();

        Card card = new Card(name, url, id.Card + 1, rarity, charms, text, effect);
        
        db.StoreCard(card);

        db.UpdateId(id.Card + 1, id.Character);
    }

    public void UpdateCard(int id, Card card) {

    }

    public void CreateCharacter(string name, string url) {
        Id id = db.GetLastId();
        
        Character character = new Character(name, Config.PathImageCharacters + "/" + url, id.Character + 1);

        db.StoreCharacter(character);
        db.UpdateId(id.Card, id.Character + 1);
    }
    
    public Character GetCharacter(int id) {  
        return db.GetCharacter(id);
    } 

    public Card GetCard(int id) {  
        return db.GetCard(id);
    } 
}