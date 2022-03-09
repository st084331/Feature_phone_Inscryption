namespace MyGame;

public class Game_Field: Main_Components
{
    private Card[] slots;
    private int[] scales;

    public Game_Field()
    {
        scales = new int[] {0, 0};
        slots = new Card[8] {null, null, null, null, null, null, null, null};
    }

    public void set_damage_balance(int player_number, int damage)
    {
        this.scales[player_number - 1] += damage;
    }

    public int check_damage_balance()
    {
        return Math.Abs(scales[0] - scales[1]);
    }

    public Card get_slot(int i)
    {
        if (i >= 0 && i < 8) return slots[i];
        return null;
    }

    public Card[] get_first_part_slots()
    {
        Card[] first_slots = new[] {slots[0], slots[1], slots[2], slots[3]};
        return first_slots;
    }

    public Card[] get_second_part_slots()
    {
        Card[] second_slots = new[] {slots[4], slots[5], slots[6], slots[7]};
        return second_slots;
    }

    public int first_slots_counter()
    {
        int counter = 0;
        for (int i = 0; i < 4; i++)
        {
            if (slots[i] != null) counter++;
        }

        return counter;
    }
    
    public int second_slots_counter()
    {
        int counter = 0;
        for (int i = 4; i < 8; i++)
        {
            if (slots[i] != null) counter++;
        }

        return counter;
    }

    public bool set_slot(Card card, int i)
    {
        if (card == null)
        {
            slots[i] = null;
            return true;
        }
        if (slots[i] == null)
        {
            slots[i] = card;
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public void show_cards_first_side()
    {
        for(int i = 0; i < 4; i++)
        {
            if (slots[i] == null)
            {
                Console.WriteLine((i + 1) + ". Empty");
            }
            else if (slots[i].get_blood_cost() != 0)
            {
                Console.WriteLine((i+1) + ". " + slots[i].get_name() + " | Health: " + slots[i].get_heal_points() + " | Attack: " +
                                  slots[i].get_damage() + " | Blood Cost: " + slots[i].get_blood_cost() + slots[i].list_of_abilities());
            }
            else if (slots[i].get_bones_cost() != 0)
            {
                Console.WriteLine((i+1) + ". " + slots[i].get_name() + " | Health: " + slots[i].get_heal_points() + " | Attack: " +
                                  slots[i].get_damage() + " | Bones Cost: " + slots[i].get_bones_cost() + slots[i].list_of_abilities());
            }
            else
            {
                Console.WriteLine((i+1) + ". " + slots[i].get_name() + " | Health: " + slots[i].get_heal_points() + " | Attack: " +
                                  slots[i].get_damage() + slots[i].list_of_abilities());
            }
        }
    }
    
    public void show_cards_second_side()
    {
        for(int i = 4; i < 8; i++)
        {
            if (slots[i] == null)
            {
                Console.WriteLine((i - 3) + ". Empty");
            }
            else if (slots[i].get_blood_cost() != 0)
            {
                Console.WriteLine((i-3) + ". " + slots[i].get_name() + " | Health: " + slots[i].get_heal_points() + " | Attack: " +
                                  slots[i].get_damage() + " | Blood Cost: " + slots[i].get_blood_cost() + slots[i].list_of_abilities());
            }
            else if (slots[i].get_bones_cost() != 0)
            {
                Console.WriteLine((i-3) + ". " + slots[i].get_name() + " | Health: " + slots[i].get_heal_points() + " | Attack: " +
                                  slots[i].get_damage() + " | Bones Cost: " + slots[i].get_bones_cost() + slots[i].list_of_abilities());
            }
            else
            {
                Console.WriteLine((i-3) + ". " + slots[i].get_name() + " | Health: " + slots[i].get_heal_points() + " | Attack: " +
                                  slots[i].get_damage() + slots[i].list_of_abilities());
            }
        }
    }

    public int[] get_scales()
    {
        return scales;
    }
}