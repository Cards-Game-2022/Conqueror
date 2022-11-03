namespace Conqueror.Logic;

class Id {
    private int card;
    private int character;

    public int Card {
        get { return card; }
        set { card = value; }
    }
    public int Character {
        get { return character; }
        set { character = value; }
    }

    public Id(int card, int character) {
        this.card = card;
        this.character = character;
    }
}