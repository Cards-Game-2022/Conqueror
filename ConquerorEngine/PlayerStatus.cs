using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conqueror.Logic; 
    public class PlayerStatus {
        public Player player;
        public List<Card> playerDeck = new();
        public List<Card> playerHand = new();
        public int life;
        public int charms;

        public PlayerStatus() {
            life = Config.BasicLife;
            charms = Config.Charms;
            Actions.CreateDeck(playerDeck);
            Actions.CreateHand(playerHand, playerDeck);
            
        }
    }
