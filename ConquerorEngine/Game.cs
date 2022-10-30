namespace Conqueror.Logic;

public class Game {
    Language lg;
    public Game() {
        lg = new Language();
    }

    public void NewGame() {

    }

    public void CreateCard(string name, int cost, string text, string efect, string urlPhoto) {
        Card card = new Card(name, cost, text, efect, 0, urlPhoto);
        Database.StoreCard(card);
    }

    public void UpdateCard(int id, Card card) {

    }

    public void CreateCharacter(string name, string url) {
        Character character = new Character(name, Config.pathImageCharacters + url);

        Database.StoreCharacter(character);
    }
    public Character GetCharacter(int id) {
        Database.LoadCharacters();
        return Database.Characters[id];
    } 

    public void GetCard(int id) {

    }

    public void ActivateEfect(string efect, Player p1, Player p2, bool isP1) {
        lg.Interpreter(efect, p1, p2, isP1);
    }
}