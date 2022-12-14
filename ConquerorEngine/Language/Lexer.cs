using System;
using Conqueror.Logic;
namespace Conqueror.Logic.Language;

class Lexer {
    private string text;
    private int pos;
    private char currentChar;
    public Lexer(string text) {
        this.text = text;
        this.pos = 0;
        this.currentChar = text[pos];
    }

    private void Advance() {
        // avanza pos y establece el nuevo currentChar
        pos++;
        if (pos > text.Length - 1) { 
            currentChar = '~'; // indica fin
        } else {
            currentChar = text[pos];
        }
    }

    // para ver el siguiente caracter sin moverme a el
    private char Peek() {
        int peekPos = pos + 1;
        if (peekPos > text.Length - 1) {
            return '~';
        } else {
            return text[peekPos];
        }
    }

    private void SkipWhiteSpace() {
        while (currentChar != '~' && IsSpace(currentChar)) {
            Advance();
        }
    }

    // retorna un entero multidigito
    private int Integer() {
        string result = ""; 

        while (currentChar != '~' && IsNum(currentChar)) {
            result += currentChar;  
            Advance();
        }  
        return Int32.Parse(result);
    }

    private Token Id() {
        string result = "";
        while (currentChar != '~' && IsAlfNum(currentChar)) {
            result += currentChar;
            Advance();
        }

        if (IsFunction(result)) {
            return new Token("FUNCTION", result);
        }

        switch (result) { 
            case "if":
                return new Token("IF", "if");
            case "while":
                return new Token("WHILE", "while"); 

            default:
                return new Token("ID", result);
        }
    }
   
    public Token GetNextToken() {

        while (currentChar != '~') {
            if (IsSpace(currentChar)) {
                SkipWhiteSpace();
                continue;
            }
            if (IsNum(currentChar)) { 
                return new Token("INT", Integer().ToString());
            }
            if (currentChar == '+') { 
                Advance();
                return new Token("PLUS", "+");
            }
            if (currentChar == '-') { 
                Advance();
                return new Token("MINUS", "-");
            }
            if (currentChar == '*') {
                Advance();
                return new Token("MUL", "*");
            }
            if (currentChar == '/') { 
                Advance();
                return new Token("DIV", "/");
            }
            if (currentChar == '(') { 
                Advance();
                return new Token("LPAREN", "(");
            }
            if (currentChar == ')') { 
                Advance();
                return new Token("RPAREN", ")");
            }
            if (currentChar == '<') { 
                Advance();
                return new Token("LESS", "<");
            }
            if (currentChar == '>') { 
                Advance();
                return new Token("MORE", ">");
            }
            if (currentChar == '&') { 
                Advance();
                return new Token("AND", "&");
            }
            if (currentChar == '|') { 
                Advance();
                return new Token("OR", "|");
            }
            if (IsAlpha(currentChar)) {
                return Id();
            }
            if (currentChar == '=') {
                Advance(); 
                if (currentChar != '=') {
                    return new Token("ASSIGN", "=");
                } else { 
                    Advance();
                    return new Token("EQUAL", "==");
                }
            } 
            if (currentChar == ';') {
                Advance();
                return new Token("SEMI", ";");
            }
            if (currentChar == '.') {
                Advance();
                return new Token("DOT", ".");
            }
            if (currentChar == '{') { 
                Advance();
                return new Token("BEGIN", "{");
            }
            if (currentChar == '}') { 
                Advance();
                return new Token("END", "}");
            }
            Utils.Error("Caracter invalido");
        }     
        return new Token("EOF", "~");
    }

    private bool IsNum(char ch) {
        return (ch > 47 && ch < 58);
    }
    private bool IsAlfNum(char ch) {
        return IsNum(ch) || (ch > 64 && ch < 123);
    }
    private bool IsAlpha(char ch) {
        return ch > 64 && ch < 123;
    }
    private bool IsSpace(char ch) {
        return ch == '\n' || ch == '\r' || ch == ' ';
    }

    private bool IsFunction(string name) {
        foreach (var item in Config.functions) {
            if (item == name) {
                return true;
            }
        }
        return false;
    }
}