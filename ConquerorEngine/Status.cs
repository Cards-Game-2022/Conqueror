using System;
using System.Collections.Generic;
using System.Linq;
using Conqueror.Logic.Language;
using System.Threading.Tasks;

namespace Conqueror.Logic;

public class Status {
    
    /// <summary>
    /// Lista de todos los estados de jugadores
    /// </summary>
    public List<PlayerStatus> playerStatuses { get; private set; }
    
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
    /// <param name="ctx">estado de juego actual</param>
    /// <param name="cd">carta que modifica el estado de juego</param>
    /// <returns></returns>
    public Status UpdateStatus(Context ctx, Card cd) {    
        playerStatuses[0].life = ctx.GetValue("MyLife");
        playerStatuses[1].life = ctx.GetValue("EnemyLife");
        playerStatuses[0].charms = ctx.GetValue("MyCharms") - cd.Charms;
        playerStatuses[1].charms = ctx.GetValue("EnemyCharms");

        return this;
    }

    /// <summary>
    /// Se intercambian los jugadores
    /// </summary>
    public void ChangePlayers() {
        List<PlayerStatus> copia = new();
        copia.Add(this.playerStatuses[1]);
        copia.Add(this.playerStatuses[0]);

        this.playerStatuses = copia;
    }

}
