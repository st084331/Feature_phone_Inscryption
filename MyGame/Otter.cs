namespace MyGame;

public class Otter: Card
{
    public Otter()
    {
        blood_cost = 1;
        damage = 1;
        heal_points = 1;
        abilities = new List<string>() {"water"};
        name = "Otter";
    }
}