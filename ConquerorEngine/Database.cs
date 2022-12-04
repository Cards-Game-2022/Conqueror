using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace Conqueror.Logic;

public class Database {
    public List<Card> Cards {
        get; private set;
    }
    public List<Character> Characters {
        get; private set;
    }
    public Database() {
        InitCards();
        InitCharacters();
    }
    public void InitCharacters() {
        if (Characters == null) {
            if (File.Exists(Config.PathCharacters)) {
                string jsonString = File.ReadAllText(Config.PathCharacters);
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
        File.WriteAllText(Config.PathCharacters, jsonString);
    }
    public void InitCards() {
        if (Cards == null) {

            if (File.Exists(Config.PathCard)) {
                string jsonString = File.ReadAllText(Config.PathCard);
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
        File.WriteAllText(Config.PathCard, jsonString);
    }
    public Id GetLastId() {
        // abre el txt y revisa si lo que contiene es un numero si no devuelve 0
        if (File.Exists(Config.PathCharacters)) {
            string jsonString = File.ReadAllText(Config.PathLastID);
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
        File.WriteAllText(Config.PathLastID, jsonString); 
    }
    public Character GetCharacter(int id) {
        foreach (var item in Characters) {
            if (id == item.Id) {
                return item;
            }
        }
        Utils.Error("Personaje no encontrado");
        return null;
    }
    public Card GetCard(int id) {
        foreach (var item in Cards) {
            if (id == item.Id) {
                return item;
            }
        }
        Utils.Error("Carta no encontrada");
        return null;
    }
}