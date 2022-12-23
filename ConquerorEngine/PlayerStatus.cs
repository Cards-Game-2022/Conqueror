using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conqueror.Logic; 
    public class PlayerStatus {
        /// <summary>
        /// El jugador
        /// </summary>
        public Player player;
        /// <summary>
        /// El deck del jugador
        /// </summary>
        public List<Card> playerDeck = new();
        /// <summary>
        /// La mano del jugador
        /// </summary>
        public List<Card> playerHand = new();
        /// <summary>
        /// La vida del jugador
        /// </summary>
        public int life;
        /// <summary>
        /// Los charms del jugador
        /// </summary>
        public int charms;

        /// <summary>
        /// Constructor del estado de jugador
        /// </summary>
        public PlayerStatus() {
            life = Config.BasicLife;
            charms = Config.Charms;
            Actions.CreateDeck(playerDeck);
            Actions.CreateHand(playerHand, playerDeck);
            
        }
    }
