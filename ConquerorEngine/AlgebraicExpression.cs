namespace Conqueror.Logic;

class AlgebraicExpression
{
    private string text;
    private int pos;
    public AlgebraicExpression(string text) {
        this.text = text;
    }

    public int Expr() { 
        Token currentToken = GetNextToken(pos, text);
        pos++;

        Token left = new Token(currentToken.Type, currentToken.Value);
        if (!Eat("int", left)) {
            throw new System.Exception("Error de sintaxis");
        }

        Token op = GetNextToken(pos, text);
        pos++;
        if (!Eat("plus", op)) {
            throw new System.Exception("Error de sintaxis");
        }

        Token right = GetNextToken(pos, text);
        pos++;
        if (!Eat("int", right)) {
            throw new System.Exception("Error de sintaxis");
        }

        Console.WriteLine((int)left.Value + (int)right.Value - 48 * 2);
        return (int)left.Value + (int)right.Value - 48 * 2;
    }


    private bool Eat(string type, Token token) {
        if (token.Type == type) {
            return true;
        }
        else {
            return false;
        }
    }

    private Token GetNextToken(int pos, string text) {
        Token token = null;
        if (text[pos] > 48 && text[pos] < 58) {
            token = new Token("int", text[pos]);
            return token;
        }

        if (text[pos] == '+') {
            token = new Token("plus", '+');
            return token;
        }

        return token;
    }
}