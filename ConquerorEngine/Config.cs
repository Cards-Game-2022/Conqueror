namespace Conqueror.Logic;

static class Config {
    static public string PathCharacters = @"../ConquerorServer/wwwroot/DB/Characters.json";
    static public string PathLastID = @"../ConquerorServer/wwwroot/DB/Id.json";
    static public string PathCard = @"../ConquerorServer/wwwroot/DB/Card.json";
    static public string PathImageCharacters = @"Images/Characters";
    static public string PathImageCards = @"images/cards/default.png";
    static public int BasicLife = 30;
    static public int StartingCardsCount = 5;
    static public string[] SystemVariables = { "MyLife", "EnemyLife" };
    static public int Charms = 5;
    public static string[] Names = { "Draw", "ChangeHands", "DrawFromEnemy" };  
}