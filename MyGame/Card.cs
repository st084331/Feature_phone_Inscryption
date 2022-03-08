namespace MyGame;

public class Card
{
    protected int heal_points;
    protected int damage;
    protected List<string> abilities;
    protected string name;
    protected int blood_cost;
    protected int bones_cost;

    public void set_name(string NAME)
    {
        this.name = NAME;
    }

    public string get_name()
    {
        return this.name;
    }

    public List<string> get_abilities()
    {
        return abilities;
    }

    public int get_heal_points()
    {
        return this.heal_points;
    }

    public void set_heal_points(int HEAL)
    {
        this.heal_points = HEAL;
    }

    public int get_damage()
    {
        return this.damage;
    }

    public void set_damage(int DAMAGE)
    {
        this.damage = DAMAGE;
    }
    
    public int get_blood_cost()
    {
        return blood_cost;
    }
    
    public int get_bones_cost()
    {
        return bones_cost;
    }

    public bool is_fly()
    {
        foreach (var abil in abilities)
        {
            if (abil == "fly") return true;
        }

        return false;
    }
    
    public bool is_antifly()
    {
        foreach (var abil in abilities)
        {
            if (abil == "antifly") return true;
        }

        return false;
    }
    
    public bool is_leader()
    {
        foreach (var abil in abilities)
        {
            if (abil == "leader") return true;
        }

        return false;
    }
    
    public bool is_barbed()
    {
        foreach (var abil in abilities)
        {
            if (abil == "barbed") return true;
        }

        return false;
    }
    
    public bool is_double_kicker()
    {
        foreach (var abil in abilities)
        {
            if (abil == "double kicker") return true;
        }

        return false;
    }
    
    public bool is_digging()
    {
        foreach (var abil in abilities)
        {
            if (abil == "digging") return true;
        }

        return false;
    }
    
    public bool is_water()
    {
        foreach (var abil in abilities)
        {
            if (abil == "water") return true;
        }

        return false;
    }
    
    public bool is_backpack()
    {
        foreach (var abil in abilities)
        {
            if (abil == "backpack") return true;
        }

        return false;
    }
    
    public bool is_stinky()
    {
        foreach (var abil in abilities)
        {
            if (abil == "stinky") return true;
        }

        return false;
    }
    
    public bool is_poison()
    {
        foreach (var abil in abilities)
        {
            if (abil == "poison") return true;
        }

        return false;
    }

    public string list_of_abilities()
    {
        if (abilities.Count != 0)
        {
            string res = " | List of abilities: ";
            foreach (var ab in abilities)
            {
                res += (ab + " ");
            }

            return res;
        }

        return "";
    }
}