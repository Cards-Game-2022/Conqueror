using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conqueror.Logic;

public class Status {
   
    public List<PlayerStatus> playerStatuses {get; private set;}
    /// <summary>
    /// Constructor de estados
    /// </summary>
    /// <param name="nPlayers">Representa la cantidad de jugadores que tendra el juego</param>
    public Status(int nPlayers) {
        playerStatuses = new();
        for (int i = 0; i<nPlayers; i++) {
            playerStatuses.Add(new PlayerStatus());
        }
    }
    /// <summary>
    /// Actualiza el estado de juego
    /// </summary>
    /// <param name="scope">estado de juego actual</param>
    /// <param name="cd">carta que modifica el estado de juego</param>
    /// <returns></returns>
    public Status UpdateStatus(Dictionary<string, int> scope, Card cd) {    
        playerStatuses[0].life = scope["MyLife"];
        playerStatuses[1].life = scope["EnemyLife"];
        playerStatuses[0].charms = scope["MyCharms"] - cd.Charms;
        playerStatuses[1].charms = scope["EnemyCharms"];

        return this;
    }
    public void ChangePlayers() {
        List<PlayerStatus> copia = new();
        copia.Add(this.playerStatuses[1]);
        copia.Add(this.playerStatuses[0]);

        this.playerStatuses = copia;
    }
        /// <summary>
    /// Crea un scope basado en el estado actual del juego
    /// </summary>
    /// <param name="st">Estado actual del juego</param>
    public static Dictionary<string, int> CreateScope(Status st) {
        Dictionary<string, int> scope = new();
        scope.Add("MyLife", st.playerStatuses[0].life);
        scope.Add("EnemyLife", st.playerStatuses[1].life);
        scope.Add("MyCharms", st.playerStatuses[0].charms);
        scope.Add("EnemyCharms", st.playerStatuses[1].charms);
        return scope;
    }
    /// <summary>
    /// Crea un scope desde un estado inicial de juego predefinido
    /// </summary>
    public static Dictionary<string, int> CreateScope() {
        Dictionary<string, int> scope = new();
        scope.Add("MyLife", Config.BasicLife);
        scope.Add("EnemyLife", Config.BasicLife);
        scope.Add("MyCharms", Config.Charms);
        scope.Add("EnemyCharms", Config.Charms);
        return scope;
    }
}
