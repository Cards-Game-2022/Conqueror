using System;
using Microsoft.VisualBasic.CompilerServices;
namespace Conqueror.Logic;

class PlayerHuman : Player {
    
    /// <summary>
    /// Constructor de un jugador humano
    /// </summary>
    /// <param name="name">nombre del jugador</param>
    /// <param name="urlPhoto">direccion de la foto</param>
    /// <param name="id">id del jugador</param>
    /// <returns>El nuevo jugador humano</returns>
    public PlayerHuman(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {

    }
}