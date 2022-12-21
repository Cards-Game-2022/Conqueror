using System.Collections.Generic;
using System;
namespace Conqueror.Logic;

public abstract class Player : Character {
    
    public Player(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {
        
    }

}