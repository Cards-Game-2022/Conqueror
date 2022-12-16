using System;
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
        Dictionary<string, int> scope = Utils.CreateScope(st);
        
        if (st.playerStatuses[0].player is PlayerIA) {
            card = PlayerIA.SelectIACard(st.playerStatuses[0]); // metodo para seleccionar la carta a jugar
        }
        if (st.playerStatuses[0].player is PlayerHuman) {
            if (!IsValid(card, st.playerStatuses[0])) {
                //no se debe hacer aqui esta revision
                return;
            }
        }
        scope = st.playerStatuses[0].player.Launch(card, scope, st.playerStatuses[0].playerHand); 
        st.UpdateStatus(scope, card);
        StabilizeLife();        
    }
    public void ChangePlayers() {
        List<PlayerStatus> copia = new();
        copia.Add(st.playerStatuses[1]);
        copia.Add(st.playerStatuses[0]);

        st.playerStatuses = copia;
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
        return st.playerStatuses[0].player.Name;
        else if (st.playerStatuses[0].life < st.playerStatuses[1].life)
        return st.playerStatuses[1].player.Name;
        else 
        return "";
    }
    public void ChangeTurns() {
        ChangePlayers();
        Actions.Draw(st.playerStatuses[0]);
        Actions.AddCharms(st.playerStatuses[0]);
         
        if (st.playerStatuses[0].player is PlayerIA) {
            Input(new Card());
        } 
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
        while (!GameOver()) {
            ChangeTurns();            
            yield return this.st;
        }
        ShowWinner();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    /// <summary>
    /// Metodo para recibir la carta jugada
    /// </summary>
    public void Input(Card card) {
        if (!GameOver()) {
            Activate(card);
            this.GetEnumerator().MoveNext();
        }
    }
    
    /// <summary>
    /// Metodo para mostrar las cartas. Se hace en el razor
    /// </summary>
    public void Output() {
        
    }
    
    /// <summary>
    /// Metodo para mostrar el ganador en consola
    /// </summary>
    public void ShowWinner() {
        
        string winner = GetWinner();
        if (winner != null && winner != "")
            Console.WriteLine("Ha ganado " + winner);
        else 
            Console.WriteLine("No ha ganado nadie. Empate");
    }
    
}