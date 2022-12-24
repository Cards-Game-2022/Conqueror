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
    public static Card SelectIACard(PlayerStatus state) {
        
        foreach (Card cd in state.playerHand) {
            if (Game.IsValid(cd, state)) {
                return cd;
            }
        }        
        return null;
    }

    public void Launch(Context context, List<PlayerStatus> playerStatuses) {
        List<Card> list = playerStatuses[0].playerHand;
        int ma = int.MinValue;
        Node node = new Node(playerStatuses[0].life, context.GetValue("EnemyLife"), playerStatuses[0].charms, context.GetValue("EnemyCharms"), playerStatuses[0].playerHand, playerStatuses[0].playerHand);
        int pos = Minimax(node, 0, playerStatuses[0].playerHand, (Node node) => node.MyLife - node.EnemyLife);
        if (pos == -1) {
            Utils.Error("No se puede lanzar ninguna carta");
        }
        Console.WriteLine(pos);
        Utils.InterpretEffect(context, playerStatuses[0].playerHand[pos].Effect);
    }

    private int Minimax(Node node, int prof, int maxProf, List<Card> enemyCards, Func<Node, int> evaluate) {
        // prof : profundidad del arbol. Si llego al final evalua el nodo y devuelve el valor
        if (prof == maxProf) {
            Console.WriteLine(node.EnemyLife);
            return evaluate(node);
        }
        // crea las  variables relativas al nodo actual
        int pos = -1;
        int value = prof % 2 == 0 ? int.MinValue : int.MaxValue; 
        List<Card> cards =  prof % 2 == 0 ? node.MyCards : enemyCards;
        int myLife = prof % 2 == 0 ? node.EnemyLife : node.MyLife;
        int myCharms = prof % 2 == 0 ? node.EnemyLife : node.MyCharms;
        int enemyLife = prof % 2 == 0 ? node.EnemyLife : node.EnemyLife;
        int enemyCharms = prof % 2 == 0 ? node.EnemyLife : node.EnemyCharms;
        int myCards = prof % 2 == 0 ? node.EnemyLife : node.MyCards.Count;

        for (int i = 0; i < cards.Count; i++) {
            // interpreta el efecto de la carta
            Context ctx = new Context();
            ctx.Add(new Token("INT", "MyLife"), myLife);
            ctx.Add(new Token("INT", "EnemyLife"), enemyLife);
            ctx.Add(new Token("INT", "MyCharms"), myCharms);
            ctx.Add(new Token("INT", "EnemyCharms"), enemyCharms);
            ctx.Add(new Token("CONST", "CantMyCards"), myCards);

            Utils.InterpretEffect(ctx, cards[i].Effect);
            Node aux = new Node(ctx.GetValue("MyLife"), ctx.GetValue("EnemyLife"), ctx.GetValue("MyCharms"), ctx.GetValue("EnemyCharms"), node.MyCards, node.EnemyCards);

            // mueve a ese nuevo estado generado por el efecto de la carta
            int response = Minimax(aux, prof + 1, maxProf, enemyCards, evaluate);
            // selecciona el mejor movimiento dependiendo de si es Max o Min
            if (prof % 2 == 0) {
                if (value < response) {
                    value = response;
                    pos = i;
                }
            } else {
                if (value > response) {
                    value = response;
                    pos = i;
                }
            }
        }
        // si es el nodo raiz devuelve la posicion de la carta a jugar 
        //sino es entonces devuelve el valor de ese nodo
        if (pos != 0) {
            return value;
        }
        return pos;
    }
}