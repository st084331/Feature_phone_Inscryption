namespace MyGame;

public class Grizzly: Card
{
    public Grizzly()
    {
        blood_cost = 3;
        heal_points = 6;
        damage = 4;
        abilities = new List<string>();
        name = "Grizzly";
    }
}