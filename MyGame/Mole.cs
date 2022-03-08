namespace MyGame;

public class Mole: Card
{
    public Mole()
    {
        blood_cost = 1;
        damage = 0;
        heal_points = 4;
        abilities = new List<string>() {"antifly", "digging"};
        name = "Mole";
    }
}