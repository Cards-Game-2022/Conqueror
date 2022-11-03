namespace Conqueror.Logic;
 public class Player : Character {
    public int Life;
    public Player(string name, string urlPhoto, int id){
        Life = Config.basicLife;
    }
}