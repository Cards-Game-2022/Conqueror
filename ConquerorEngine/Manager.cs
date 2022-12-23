namespace Conqueror.Logic;

public class Manager {
    
    public Database db;
    /// <summary>
    /// Constructor del manager
    /// </summary>
    public Manager() {
        db = new Database();
        db.InitCards();
        db.InitCharacters();
    }
    
    /// <summary>
    /// Crea una carta
    /// </summary>
    /// <param name="name">nombre de la carta</param>
    /// <param name="url">direccion de la foto</param>
    /// <param name="rarity">rareza de la carta</param>
    /// <param name="charms">charms que cuesta la carta</param>
    /// <param name="text">descripcion de la carta</param>
    /// <param name="effect">efecto de la carta en codigo</param>
    public void CreateCard(string name, string url, int rarity, int charms, string text, string effect) {
        try {
            Utils.InterpretEffect(Utils.CreateScope(), effect);
        }
        catch(Exception e) {
            Utils.Error("Hubo un error en el codigo de la carta");
        }
        
        //Obtiene el id de la ultima carta
        Id id = Database.GetLastId();
        //Crea y almacena la nueva carta con los parametros recibidos
        db.StoreCard(new Card(name, url, id.Card + 1, rarity, charms, text, effect));
        //Actualiza el ultimo id de carta de la base de datos
        Database.UpdateId(id.Card + 1, id.Character);
    }
    
    /// <summary>
    /// Crea un personaje nuevo
    /// </summary>
    /// <param name="name">nombre del nuevo personaje</param>
    /// <param name="url">foto del nuevo personaje</param>
    public void CreateCharacter(string name, string url) {
        //Obtiene el id del ultimo personaje
        Id id = Database.GetLastId();
        //Crea y almacena el nuevo personaje con los parametros recibidos.      
        db.StoreCharacter(new Character(name, Config.PathImageCharacters + "/" + url, id.Character + 1));
        //Actualiza el ultimo id de personaje de la base de datos
        Database.UpdateId(id.Card, id.Character + 1);
    }
    
    /// <summary>
    /// Obtiene un personaje de la base de datos
    /// </summary>
    /// <param name="id">id del personaje</param>
    /// <returns>El personaje obtenido</returns>
    public Character GetCharacter(int id) { 
        return db.GetCharacter(id);
    }

    /// <summary>
    /// Obtiene una carta de la base de datos
    /// </summary>
    /// <param name="id">id de la carta</param>
    /// <returns>La carta obtenida</returns>
    public Card GetCard(int id) {  
        return db.GetCard(id);
    } 
}