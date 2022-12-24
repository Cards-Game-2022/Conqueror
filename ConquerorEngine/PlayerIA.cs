using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System;
using Conqueror.Logic.Language;
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
    public Card SelectIACard(Status state) {
        
        /* foreach (Card cd in state.playerHand) {
            if (Game.IsValid(cd, state)) {
                return cd;
            }
        }        
        return null; */

        // delegado que devuelve la diferencia de la vida de los jugadores y el -1 es para cuando de primero esta el humano para que siga siendo negativo
        int pos = this.Minimax(state, 0, 4, (x, y) => (x.playerStatuses[0].life - x.playerStatuses[1].life)*(y % 2 == 0 ? 1 : - 1));

        return state.playerStatuses[0].playerHand[pos];
    }

    private int Minimax(Status node, int prof, int maxProf, Func<Status, int, int> evaluate) {
        // prof : profundidad del arbol si llego a final evalua el nodo y devuelve el valor
        if (prof == maxProf) {
            return evaluate(node, prof);
        }
        // crea las  variables relativas a el nodo actual
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

}