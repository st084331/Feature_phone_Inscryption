namespace MyGame;

public class Turkey: Card
{
    public Turkey()
    {
        bones_cost = 8;
        damage = 3;
        heal_points = 3;
        abilities = new List<string>() {"fly"};
        name = "Turkey";
    }
}