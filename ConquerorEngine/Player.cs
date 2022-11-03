namespace Conqueror.Logic;
 public class Player : Character {
    public int Life;
    
    public Hand hand = new();
    public Player(string name, string urlPhoto, int id){
        
        Life = Config.basicLife;
        
        this.Name = name;
        this.UrlPhoto = urlPhoto;
        this.Id = id;
        
    }

    
}