using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System;
namespace Conqueror.Logic;

public class PlayerIA : Player {
    
    /// <summary>
    /// Constructor de un jugador virtual
    /// </summary>
    /// <param name="name">nombre del jugador</param>
    /// <param name="urlPhoto">direccion de la foto</param>
    /// <param name="id">id del jugador</param>
    /// <returns>El nuevo jugador virtual</returns>
    public PlayerIA(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {

    }
    /// <summary>
    /// Selecciona la carta que va a jugar el jugador virtual
    /// </summary>
    /// <param name="state">Estado actual del juego</param>
    /// <returns>La carta seleccionada</returns>
    public static Card SelectIACard(PlayerStatus state) {
        
        foreach (Card cd in state.playerHand) {
            if (Game.IsValid(cd, state)) {
                return cd;
            }
        }        
        return null;
    }
}