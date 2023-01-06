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
            life = Config.basicLife;
            charms = Config.defaultCharms;
            Actions.CreateDeck(playerDeck);
            Actions.CreateHand(playerHand, playerDeck);
            
        }

        /// <summary>
        /// Clona el estado actual del juego por copia
        /// </summary>
        /// <returns>La copia del estado actual del juego</returns>
        public PlayerStatus Clone() {
            PlayerStatus copy = new PlayerStatus();
            copy.charms = this.charms;
            copy.life = this.life;
            
            if (this.player is PlayerHuman) {
                copy.player = this.player;
            }
            else {
                //Clona el jugador virtual por copia para evitar que las cartas jugadas
                //por el enemigo se pasen por referencia
                copy.player = (this.player as PlayerIA).Clone();
            }

            copy.playerDeck.Clear();
            foreach(Card card in this.playerDeck) {
                copy.playerDeck.Add(card);
            }

            copy.playerHand.Clear();
            foreach(Card card in this.playerHand) {
                copy.playerHand.Add(card);
            }

            return copy;   
        }
    }
