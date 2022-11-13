using System;
using Microsoft.VisualBasic.CompilerServices;
namespace Conqueror.Logic;

class PlayerHuman : Player {
    public PlayerHuman(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {

    }

    override public Dictionary<string, int> Launch(Dictionary<string, int> scope) {
        bool valid = IsValid(Pos);
        //Console.WriteLine(Pos);
        if (!valid) {
            Utils.Error("Jugada incorrecta del jugador");
        }
        return Utils.InterpretEffect(scope, Hand.CardsList[Pos].Effect);
    }
}