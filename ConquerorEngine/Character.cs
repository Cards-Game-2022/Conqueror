using System.Collections.Generic;
namespace Conqueror.Logic;

public class Character {
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

    /// <summary>
    /// Constructor de personaje
    /// </summary>
    /// <param name="name">nombre del personaje</param>
    /// <param name="url">direccion de la foto</param>
    /// <param name="id">identificador del personaje</param>
    public Character(string name, string url, int id) {
        this.name = name;
        this.urlPhoto = url; 
        this.id = id;
    }
}