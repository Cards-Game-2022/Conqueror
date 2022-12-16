using System.Collections.Generic;
using System;
namespace Conqueror.Logic;

public abstract class Player : Character {
    
    public Player(string name, string urlPhoto, int id) : base(name, urlPhoto, id) {
        
    }
    abstract public Dictionary<string, int> Launch(Card card, Dictionary<string, int> scope, List<Card> playerHand); // metodo que selecciona la carta a lanzar

}