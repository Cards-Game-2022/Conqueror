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

    public void InitCharacters() {
        if (Characters == null) {
            if (File.Exists(Config.pathCharacters)) {
                string jsonString = File.ReadAllText(Config.pathCharacters);
                if (jsonString != "") {
                    Characters = JsonSerializer.Deserialize<List<Character>>(jsonString);
                    return;
                }
            }
            Characters = new List<Character>();
        }
    }

    public void StoreCharacter(Character ch) {
        InitCharacters();
        Characters.Add(ch);
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Characters, options);
        File.WriteAllText(Config.pathCharacters, jsonString);
    }

    public void InitCards() {
        if (Cards == null) {
            if (File.Exists(Config.pathCard)) {
                string jsonString = File.ReadAllText(Config.pathCard);
                if (jsonString != "") {
                    Cards = JsonSerializer.Deserialize<List<Card>>(jsonString);
                    return;
                }
            }
            Cards = new List<Card>();
        }
    }

    public void StoreCard(Card cd) {
        InitCards();
        Cards.Add(cd);
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Cards, options);
        File.WriteAllText(Config.pathCard, jsonString);
    }

    public Id GetLastId() {
        // abre el txt y revisa si lo que contiene es un numero si no devuelve 0
        if (File.Exists(Config.pathCharacters)) {
            string jsonString = File.ReadAllText(Config.pathLastID);
            if (jsonString != "") {
                return JsonSerializer.Deserialize<Id>(jsonString);
            }
        }
        return new Id(0, 0);
    }

    public void UpdateId(int card, int character) {
        Id id = new Id(card, character);
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(id, options);
        
        File.WriteAllText(Config.pathLastID, jsonString); 
    }

    public Character GetCharacter(int id) {
        foreach (var item in Characters) {
            if (id == item.Id) {
                return item;
            }
        }
        return null;
    }
    public Card GetCard(int id) {
        foreach (var item in Cards) {
            if (id == item.Id) {
                return item;
            }
        }
        return null;
    }
}