using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace Conqueror.Logic;

static public class Database {
    static public List<Card> Cards {
        get; private set;
    }
    static public List<Character> Characters {
        get; private set;
    }

    
    static public List<Card> LoadCards() {

        
        if (File.Exists(Config.pathCard)) {            
            string jsonString = File.ReadAllText(Config.pathCard);
            Cards = JsonSerializer.Deserialize<List<Card>>(jsonString);

            Console.WriteLine(Cards[0].Name);            
        }
        return Cards;
    }

    static public void LoadCharacters() {
        if (File.Exists(Config.pathCharacters)) {
            string jsonString = File.ReadAllText(Config.pathCharacters);
            Characters = JsonSerializer.Deserialize<List<Character>>(jsonString);
        }
    }

    static public void StoreCard(Card card) {
        //List<Card>cards = new List<Card>();
        Cards.Add(card);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Cards, options);

        File.WriteAllText(Config.pathCard, jsonString); 
    }

    static public void StoreCharacter(Character character) {
        List<Character> characters = new List<Character>();
        characters.Add(character);
        characters.Add(character);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(characters, options);
        File.WriteAllText(Config.pathCharacters, jsonString); 
    }
}