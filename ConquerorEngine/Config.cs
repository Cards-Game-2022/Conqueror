namespace Conqueror.Logic;

static class Config {
    
    /// <summary>
    /// Ruta del json que contiene los personajes
    /// </summary>
    static public string pathCharacters = @"../ConquerorServer/wwwroot/DB/Characters.json";
    /// <summary>
    /// Ruta del json que contiene los ultimos id
    /// </summary>
    static public string pathLastID = @"../ConquerorServer/wwwroot/DB/Id.json";
    /// <summary>
    /// Ruta del json que contiene las cartas
    /// </summary>
    static public string pathCard = @"../ConquerorServer/wwwroot/DB/Card.json";
    /// <summary>
    /// Ruta de la carpeta que contiene las fotos de los personajes
    /// </summary>
    static public string pathCharactersImage = @"Images/Characters";
    /// <summary>
    /// Ruta a la foto por defecto de las cartas que se creen nuevas
    /// </summary>
    static public string pathCardsImage = @"images/cards/default.png";
    /// <summary>
    /// Vida con que inicia el juego
    /// </summary>
    static public int basicLife = 50;
    /// <summary>
    /// Cantidad de cartas con que inicia el juego cada jugador
    /// </summary>
    static public int startingCards = 10;
    /// <summary>
    /// Cantidad de charms
    /// </summary>
    static public int defaultCharms = 5;
    /// <summary>
    /// Nombres de las funciones definidas en el lenguaje
    /// </summary>
    public static string[] functions = { "Draw", "ChangeHands", "DrawFromEnemy" };  
}