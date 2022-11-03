﻿using System;
using Conqueror.Logic;

Game game = new Game();

//game.CreateCharacter("Helbrand", "1.png");
game.CreateCard("Helbrand", "1.png");
//game.GetCharacter(1); 
//game.GetCard(1);

Character c1 = game.GetCharacter(0);

Character c2 = game.GetCharacter(1);

Player p1 = new Player(c1.Name, c1.UrlPhoto, c1.Id);

Player p2 = new Player(c2.Name, c2.UrlPhoto, c2.Id);