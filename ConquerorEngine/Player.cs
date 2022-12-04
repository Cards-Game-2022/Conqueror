using System.Collections.Generic;
using System;
namespace Conqueror.Logic;

public abstract class Player : Character {
    public int Life {
        get; set;
    }
    public int Charms {
        get; set;
    }

    public int Pos;
    public Player(string name, string urlPhoto, int id) : base(name, urlPhoto, id){
        Life = Config.BasicLife;
        Charms = Config.Charms;
        Pos = -1;
    }

    public Player(Player p) : base(p.Name, p.UrlPhoto, p.Id) {
        Life = p.Life;
        Charms = p.Charms;
        Pos = -1;
    }
    abstract public Dictionary<string, int> Launch(Dictionary<string, int> scope, List<Card> Player1Hand); // metodo que selecciona la carta a lanzar


    public void ResetPos() {
        Pos = -1;
    }
    public void RemoveCard(List<Card> Player1Hand) {
        Player1Hand.RemoveAt(Pos);
    }
}