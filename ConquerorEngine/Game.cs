namespace Conqueror.Logic;

public class Game {
    Language lg;
    public Game() {
        lg = new Language();
    }

    public void NewGame() {



        //Database.LoadCards();
        //Añadir 5 cartas a la mano del jugador cuando se crea
        List<int> hand1 = new();
        List<int> hand2 = new();
        for(int i = 0; i<5; i++)
        {
            hand1.Add(Deck.Draw(Deck.deck).Id);
            hand2.Add(Deck.Draw(Deck.deck).Id);
        }
        Player player1 = new Player("Andres", 1, hand1);
        Player player2 = new Player("Manolo", 2, hand2);

    }

    public void CreateCard(string name, int cost, string text, string effect, string urlPhoto) {

        //GetLastCardId
        //int newId = LastCardId + 1
        int newId = 0;
        Card card = new Card(name, cost, newId, 1, text, effect, urlPhoto);
        Database.StoreCard(card);
    }

      public void CreateCard(string name, int cost, int newId, string text, string effect, string urlPhoto) {

        //GetLastCardId
        //int newId = LastCardId + 1
        Card card = new Card(name, cost, newId, 1, text, effect, urlPhoto);
        Database.StoreCard(card);
    }


    public void UpdateCard(int id, Card card) {

    }

    public void CreateCharacter(string name, string url) {
        
        Character character = new Character(name, 0, Config.pathImageCharacters + url);

        Database.StoreCharacter(character);
    }
    public Character GetCharacter(int id) {
        
        Database.LoadCharacters();
        return Database.Characters[id];
    } 

    public void GetCard(int id) {

    }

    public void ActivateEffect(string effect, Player p1, Player p2, bool isP1) {
        lg.Interpreter(effect, p1, p2, isP1);
    }
}