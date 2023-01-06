using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace Conqueror.Logic;

public class Database {
   
   /// <summary>
   /// Lista de cartas en la base de datos
   /// </summary>
    public List<Card> Cards { get; private set; }
    
    /// <summary>
    /// Lista de personajes de la base de datos
    /// </summary>
    public List<Character> Characters { get; private set; }
    
    /// <summary>
    /// Constructor de la base de datos
    /// </summary>
    public Database() {
        InitCards();
        InitCharacters();
    }
    
    /// <summary>
    /// Rellena la lista de personajes
    /// </summary>
    public void InitCharacters() {
        if (Characters == null) {
            Characters = new List<Character>();
            if (File.Exists(Config.pathCharacters)) {
                string jsonString = File.ReadAllText(Config.pathCharacters);
                if (jsonString != "") {
                    Characters = JsonSerializer.Deserialize<List<Character>>(jsonString);
                    return;
                }
            }            
        }
    }
    
    /// <summary>
    /// Rellena la lista de cartas
    /// </summary>
    public void InitCards() {
        if (Cards == null) {
            Cards = new List<Card>();
            if (File.Exists(Config.pathCard)) {
                string jsonString = File.ReadAllText(Config.pathCard);
                if (jsonString != "") {
                    Cards = JsonSerializer.Deserialize<List<Card>>(jsonString);
                    return;
                }
            }            
        }
    }
        
    /// <summary>
    /// Almacena un personaje en la base de datos (archivo json)
    /// </summary>
    /// <param name="ch">personaje que se va a almacenar</param>
    public void StoreCharacter(Character ch) {
        InitCharacters();
        Characters.Add(ch);
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Characters, options);
        File.WriteAllText(Config.pathCharacters, jsonString);
    }
    
    /// <summary>
    /// Almacena una carta en la base de datos (archivo json)
    /// </summary>
    /// <param name="cd">carta que se va a almacenar</param>
    public void StoreCard(Card cd) {
        InitCards();
        Cards.Add(cd);
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Cards, options);
        File.WriteAllText(Config.pathCard, jsonString);
    }
    
    /// <summary>
    /// Obtiene un personaje de la base de datos
    /// </summary>
    /// <param name="id">id del personaje</param>
    /// <returns>El personaje obtenido</returns>
    public Character GetCharacter(int id) {
        foreach (var item in Characters) {
            if (id == item.Id) {
                return item;
            }
        }
        Utils.Error("Personaje no encontrado");
        return null;
    }
    
    /// <summary>
    /// Obtiene una carta de la base de datos
    /// </summary>
    /// <param name="id">id de la carta</param>
    /// <returns>La carta obtenida</returns>
    public Card GetCard(int id) {
        foreach (var item in Cards) {
            if (id == item.Id) {
                return item;
            }
        }
        Utils.Error("Carta no encontrada");
        return null;
    }

    /// <summary>
    /// Obtiene el ultimo id de la base datos
    /// </summary>
    /// <returns>El ultimo id de la base de datos</returns>
    public static Id GetLastId() {
        //Si existe el txt existe y contiene un numero, lo retorna
        //De lo contrario devuelve 0.
        if (File.Exists(Config.pathCharacters)) {
            string jsonString = File.ReadAllText(Config.pathLastID);
            if (jsonString != "") {
                return JsonSerializer.Deserialize<Id>(jsonString);
            }
        }
        return new Id(0, 0);
    }
    
    /// <summary>
    /// Actualiza el id correspondiente
    /// </summary>
    /// <param name="card"></param>
    /// <param name="character"></param>
    public static void UpdateId(int card, int character) {
        Id id = new Id(card, character);

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(id, options);
        File.WriteAllText(Config.pathLastID, jsonString); 
    }
}