using System.Collections.Generic;
using Conqueror.Logic.Language;
namespace Conqueror.Logic;

static class Utils {

    /// <summary>
    /// Crea un Contexto basado en el estado actual del juego
    /// </summary>
    /// <param name="st">Estado actual del juego</param>
    public static Context CreateScope(Status st) {
        
        Context ctx = new Context();
        ctx.Add(new Token("INT", "MyLife"), st.playerStatuses[0].life);
        ctx.Add(new Token("INT", "EnemyLife"), st.playerStatuses[1].life);
        ctx.Add(new Token("INT", "MyCharms"), st.playerStatuses[0].charms);
        ctx.Add(new Token("INT", "EnemyCharms"), st.playerStatuses[1].charms);
        ctx.Add(new Token("CONST", "CantMyCards"), st.playerStatuses[0].playerHand.Count);

        return ctx;
    }
    
    /// <summary>
    /// Crea un Contexto desde un estado inicial de juego predefinido
    /// </summary>
    public static Context CreateScope() {
        Context ctx = new Context();
        ctx.Add(new Token("INT", "MyLife"), Config.basicLife);
        ctx.Add(new Token("INT", "EnemyLife"), Config.basicLife);
        ctx.Add(new Token("INT", "MyCharms"), Config.defaultCharms);
        ctx.Add(new Token("INT", "EnemyCharms"), Config.defaultCharms);
        ctx.Add(new Token("CONST", "CantMyCards"), Config.startingCards);
        return ctx;
    }
    
    /// <summary>
    /// Interpreta un efecto
    /// </summary>
    /// <param name="scope">contexto actual del juego</param>
    /// <param name="effect">efecto a interpretar</param>
    /// <returns></returns>
    public static Context InterpretEffect(Context scope, string effect) {
        Lexer lexer = new Lexer(effect); 
        Parser pr = new Parser(lexer);
        Interpreter i = new Interpreter(pr, scope);
        i.Interpret();
        
        return scope;
    }

    /// <summary>
    /// Lanza una excepcion
    /// </summary>
    /// <param name="text">texto de la excepcion</param>
    public static void Error(string text) {
        throw new Exception(text);
    }
} 