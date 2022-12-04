using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System;
namespace Conqueror.Logic;

class PlayerIA : Player {
    public PlayerIA(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {

    }
    Game game = new Game();

    override public Dictionary<string, int> Launch(Dictionary<string, int> scope, List<Card> Player1Hand) {
        int ma = int.MinValue;
        for (int i = 0; i < Player1Hand.Count; i++) {
            //Console.WriteLine(list[i].Name + " " + list[i].Charms + " " + list[i].Rarity);
            if (ma < Player1Hand[i].Charms && game.IsValid(i)) {
                ma = Player1Hand[i].Charms;
                Pos = i;
            }
        }
        return Utils.InterpretEffect(scope, Player1Hand[Pos].Effect);
    }
}