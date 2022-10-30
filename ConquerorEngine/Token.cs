namespace Conqueror.Logic;

class Token {
    public string Type {
        private set; get;
    }
    public char Value {
        private set; get;
    }

    public Token(string type, char value) { 
        Type = type;
        Value = value;
    }
}