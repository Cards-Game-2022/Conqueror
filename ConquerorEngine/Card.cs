namespace Conqueror.Logic;

public class Card {
    private string name;
    private int cost;    
    private int rarity;
    private string text;
    private string effect;
    private int id;
    private string urlPhoto;

    public string Name {
        get; private set;
    }
    public int Cost {
        get; private set;
    }
    public int Rarity{
        get; private set;

    }
    public string Text {
        get; private set;
    }
    public string Effect {
        get; private set;
    }
    public int Id {
        get; private set;
    }
    public string UrlPhoto {
        get; private set;
    }


        /// <summary>
        ///if rarity is 1, the card is legendary
        /// if rarity is 2, the card is rare
        /// if rarity is 3, the card is special
        /// if rarity is 4, the card is common
        /// if rarity is 5, the card is basic
        /// </summary>
 

    public Card(){}
    public Card(string name, int cost, int id, int rarity, string effect) {
        
        this.name = name;
        this.id = id;
        this.effect = effect;

        if(cost>=0)
        this.cost = cost;
        else
        throw new Exception();

        if(rarity>0)
        this.rarity = rarity;
        else
        throw new Exception();


    }

    public Card(string name, int cost, int id, int rarity, string effect, string text) {
        
        this.name = name;
        this.id = id;
        this.effect = effect;
        this.text = text;

        
        if(cost>=0)
        this.cost = cost;
        else
        throw new Exception();

        if(rarity>0)
        this.rarity = rarity;
        else
        throw new Exception();



    }
    
    public Card(string urlPhoto, string name, int cost, int id, int rarity, string effect) {
        
        this.urlPhoto = urlPhoto;
        this.name = name;
        this.id = id;
        this.effect = effect;

        if(cost>=0)
        this.cost = cost;
        else
        throw new Exception();

        if(rarity>0)
        this.rarity = rarity;
        else
        throw new Exception();



    }
    public Card(string name, int cost, int id, int rarity, string effect, string text, string urlPhoto) {
        
        this.name = name;
        this.id = id;
        this.effect = effect;
        this.text = text;
        this.urlPhoto = urlPhoto;


        if(cost>=0)
        this.cost = cost;
        else
        throw new Exception();

        if(rarity>0)
        this.rarity = rarity;
        else
        throw new Exception();


   
    }


    void InvoqueCard(Card card) {
        
        Hand.RemoveCard(card.id);

        //card.ApplyEffect;
    }
}