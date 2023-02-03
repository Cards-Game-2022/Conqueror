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
    /// Agrega a la lista de cartas jugadas por el enemigo una nueva carta
    /// </summary>
    /// <param name="cd">carta que se añade a la lista</param>
    public void StoreCard(Card cd) {
        this.playedCards.Add(cd);
    }

    /// <summary>
    /// Algoritmo minimax para determinar que carta jugar
    /// </summary>
    /// <param name="node">nodo actual</param>
    /// <param name="prof">profundidad del arbol</param>
    /// <param name="maxProf">maxima profundidad del arbol</param>
    /// <param name="evaluate"></param>
    /// <returns>la posicion que ocupa en la mano la carta elegida</returns>
    private int Minimax(Status node, int prof, int maxProf, Func<Status, int, int> evaluate) {
        // prof : profundidad del arbol, si llego al final evalua el nodo y devuelve el valor
        if (prof == maxProf) {
            return evaluate(node, prof);
        }
        // crea las  variables relativas al nodo actual
        int pos = -1;
        int value = prof % 2 == 0 ? int.MinValue : int.MaxValue;  // para elegir o un maximo valor o un minimo

        for (int i = 0; i < node.playerStatuses[0].playerHand.Count; i++) {
            // interpreta el efecto de la carta
            Context ctx = Utils.CreateScope(node);
            Context ctxAux = Utils.CreateScope(node);

            Utils.InterpretEffect(ctx, node.playerStatuses[0].playerHand[i].Effect);
            // mueve a ese nuevo estado generado por el efecto de la carta
            node.UpdateStatus(ctx, node.playerStatuses[0].playerHand[i]);
            node.ChangePlayers();

            int response = Minimax(node, prof + 1, maxProf, evaluate);

            node.ChangePlayers();
            node.UpdateStatus(ctxAux, new Card());

            int totalEvaluate = response + evaluate(node, prof);
            // selecciona el mejor movimiento dependiendo de si es Max o Min
            if (prof % 2 == 0) {
                if (value < totalEvaluate) {
                    value = response;
                    pos = i;
                }
            } else {
                if (value > totalEvaluate) {
                    value = response;
                    pos = i;
                }
            }
        }
        // si es el nodo raiz devuelve la posicion de la carta a jugar sino es entonces devuelve el valor de ese nodo
        if (prof != 0) {
            return value;
        }
        return pos;
    }

    /// <summary>
    /// Selecciona la primera carta valida de la mano del jugador virtual
    /// </summary>
    /// <param name="playerSt">Estado actual del jugador virtual</param>
    /// <returns>La primera carta valida. Null si no se encontro ninguna valida</returns>
    private Card RandomMove(PlayerStatus playerSt) {
        foreach (Card cd in playerSt.playerHand) {
            if (Game.IsValid(cd, playerSt)) {
                return cd;
            }
        }
        return null;
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

    public override void Play(Status st, Card cd)
    {        
        st.currentCard = SelectIACard(st.StatusForIA());
    }

    public Card SelectIACard(Status IAState) {
        IAState.playerStatuses[1].playerHand = (IAState.playerStatuses[0].player as PlayerIA).playedCards;
        // delegado que devuelve la diferencia de la vida de los jugadores y el -1 es para cuando de primero esta el humano para que siga siendo negativo
        int pos = this.Minimax(IAState, 0, 4, (x, y) => (x.playerStatuses[0].life - x.playerStatuses[1].life)*(y % 2 == 0 ? 1 : - 1));
        if (pos >= 0 && pos < IAState.playerStatuses[0].playerHand.Count) {
            return IAState.playerStatuses[0].playerHand[pos];
        }
        return RandomMove(IAState.playerStatuses[0]);
    }

}