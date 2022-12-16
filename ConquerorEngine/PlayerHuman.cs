using System;
using Microsoft.VisualBasic.CompilerServices;
namespace Conqueror.Logic;

class PlayerHuman : Player {
    public PlayerHuman(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {

    }
    override public Dictionary<string, int> Launch(Card card, Dictionary<string, int> scope, List<Card> playerHand) {
        //bool valid = game.IsValid(Pos);
        //Console.WriteLine(Pos);
       // if (!valid) {
         //   Utils.Error("Jugada incorrecta del jugador");
        //}
        
        Actions.RemoveCard(card, playerHand);
        return Utils.InterpretEffect(scope, card.Effect);
    }
}