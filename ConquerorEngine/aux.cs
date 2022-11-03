namespace Conqueror.Logic;
using Microsoft.VisualBasic.CompilerServices;

using System;

using System.Text.Json; 

public class Suggestion {
    private class Words {
        public List<string[]>? sinonimos { get; set; }
    }

    private List<string[]> Synonyms; 

    public Suggestion( string pathdb ) { // Constructor
        if (File.Exists(pathdb) == false) {
            return;
        }
        
        // Leer el Json y guardarlo en un string
        string dbString = File.ReadAllText(pathdb);

        // Convertir el string con el json a una structura de datos
        Words db = JsonSerializer.Deserialize<Words>(dbString)!;
        
        // Guardar el contenido de los sinonimos
        this.Synonyms = db.sinonimos!;

        foreach (var item in this.Synonyms)
        {
            foreach (var i in item)
            {
                //Console.WriteLine(i);
            }
        }
    }

    public Suggestion() {
        this.Synonyms = new List<string[]>();
    }
}