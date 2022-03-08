namespace MyGame;

public class Stink_Bug: Card
{
    public Stink_Bug()
    {
        name = "Stink Bug";
        damage = 1;
        heal_points = 2;
        bones_cost = 2;
        abilities = new List<string>() {"stinky"};
    }
}