using System.Collections;
using Conqueror.Logic.Language;

namespace Conqueror.Logic;

public class Game : IEnumerable<Status>, IGraphics {
    
    /// <summary>
    /// Estado del juego
    /// </summary>
    public Status st = new(2);

    public Game() {

    }
    
    /// <summary>
    /// Constructor de un nuevo juego
    /// </summary>
    /// <param name="level">Determina los tipos de jugadores</param>
    public Game(int level) {
        st.InitializePlayers(level);        
    }    
    
    /// <summary>
    /// Activa una carta
    /// </summary>
    /// <param name="card">carta que se va a activar</param>
    public void Activate(Card card) {
        Context newContext = Launch(card, Utils.CreateScope(st), st);
        st.UpdateStatus(newContext, card);
        Actions.RemoveCard(st.playerStatuses[0].playerHand, card);

        StabilizeLife();      
    }

    /// <summary>
    /// Lanza una carta
    /// </summary>
    /// <param name="card">carta que se quiere activar</param>
    /// <param name="ctx">Contexto del interprete</param>
    /// <param name="st">Estado actual del juego</param>
    /// <returns>El nuevo contexto</returns>
    public Context Launch(Card card, Context ctx, Status st)
    {    
        try {
            Utils.InterpretEffect(ctx, card.Effect);
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
        return ctx;
    }

    /// <summary>
    /// Realiza los movimientos del jugador si es un jugador virtual
    /// </summary>
    /// <returns>Si realizo o no la jugada</returns>
    public bool PlayIA() {
        if (st.playerStatuses[0].player is PlayerIA) {
            Card cd = (st.playerStatuses[0].player as PlayerIA).SelectIACard(st.StatusForIA());
            Input(cd);
            return true;
        }
        return false;
    }
    
    /// <summary>
    /// Verifica que una jugada sea valida
    /// </summary>
    /// <param name="cd">Carta que se quiere activar</param>
    /// <param name="playerStatus">Estado del jugador que activa la carta</param>
    /// <returns>Si es valida la jugada o no</returns>
    public static bool IsValid(Card cd, PlayerStatus playerStatus) {
        if (cd == null)
            return false;
        if (playerStatus.charms >= cd.Charms || cd.Charms == 0) {
            return true;
        }        
        return false;
    }
    
    /// <summary>
    /// Verifica el fin del juego
    /// </summary>
    /// <returns>Si el juego termino o no</returns>
    public bool GameOver() {
        if (st.playerStatuses[0].life <= 0 || st.playerStatuses[1].life <= 0) { 
            return true;
        } else {
            return false;
        }
    }   
    
    /// <summary>
    /// Obtiene el ganador
    /// </summary>
    /// <returns>Texto con mensaje y el ganador</returns>        
    public string GetWinner() {
        if (st.playerStatuses[0].life > st.playerStatuses[1].life)
        return "El ganador es: " + st.playerStatuses[0].player.Name;

        else if (st.playerStatuses[0].life < st.playerStatuses[1].life)
        return "El ganador es: " + st.playerStatuses[1].player.Name;

        else 
        return "No hubo ganadores";
    }
    
    /// <summary>
    /// Los jugadores intercambian turnos
    /// </summary>
    public void ChangeTurns() {
        st.ChangePlayers();
        Actions.Draw(st.playerStatuses[0]);
        Actions.AddCharms(st.playerStatuses[0]);
    }
    
    /// <summary>
    /// Evita que la vida sea negativa
    /// </summary>    
    public void StabilizeLife() {
        foreach (PlayerStatus item in st.playerStatuses) {
            if (item.life < 0) {
                item.life = 0;
            }
        }
    }

    /// <summary>
    /// Obtiene la siguiente jugada
    /// </summary>
    /// <returns>El nuevo estado de juego</returns>
    public IEnumerator<Status> GetEnumerator() {    
        if (!GameOver()) {            
            ChangeTurns();
            if (PlayIA()) {
                ChangeTurns();
            }
            yield return this.st;
        }
        else
        yield break;            
    }

    /// <summary>
    /// Obtiene la siguiente jugada
    /// </summary>
    /// <returns>El nuevo estado de juego</returns>
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();        
    }
    
    /// <summary>
    /// Recibe la carta jugada
    /// </summary>
    /// <param name="card">carta jugada</param>
    public void Input(Card card) {
        if (!GameOver()) {                
            if (IsValid(card, st.playerStatuses[0])) {
                Activate(card);

                //Almacena la carta jugada por el enemigo del jugador virtual
                if (st.playerStatuses[1].player is PlayerIA) {
                    (st.playerStatuses[1].player as PlayerIA).StoreCard(card);
                }
            }            
            else
                return;

            //Si el jugador es humano, no puede activar ninguna otra carta y se cambia el turno automaticamente
            if (st.playerStatuses[0].player is PlayerHuman) {
                this.GetEnumerator().MoveNext();
            }
        }
    }
    
    /// <summary>
    /// Muestra las acciones
    /// </summary>
    public void Output() {
        
    }
}