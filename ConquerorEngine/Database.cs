using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace Conqueror.Logic;

class Database {
    public List<Card> Cards {
        get; private set;
    }
    public List<Character> Characters {
        get; private set;
    }

    
    public void LoadCards() {
        if (File.Exists(Config.pathCard)) {
            string jsonString = File.ReadAllText(Config.pathCard);

            if (jsonString == "") {
                return;
            }

            Cards = JsonSerializer.Deserialize<List<Card>>(jsonString);
        }
    }

    public void LoadCharacters() {
        if (File.Exists(Config.pathCharacters)) {
            string jsonString = File.ReadAllText(Config.pathCharacters);

            if (jsonString == "") {
                return;
            }

            Characters = JsonSerializer.Deserialize<List<Character>>(jsonString);
        }
    }

    public void StoreCard(Card card) {
        // cargo los datos que tengo y le agrego el nuevo
        if (Cards == null) {
            Cards = new List<Card>();
            
            LoadCards();
        }
        
        Cards.Add(card);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Cards, options);

        File.WriteAllText(Config.pathCard, jsonString); 
    }

    public void StoreCharacter(Character character) {
        if (Characters == null) {
            Characters = new List<Character>();

            LoadCharacters();
        }
        
        Characters.Add(character);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Characters, options);
        File.WriteAllText(Config.pathCharacters, jsonString); 
    }

    public Id GetLastId() {
        // abre el txt y revisa si lo que contiene es un numero si no devuelve 0
        Id id = new Id(0, 0);

        if (File.Exists(Config.pathCharacters)) {
            string jsonString = File.ReadAllText(Config.pathLastID);

            if (jsonString == "") {
                return id;
            }

            id = JsonSerializer.Deserialize<Id>(jsonString);
        }

        return id;
    }

    public void UpdateId(int card, int character) {
        Id id = new Id(card, character);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(id, options);
        File.WriteAllText(Config.pathLastID, jsonString); 
    }

    public Character GetCharacter(int id) {
        Character ch = null;

        foreach (var item in Characters)
        {
            if (id == item.Id) {
                ch = item;
            }
        }

        return ch;
    }
    public Card GetCard(int id) {
        Card cd = null;

        foreach (var item in Cards)
        {
            if (id == item.Id) {
                cd = item;
            }
        }

        return cd;
    }
}