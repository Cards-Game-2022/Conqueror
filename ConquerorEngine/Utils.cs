using System.Collections.Generic;
using Conqueror.Logic.Language;
namespace Conqueror.Logic;

static class Utils {
    public static void Error(string text) {
        throw new Exception(text);
    }
    public static Dictionary<string, int> CreateScope() {
        Dictionary<string, int> scope;
        scope = new Dictionary<string, int>();
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