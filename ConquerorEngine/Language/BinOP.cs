namespace Conqueror.Logic.Interpreter;

// clase para guardar operadores binarios en los nodos
class BinOp : AST{
    public int Left {
        get; private set;
    }
    public string Token {
        get; private set;
    }
    public string Op {
        get; private set;
    }
    public int Right {
        get; private set;
    }

    public BinOp(int left, string op, int right) {
        this.Left = left;
        this.Token = this.Op = op;
        this.Right = right;
    }
}