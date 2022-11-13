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
    public Hand Hand {
        get; set;
    }
    public int Pos;
    public Player(string name, string urlPhoto, int id) : base(name, urlPhoto, id){
        Life = Config.BasicLife;
        Charms = Config.Charms;
        Hand = new Hand();
        Pos = -1;
    }

    public Player(Player p) : base(p.Name, p.UrlPhoto, p.Id) {
        Life = p.Life;
        Charms = p.Charms;
        Hand = p.Hand;
        Pos = -1;
    }
    abstract public Dictionary<string, int> Launch(Dictionary<string, int> scope); // metodo que selecciona la carta a lanzar

    public bool IsValid(int pos) {
        if (pos >= 0) {
            if (Hand.CardsList.Count > pos && Hand.CardsList[pos].Charms <= Charms) {
                return true;
            }
        }
        return false;
    }
    public void ResetPos() {
        Pos = -1;
    }
    public void RemoveCard() {
        Hand.CardsList.RemoveAt(Pos);
    }
}