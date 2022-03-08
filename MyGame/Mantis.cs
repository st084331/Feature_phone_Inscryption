namespace MyGame;

public class Mantis: Card
{
    public Mantis()
    {
        blood_cost = 1;
        damage = 1;
        heal_points = 1;
        abilities = new List<string>() {"double kicker"};
        name = "Mantis";
    }
}