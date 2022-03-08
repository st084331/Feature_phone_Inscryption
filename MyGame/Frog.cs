namespace MyGame;

public class Frog: Card
{
    public Frog()
    {
        name = "Frog";
        damage = 1;
        heal_points = 3;
        abilities = new List<string>() {"antifly"};
        blood_cost = 1;
    }
}