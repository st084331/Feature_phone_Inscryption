using System.Reflection.Metadata.Ecma335;

namespace MyGame;

public class Pack_Rat: Card
{
    public Pack_Rat()
    {
        blood_cost = 2;
        heal_points = 2;
        damage = 2;
        abilities = new List<string>() {"backpack"};
        name = "Pack Rat";
    }
}