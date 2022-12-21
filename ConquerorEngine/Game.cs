using System.Collections;
using Conqueror.Logic.Language;

namespace Conqueror.Logic;

public class Game : IEnumerable<Status>, IGraphics {
    
    public Status st = new(2);

    public Game() {

    }
    public Game(int level) {
        InitializePlayers(level);
        
    }
    
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
    public void Activate(Card card) {

        Context newContext = Launch(card, Utils.CreateScope(st), st);
        st.UpdateStatus(newContext, card);
        StabilizeLife();        
    }

    public Context Launch(Card card, Context scope, Status st)
    {
        if (card != null) {        
            Actions.RemoveCard(card, st.playerStatuses[0].playerHand);
            Utils.InterpretEffect(scope, card.Effect);
            return scope;
        }        
        else {
            Utils.Error("Accion invalida");
            return null;
        }
    }

    public bool GameOver() {
        if (st.playerStatuses[0].life <= 0 || st.playerStatuses[1].life <= 0) { 
            return true;
        } else {
            return false;
        }
    }
    public static bool IsValid(Card cd, PlayerStatus playerStatus) {
        if (playerStatus.charms >= cd.Charms ) {
            return true;
        }        
        return false;
    }        
    public string GetWinner() {
        if (st.playerStatuses[0].life > st.playerStatuses[1].life)
        return "El ganador es: " + st.playerStatuses[0].player.Name;

        else if (st.playerStatuses[0].life < st.playerStatuses[1].life)
        return "El ganador es: " + st.playerStatuses[1].player.Name;

        else 
        return "No hubo ganadores";
    }
    public void ChangeTurns() {
        st.ChangePlayers();
        Actions.Draw(st.playerStatuses[0]);
        Actions.AddCharms(st.playerStatuses[0]);
    }    
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

    public IEnumerator<Status> GetEnumerator() {    
            if (!GameOver()) {            
                ChangeTurns();
                PlayIA();
                yield return this.st;
            }
            else
            yield break;
            
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();        
    }

    public void PlayIA() {
        if (st.playerStatuses[0].player is PlayerIA) {
            Input(PlayerIA.SelectIACard(st.playerStatuses[0]));
        }
    }
    /// <summary>
    /// Recibe la carta jugada
    /// </summary>
    /// <param name="card">carta jugada</param>
    public void Input(Card card) {
            if (card != null)
            Activate(card);
    }
    
    /// <summary>
    /// Muestra las acciones
    /// </summary>
    public void Output() {
        
    }
    
}