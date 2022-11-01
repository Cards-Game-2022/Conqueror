namespace Conqueror.Logic;
public class Player : Character {
    public int Life;
    public Hand Hand;

    //TODO: Set Hand for player.
    public Player(string name, int id, List<int> hand) : base(name, id){
        Life = Config.basicLife;
        

    }

    public Player(string name, int id, string url) : base(name, id, url){
        Life = Config.basicLife;
    }
}