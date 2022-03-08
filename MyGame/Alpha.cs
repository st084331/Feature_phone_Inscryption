namespace MyGame;

public class Alpha: Card
{
    public Alpha()
    {
        bones_cost = 5;
        damage = 1;
        heal_points = 2;
        abilities = new List<string>() {"leader"};
        name = "Alpha";
    }
}