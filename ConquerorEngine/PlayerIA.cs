using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System;
namespace Conqueror.Logic;

public class PlayerIA : Player {
    public PlayerIA(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {

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