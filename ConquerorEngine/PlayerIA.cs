using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System;
namespace Conqueror.Logic;

class PlayerIA : Player {
    public PlayerIA(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {

    }

    override public Dictionary<string, int> Launch(Dictionary<string, int> scope) {
        List<Card> list = Hand.CardsList;
        int ma = int.MinValue;
        for (int i = 0; i < list.Count; i++) {
            //Console.WriteLine(list[i].Name + " " + list[i].Charms + " " + list[i].Rarity);
            if (ma < list[i].Charms && IsValid(i)) {
                ma = list[i].Charms;
                Pos = i;
            }
        }
        return Utils.InterpretEffect(scope, Hand.CardsList[Pos].Effect);
    }
}