using Microsoft.VisualBasic.CompilerServices;
using System; 
using Conqueror.Logic.Interpreter;
namespace Conqueror.Logic;

class Language {
    private Lexer lexer;
    private Token currentToken;
    public Language(Lexer lexer) {
        this.lexer = lexer;
        currentToken = lexer.GetNextToken(); 
    }
    
    
    public void IsValid(string effect) {
        // valida si el effecto esta escrito correctamente
    }

    private void Eat(string tokenType) {
        // Compara el tipo token actual con el pasado tipo y si son lo mismo asigna
        // asigna al siguiente token al actual sino lanza excepcion
        //Console.WriteLine(tokenType + " " + currentToken.Type);
        if (currentToken.Type == tokenType) {
            //Console.WriteLine(currentToken.Value);
            currentToken = lexer.GetNextToken();
        }
        else {
            Utils.Error("Sintaxis invalida");
        }
    }

    private string Factor() {
        // factor: INT | LPAREN expr RPAREN
        // interos y parentesis
        Token token = currentToken;
        //Console.WriteLine(token.Value + " " + token.Type);
        if (token.Type == "INT") {
            Eat("INT");
            return token.Value;
        }
        else {
            if (token.Type == "LPAREN") {
                Eat("LPAREN");

                int result = Expr();

                Eat("RPAREN");
                
                return result.ToString();
            }
            
        } 

        Utils.Error("Error de sintaxis");
        return "";
    }

    private int Term() {
        // term: factor((* | /) factor)
        int result = Int32.Parse(Factor());
        //Console.WriteLine(result);

        while (currentToken.Type == "OP") {
            Token token = currentToken;
            //Console.WriteLine(token.Value + " " + token.Type);

            if (token.Value == "*") {
                Eat("OP");
                result *= Int32.Parse(Factor());
            }
            else {
                if (token.Value == "/") {
                    Eat("OP");
                    int factor = Int32.Parse(Factor());

                    if (factor == 0) {
                        Utils.Error("Division por cero");
                    }
                    result = result / factor;
                }
                else {
                    //Console.WriteLine(token.Value + " " + currentToken.Value);
                    break;
                }
            }
        }

        return result;
    }

    public int Expr() {
        // expresion aritmetica parser
        // expr : factor((+ | -) factor)*
        // term : factor((* | /) factor
        // factor: INT ? | LPAREN expr RPAREN
 
        int result = Term(); 
        //Console.WriteLine(result + "HOla");

        while (currentToken.Type == "OP") {
            Token token = currentToken;
            //Console.WriteLine(token.Value + " " + token.Type);

            if (token.Value == "+") {        
                Eat("OP"); 

                result += Term();
                Console.WriteLine("hola");
            }
            else {
                if (token.Value == "-") {
                    Eat("OP");

                    result -= Term();
                }
                else {
                    break;
                }
            }
        }

        // para casos como 1*(10+10))*10 10
        if (currentToken.Type == "RPAREN") {
            return result;
        }
        
        // para casos como: 10 / 10* 1 * 2 13
        if (currentToken.Type != "EOF") {
            Utils.Error("Sintaxis invalida");
        }

        return result;
    }


    // interpreta el effecto y devuelve el nuevo estado del tablero
    public void Interpreter(string effect, Player p1, Player p2, bool isP1) {

    }
}