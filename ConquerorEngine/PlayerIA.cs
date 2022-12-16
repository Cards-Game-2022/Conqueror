using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System;
namespace Conqueror.Logic;

public class PlayerIA : Player {
    public PlayerIA(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {

    }
    
    override public Dictionary<string, int> Launch(Card card, Dictionary<string, int> scope, List<Card> playerHand) {
        
        if (card != null) {        
            Actions.RemoveCard(card, playerHand);
            return Utils.InterpretEffect(scope, card.Effect);
        }        
        else {
            Utils.Error("Accion invalida");
            return null;
        }
    }
    public static Card SelectIACard(PlayerStatus state) {
        
        foreach (Card cd in state.playerHand) {
            if (Game.IsValid(cd, state)) {
                return cd;
            }
        }
        return null;
    }
}