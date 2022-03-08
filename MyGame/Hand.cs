namespace MyGame;

public class Hand
{
    private List<Card> cards;
    private Card_Maker owner;
    public Hand(Card_Maker own)
    {
        this.owner = own;
        this.cards = new List<Card>();
    }

    public void take_card(Card card)
    {
        this.cards.Add(card);
    }

    public Card drop_card(int i)
    {
        Card choice = cards[i];
        cards.Remove(cards[i]);
        return choice;
    }

    public List<Card> get_cards_on_hand()
    {
        return cards;
    }

    public void show_cards()
    {
        Console.WriteLine("Here is what you have.");
        int i = 1;
        foreach (var card in cards)
        {
            if (card.get_blood_cost() != 0)
            {
                Console.WriteLine(i + ". " + card.get_name() + " | Health: " + card.get_heal_points() + " | Attack: " +
                                  card.get_damage() + " | Blood Cost: " + card.get_blood_cost() + card.list_of_abilities());
            }
            else if (card.get_bones_cost() != 0)
            {
                Console.WriteLine(i + ". " + card.get_name() + " | Health: " + card.get_heal_points() + " | Attack: " +
                                  card.get_damage() + " | Bones Cost: " + card.get_bones_cost() + card.list_of_abilities());
            }
            else
            {
                Console.WriteLine(i + ". " + card.get_name() + " | Health: " + card.get_heal_points() + " | Attack: " +
                                  card.get_damage() + card.list_of_abilities());
            }
            i++;
        }
    }
}