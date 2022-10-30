using System;
namespace Conqueror.Logic;

class Language {

    public Language() {

    }
    
    // valida si el efecto esta escrito correctamente
    public void IsValid(string efect) {

    }

    // interpreta el efecto y devuelve el nuevo estado del tablero
    public void Interpreter(string efect, Player p1, Player p2, bool isP1) {
        if (efect.Contains("=")) {
            char[] tokenSimple = "=".ToCharArray();
            string[] tokens = efect.Split(tokenSimple, System.StringSplitOptions.RemoveEmptyEntries);

            if(tokens.Length == 2) {
                bool mk = false;
                string variable = "";

                foreach (var item in Config.SystemVariables)
                {
                    if (tokens[0] == item) {
                        variable = item;
                        mk = true;
                        break;
                    }
                }

                if (mk == true) {
                    AlgebraicExpression alg = new AlgebraicExpression(tokens[1]);
                    int value = alg.Expr();

                    if (isP1 == true) {
                        if (variable == "MyLife") {
                            p1.Life = value;
                        }
                        else {
                            p2.Life = value;
                        }
                    }
                    else {
                        if (variable == "MyLife") {
                            p2.Life = value;
                        }
                        else {
                            p1.Life = value;
                        }
                    }
                }
                else {
                    throw new Exception("Error de sintaxis");
                }
            }
            else {
                throw new Exception("Error de sintaxis");
            }
        } 
    }

}