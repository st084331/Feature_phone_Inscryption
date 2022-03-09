namespace MyGame;

public class Card_Maker: Main_Components
{
    private int player_number;
    private string name;
    private int bones;

    public Card_Maker(string NAME, int NUM)
    {
        this.name = NAME;
        this.player_number = NUM;
        this.bones = 0;
    }

    public void set_name(string NAME)
    {
        this.name = NAME;
    }

    public string get_name()
    {
        return this.name;
    }

    public void set_player_number(int NUM)
    {
        this.player_number = NUM;
    }

    public int get_player_number()
    {
        return this.player_number;
    }

    public void set_bones(int BONES)
    {
        this.bones = BONES;
    }

    public int get_bones()
    {
        return this.bones;
    }
}