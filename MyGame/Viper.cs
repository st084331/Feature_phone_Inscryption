namespace MyGame;

public class Viper: Card
{
    public Viper()
    {
        blood_cost = 2;
        heal_points = 1;
        damage = 1;
        abilities = new List<string>() {"poison"};
        name = "Viper";
    }
}