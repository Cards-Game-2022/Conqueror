using System.Collections.Generic;
using System;
namespace Conqueror.Logic;

public abstract class Player : Character {
    
    /// <summary>
    /// Constructor de jugador
    /// </summary>
    /// <param name="name">nombre del jugador</param>
    /// <param name="urlPhoto">direccion de la foto</param>
    /// <param name="id">id del jugador</param>
    /// <returns>El nuevo jugador</returns>
    public Player(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {
        
    }

}