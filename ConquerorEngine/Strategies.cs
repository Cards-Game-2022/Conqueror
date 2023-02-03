using Conqueror.Logic.Language;
namespace Conqueror.Logic;

public static class Strategies {

    /// <summary>
    /// Portal al minimax
    /// </summary>
    /// <param name="IAState">Estado con restricciones</param>
    /// <param name="playedCards">cartas jugadas</param>
    /// <returns></returns>
    public static Card Minimax(Status IAState, List<Card> playedCards)
    {
        IAState.playerStatuses[1].playerHand = playedCards;
        // delegado que devuelve la diferencia de la vida de los jugadores y el -1 es para cuando de primero esta el humano para que siga siendo negativo
        int pos = Minimax(IAState, 0, 4, (x, y) => (x.playerStatuses[0].life - x.playerStatuses[1].life)*(y % 2 == 0 ? 1 : - 1));
        if (pos >= 0 && pos < IAState.playerStatuses[0].playerHand.Count) {
            return IAState.playerStatuses[0].playerHand[pos];
        }
        return null;
    }
    
    /// <summary>
    /// Algoritmo minimax para determinar que carta jugar
    /// </summary>
    /// <param name="node">nodo actual</param>
    /// <param name="prof">profundidad del arbol</param>
    /// <param name="maxProf">maxima profundidad del arbol</param>
    /// <param name="evaluate"></param>
    /// <returns>la posicion que ocupa en la mano la carta elegida</returns>
    private static int Minimax(Status node, int prof, int maxProf, Func<Status, int, int> evaluate) {
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
    public static Card RandomMove(PlayerStatus playerSt) {
        foreach (Card cd in playerSt.playerHand) {
            if (Game.IsValid(cd, playerSt)) {
                return cd;
            }
        }
        return null;
    }

    /// <summary>
    /// Selecciona la carta mas fuerte
    /// </summary>
    /// <param name="IAState">Estado del juego con restricciones</param>
    /// <returns>la carta activable mas fuerte de su mano</returns>
    public static Card StrongestCard(Status IAState) {
        Card strongest = new();
        int life = IAState.playerStatuses[1].life;
        
        foreach (Card card in IAState.playerStatuses[0].playerHand)
        {
            if (Game.IsValid(card, IAState.playerStatuses[0]))
            {
                Context ctx = Utils.CreateScope(IAState);
                Context nuevo = Utils.InterpretEffect(ctx, card.Effect);

                if (LogicMove(ctx, nuevo)) {
                    if (life > nuevo.GetValue("EnemyLife"))
                    {
                        life = nuevo.GetValue("EnemyLife");
                        strongest = card;
                    }
                }
            }
        }
        if (life != IAState.playerStatuses[1].life) {
            return strongest;
        }
        return null;
    }

    /// <summary>
    /// Selecciona la carta que mas aumente la vida del jugador
    /// </summary>
    /// <param name="IAState">Estado del juego con restricciones</param>
    /// <returns>la carta valida que mayor vida otorgue</returns>
    public static Card HealerCard(Status IAState) {
       Card healer = new();
        int life = IAState.playerStatuses[0].life;
        
        foreach (Card card in IAState.playerStatuses[0].playerHand)
        {
            if (Game.IsValid(card, IAState.playerStatuses[0]))
            {                
                Context ctx = Utils.CreateScope(IAState);
                Context nuevo = Utils.InterpretEffect(ctx, card.Effect);
                
                if (LogicMove(ctx, nuevo))
                {
                    if (life < nuevo.GetValue("MyLife"))
                    {
                        life = nuevo.GetValue("MyLife");
                        healer = card;
                    }
                }
            }
        }
        if (life != IAState.playerStatuses[0].life) {
            return healer;
        }
        return null; 
    }

    /// <summary>
    /// Determina si una jugada es medianamente logica
    /// </summary>
    /// <param name="IAState">Estado del juego con restricciones</param>
    /// <param name="cd">carta que se quiere seleccionar</param>
    /// <returns>Si seleccionar la carta es una jugada con sentido</returns>
    public static bool LogicMove(Context actual, Context nuevo)
    {        
        int originalLife = actual.GetValue("MyLife");
        int newLife = nuevo.GetValue("MyLife");
        //Si la vida luego de activar la carta bajo a la mitad,
        //probablemente no sea una jugada con sentido porque costo demasiado.
        if (newLife < originalLife/2)
            return false;
        return true;
    }
}