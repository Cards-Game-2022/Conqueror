using System.Collections.Generic;
namespace Conqueror.Logic;

public class Character {
    private string name; 
    private string urlPhoto;
    private int id;

    public string Name {
        get; private set;
    }
    public string UrlPhoto {
         get; private set;
    }
    public int Id {
        get; private set;
    }

    public Character(string name, int id) {
        this.name = name; 
        this.id = id;
        
    }

    public Character(string name, int id, string url) {
        this.name = name;
        this.id = id;
        this.urlPhoto = url; 
        
    }
}