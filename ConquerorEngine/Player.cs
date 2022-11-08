namespace Conqueror.Logic;
public class Player : Character {
    public int Life;
    public int Charms;
    public Hand Hand;

    public Player() {
        Hand = new Hand();
    }
    public Player(string name, string urlPhoto, int id) {        
        Life = Config.basicLife;
        Charms = Config.charms;
        Hand = new Hand();

        this.Name = name;
        this.UrlPhoto = urlPhoto;
        this.Id = id;
    }   
}