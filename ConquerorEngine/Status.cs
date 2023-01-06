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
    /// Constructor de estados vacio
    /// </summary>
    public Status() {
        playerStatuses = new();
    }
    
    /// <summary>
    /// Constructor de estados
    /// </summary>
    /// <param name="nPlayers">Representa la cantidad de jugadores que tendra el juego</param>
    public Status(int nPlayers) {
        playerStatuses = new(nPlayers);
        for (int i = 0; i<nPlayers; i++) {
            playerStatuses.Add(new PlayerStatus());
        }
    }


    /// <summary>
    /// Inicializa los jugadores
    /// </summary>
    /// <param name="level">Define los tipos de jugadores: 
    /// 0: Humano vs Humano. 
    /// 1: Humano vs IA. 
    /// 2: IA vs IA.
    /// </param>
    public void InitializePlayers(int level)
    {
        Manager mg = new Manager();

        Character c0 = mg.db.GetCharacter(0);
        Character c1 = mg.db.GetCharacter(1);

        if (level != 2)
        {
            playerStatuses[0].player = new PlayerHuman(c0.Name, c0.UrlPhoto, c0.Id);
            if (level == 0)
            {
                playerStatuses[1].player = new PlayerHuman(c1.Name, c1.UrlPhoto, c1.Id);
            }
            else
            {
                playerStatuses[1].player = new PlayerIA(c1.Name, c1.UrlPhoto, c1.Id);
            }
        }
        else
        {
            playerStatuses[0].player = new PlayerIA(c0.Name, c0.UrlPhoto, c0.Id);
            playerStatuses[1].player = new PlayerIA(c1.Name, c1.UrlPhoto, c1.Id);
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

        ActivateFunctions(ctx);
        return this;
    }

    /// <summary>
    /// Activa las funciones del efecto de una carta
    /// </summary>
    /// <param name="ctx">estado de juego actual</param>
    public void ActivateFunctions(Context ctx) {
        foreach (var item in Config.Names) {
            if (ctx.ContainsId(item)) {
                for (int i = ctx.GetValue(item); i>0; i--) {

                    if (item == "Draw") {
                        Actions.Draw(this.playerStatuses[0]);
                    } else 
                    if (item == "ChangeHands") {
                        Actions.ChangeHands(this.playerStatuses);
                    } else
                    if (item == "DrawFromEnemy") {
                        Actions.DrawFromEnemy(this.playerStatuses);
                    }                   
                }
            }
        }
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

    /// <summary>
    /// Crea un estado de juego a partir del estado actual con restricciones
    /// </summary>
    /// <returns>Un estado que no contiene la mano ni el deck del enemigo</returns>
    public Status StatusForIA() {

        Status newStatus = new();
        newStatus.playerStatuses.Add(this.playerStatuses[0].Clone());
        //Barajea el deck del jugador para evitar que conozca el orden de sus cartas
        Actions.Shuffle(newStatus.playerStatuses[0].playerDeck);

        newStatus.playerStatuses.Add(this.playerStatuses[1].Clone());
        newStatus.playerStatuses[1].playerHand.Clear();
        newStatus.playerStatuses[1].playerDeck.Clear();
        
        return newStatus;
    }
}
