using System;
using Microsoft.VisualBasic.CompilerServices;
namespace Conqueror.Logic;

class PlayerHuman : Player {
    public PlayerHuman(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {

    }
    Game game = new Game();

    override public Dictionary<string, int> Launch(Dictionary<string, int> scope, List<Card> Player1Hand) {
        bool valid = game.IsValid(Pos);
        //Console.WriteLine(Pos);
        if (!valid) {
            Utils.Error("Jugada incorrecta del jugador");
        }
        return Utils.InterpretEffect(scope, Player1Hand[Pos].Effect);
    }
}