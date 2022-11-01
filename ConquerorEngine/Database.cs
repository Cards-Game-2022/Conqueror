using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace Conqueror.Logic;

static class Database {
    static public List<Card> Cards {
        get; private set;
    }
    static public List<Character> Characters {
        get; private set;
    }

    
    static public void LoadCards() {
        if (File.Exists(Config.pathCard)) {
            string jsonString = File.ReadAllText(Config.pathCard);
            List<Card> card = JsonSerializer.Deserialize<List<Card>>(jsonString);
        }
    }

    static public void LoadCharacters() {
        if (File.Exists(Config.pathCharacters)) {
            string jsonString = File.ReadAllText(Config.pathCharacters);
            Characters = JsonSerializer.Deserialize<List<Character>>(jsonString);
        }
    }

    static public void StoreCard(Card card) {
        List<Card>cards = new List<Card>();
        cards.Add(card);
        cards.Add(card);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(cards, options);

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