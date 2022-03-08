namespace MyGame;

public class Wolf: Card
{
    public Wolf()
    {
        blood_cost = 2;
        damage = 3;
        heal_points = 2;
        abilities = new List<string>();
        name = "Wolf";
    }
    
}