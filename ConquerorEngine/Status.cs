using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conqueror.Logic;

public class Status {
   
    public List<PlayerStatus> playerStatuses = new();
    /// <summary>
    /// Constructor de estados
    /// </summary>
    /// <param name="nPlayers">Representa la cantidad de jugadores que tendra el juego</param>
    public Status(int nPlayers) {
        for (int i = 0; i<nPlayers; i++) {
            playerStatuses.Add(new PlayerStatus());
        }
    }
    public Status UpdateStatus(Dictionary<string, int> scope, Card cd) {    
        playerStatuses[0].life = scope["MyLife"];
        playerStatuses[1].life = scope["EnemyLife"];
        playerStatuses[0].charms = scope["MyCharms"] - cd.Charms;
        playerStatuses[1].charms = scope["EnemyCharms"];

        return this;
    }
}
