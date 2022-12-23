using System.Collections;
using Conqueror.Logic.Language;

namespace Conqueror.Logic;

public class Game : IEnumerable<Status>, IGraphics {
    
    public Status st = new(2);

    public Game() {

    }
    
    /// <summary>
    /// Constructor de un nuevo juego
    /// </summary>
    /// <param name="level">Determina los tipos de jugadores</param>
    public Game(int level) {
        InitializePlayers(level);        
    }
    
    /// <summary>
    /// Inicializa los jugadores
    /// </summary>
    /// <param name="level">Define los tipos de jugadores: 
    /// 0: Humano vs Humano. 
    /// 1: Humano vs IA. 
    /// 2: IA vs IA.
    /// </param>
    public void InitializePlayers(int level) {
        Manager cq = new Manager();
        
        Character c0 = cq.GetCharacter(0);
        Character c1 = cq.GetCharacter(1);

        if (level != 2) {
            st.playerStatuses[0].player = new PlayerHuman(c0.Name, c0.UrlPhoto, c0.Id);
            if (level == 0) {
                st.playerStatuses[1].player = new PlayerHuman(c1.Name, c1.UrlPhoto, c1.Id);           
            } else {
                st.playerStatuses[1].player = new PlayerIA(c1.Name, c1.UrlPhoto, c1.Id);    
            }
        }
        else {
            st.playerStatuses[0].player = new PlayerIA(c0.Name, c0.UrlPhoto, c0.Id);
            st.playerStatuses[1].player = new PlayerIA(c1.Name, c1.UrlPhoto, c1.Id);            
        }
    }    
    
    /// <summary>
    /// Activa una carta
    /// </summary>
    /// <param name="card">carta que se va a activar</param>
    public void Activate(Card card) {

        Context newContext = Launch(card, Utils.CreateScope(st), st);
        st.UpdateStatus(newContext, card);
        StabilizeLife();        
    }

    /// <summary>
    /// Lanza una carta
    /// </summary>
    /// <param name="card">carta que se quiere activar</param>
    /// <param name="scope">Contexto del interprete</param>
    /// <param name="st">Estado actual del juego</param>
    /// <returns>El nuevo contexto</returns>
    public Context Launch(Card card, Context scope, Status st)
    {
        Actions.RemoveCard(st.playerStatuses[0].playerHand, card);
        
        try {
            Utils.InterpretEffect(scope, card.Effect);
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
        return scope;
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
    /// Verifica que una jugada sea valida
    /// </summary>
    /// <param name="cd">Carta que se quiere activar</param>
    /// <param name="playerStatus">Estado del jugador que activa la carta</param>
    /// <returns>Si es valida la juagada o no</returns>
    public static bool IsValid(Card cd, PlayerStatus playerStatus) {
        if (playerStatus.charms >= cd.Charms || cd.Charms == 0) {
            return true;
        }        
        return false;
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
        foreach (PlayerStatus state in st.playerStatuses) {
            if (state.life < 0) {
                state.life = 0;
            }
        }
    }
    
    /// <summary>
    /// Aun no esta hecho para usarse.
    /// </summary>
    public List<Card> StorePlayedCard(List<Card> playedCards, Card card) {
        playedCards.Add(card);
        return playedCards;
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

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();        
    }

    /// <summary>
    /// Realiza los movimientos del jugador si es un jugador virtual
    /// </summary>
    /// <returns>Si es o no un jugador virtual</returns>
    public bool PlayIA() {
        if (st.playerStatuses[0].player is PlayerIA) {
            Input(PlayerIA.SelectIACard(st.playerStatuses[0]));
            return true;
        }
        return false;
    }
    
    /// <summary>
    /// Recibe la carta jugada
    /// </summary>
    /// <param name="card">carta jugada</param>
    public void Input(Card card) {
            if (card != null) {
                if (IsValid(card, st.playerStatuses[0])) {
                    Activate(card);
                }
            }
            else
                return;

            //Si el jugador es humano, no puede activar ninguna otra carta y se cambia el turno automaticamente
            if (st.playerStatuses[0].player is PlayerHuman) {
                this.GetEnumerator().MoveNext();
            }
    }
    
    /// <summary>
    /// Muestra las acciones
    /// </summary>
    public void Output() {
        
    }
    
}