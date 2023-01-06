using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
namespace Conqueror.Logic;

public class Card {
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
    
    /// <summary>
    /// Constructor de carta
    /// </summary>
    /// <param name="name">nombre de la carta</param>
    /// <param name="url">direccion de la foto</param>
    /// <param name="id">identificador de la carta</param>
    /// <param name="rarity">rareza de la carta</param>
    /// <param name="charms">charms que cuesta la carta</param>
    /// <param name="text">descripcion de la carta</param>
    /// <param name="effect">efecto de la carta en codigo</param>
    public Card(string name, string url, int id, int rarity, int charms, string text, string effect) {
        this.name = name;
        this.urlPhoto = url; 
        this.id = id;
        this.text = text;
        this.effect = effect;

        if (charms >= 0) {
            this.charms = charms;
        } else {
            Utils.Error("Valor incorrecto para charms. Debe ser no negativo");
        }

        if (rarity >= 0) {
            this.rarity = rarity;
        } else {
            Utils.Error("Valor incorrecto para rarity. Debe ser no negativo");
        }

        if (this.urlPhoto == null || this.urlPhoto == "") {
            this.urlPhoto = Config.pathCardsImage;
        }
    }
    
}