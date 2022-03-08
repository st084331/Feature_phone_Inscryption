namespace MyGame;

public class Hedgehog: Card
{
    public Hedgehog()
    {
        blood_cost = 1;
        heal_points = 2;
        damage = 1;
        abilities = new List<string>() {"barbed"};
        name = "Hedgehog";
    }
}