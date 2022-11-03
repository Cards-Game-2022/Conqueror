using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
namespace Conqueror.Logic;

class Card {
    // no se pq pero las propiedades para el json tienen que ser de esta forma
    private string name; 
    private string urlPhoto;
    private int id;
    private int rarity;
    private int charms;
    private string text;
    private string effect;

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
    public int Rarity {
        get { return rarity; }
        set { rarity = value; }
    }
    public int Charms {
        get { return charms; }
        set { charms = value; }
    }
    public string Text {
        get { return text; }
        set { text = value; }
    }
    public string Effect {
        get { return effect; }
        set { effect = value; }
    }

    public Card() {

    }

    public Card(string name) {
        this.name = name; 
    }

    public Card(string name, string url) {
        this.name = name;
        this.urlPhoto = url; 
    }
    public Card(string name, string url, int id, int rarity, int charms, string text, string effect) {
        this.name = name;
        this.urlPhoto = url; 
        this.id = id;
        this.text = text;
        this.effect = effect;

        if (charms >= 0) {
            this.charms = charms;
        }
        else {
            Utils.Error("Valor incorrecto para charms debe ser no negativo");
        }

        if (rarity >= 0) {
            this.rarity = rarity;
        }
        else {
            Utils.Error("Valor incorrecto para rarity debe ser no negativo");
        }
    }
    
}