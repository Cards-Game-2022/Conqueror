using System.Collections.Generic;
using Conqueror.Logic.Language;
namespace Conqueror.Logic;

static class Utils {
    public static void Error(string text) {
        throw new Exception(text);
    }
    /// <summary>
    /// Crea un scope basado en el estado actual del juego
    /// </summary>
    /// <param name="st">Estado actual del juego</param>
    public static Dictionary<string, int> CreateScope(Status st) {
        Dictionary<string, int> scope = new();
        scope.Add("MyLife", st.playerStatuses[0].life);
        scope.Add("EnemyLife", st.playerStatuses[1].life);
        scope.Add("MyCharms", st.playerStatuses[0].charms);
        scope.Add("EnemyCharms", st.playerStatuses[1].charms);
        return scope;
    }
    /// <summary>
    /// Crea un scope desde un estado inicial de juego predefinido
    /// </summary>
    public static Dictionary<string, int> CreateScope() {
        Dictionary<string, int> scope = new();
        scope.Add("MyLife", Config.BasicLife);
        scope.Add("EnemyLife", Config.BasicLife);
        scope.Add("MyCharms", Config.Charms);
        scope.Add("EnemyCharms", Config.Charms);
        return scope;
    }
    public static Dictionary<string, int> InterpretEffect(Dictionary<string, int> scope, string effect) {
        Lexer lexer = new Lexer(effect); 
        Parser pr = new Parser(lexer);
        Interpreter i = new Interpreter(pr, scope);
        i.Interpret();
        return i.Scope;
    }
} 