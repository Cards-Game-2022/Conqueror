using System.Collections.Generic;
namespace Conqueror.Logic;

class Character {
    private string name; 
    private string urlPhoto;
    private int id;

    public string Name {
        get { return name; }
        set { name = value; }
    }
    public string UrlPhoto {
        get { return urlPhoto; }
        set { urlPhoto = value; }
    }
    public int Id {
        get { return id; }
        set { id = value; }
    }

    public Character() {

    }

    public Character(string name) {
        this.name = name; 
    }

    public Character(string name, string url) {
        this.name = name;
        this.urlPhoto = url; 
    }
    public Character(string name, string url, int id) {
        this.name = name;
        this.urlPhoto = url; 
        this.id = id;
    }
}