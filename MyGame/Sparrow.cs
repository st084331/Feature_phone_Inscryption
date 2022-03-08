namespace MyGame;

public class Sparrow: Card
{
    public Sparrow()
    {
        blood_cost = 1;
        heal_points = 2;
        damage = 1;
        abilities = new List<string>() {"fly"};
        name = "Sparrow";
    }
}