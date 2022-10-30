namespace Conqueror.Logic;

class Card {
    private string name;
    private int cost;
    private string text;
    private string effect;
    private int id;
    private string urlPhoto;

    public string Name {
        get { return name; }
        set { name = value; }
    }
    public int Cost {
        get { return cost; }
        set { cost = value; }
    }
    public string Text {
        get { return text; }
        set { text = value; }
    }
    public string Effect {
        get { return effect; }
        set { effect = value; }
    }
    public int Id {
        get { return id; }
        set { id = value; }
    }
    public string UrlPhoto {
        get { return urlPhoto; }
        set { urlPhoto = value; }
    }


    public Card(int id) {
        this.id = id;
    }
    public Card(string name, int cost, string text, string efect, int id, string urlPhoto) {
        this.name = name;
        this.cost = cost;
        this.text = text;
        this.effect = efect;
        this.urlPhoto = urlPhoto;
        this.id = id;
    }
}