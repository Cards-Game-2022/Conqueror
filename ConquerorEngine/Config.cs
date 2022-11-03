namespace Conqueror.Logic;

static class Config {
    static public string pathCharacters = @"../ConquerorServer/wwwroot/DB/Characters.json";
    static public string pathLastID = @"../ConquerorServer/wwwroot/DB/Id.json";
    static public string pathCard = @"../ConquerorServer/wwwroot/DB/Card.json";
    static public string pathImageCharacters = @"Images/Characters";
    static public int basicLife = 30;
    static public string[] SystemVariables = { "MyLife", "EnemyLife" };
}