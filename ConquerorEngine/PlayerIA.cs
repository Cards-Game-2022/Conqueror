using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System;
using Conqueror.Logic.Language;
namespace Conqueror.Logic;

public class PlayerIA : Player {

    /// <summary>
    /// Cartas jugadas por el enemigo del jugador virtual
    /// </summary>
    private List<Card> playedCards = new();
    
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
    /// El jugador virtual elige su carta
    /// </summary>
    /// <param name="st">estado actual del juego</param>
    /// <param name="cd">null</param>
    public override void Play(Status st, Card cd)
    {        
        st.currentCard = SelectIACard(st.StatusForIA());
    }

    /// <summary>
    /// Selecciona la carta que va a jugar el jugador virtual
    /// </summary>
    /// <param name="IAState">estado con restricciones</param>
    /// <returns>la carta que selecciono el jugador virtual</returns>
    public Card SelectIACard(Status IAState) {

        Random generator = new Random();        
        int choice = generator.Next(4);
        Card selected = null;

        switch(choice)
        {
            case 0: selected = Strategies.StrongestCard(IAState);
            break;

            case 1: selected = Strategies.Minimax(IAState, playedCards);
            break;

            case 2: selected = Strategies.HealerCard(IAState);
            break;

            case 3: selected = Strategies.RandomMove(IAState.playerStatuses[0]);
            break;

            default: Utils.Error("Hubo un error grave");
            break;
        }
        return selected;
    }

    /// <summary>
    /// Agrega a la lista de cartas jugadas por el enemigo una nueva carta
    /// </summary>
    /// <param name="cd">carta que se añade a la lista</param>
    public void StoreCard(Card cd) {
        this.playedCards.Add(cd);
    }
    
    /// <summary>
    /// Clona el estado del juego del jugador virtual por copia
    /// </summary>
    /// <returns>Una copia del estado de juego del jugador virtual</returns>
    public PlayerIA Clone() {
        PlayerIA copy = new(this.Name, this.UrlPhoto, this.Id);
        foreach(Card cd in this.playedCards) {
            copy.playedCards.Add(cd);
        }
        return copy;        
    }

}

 
