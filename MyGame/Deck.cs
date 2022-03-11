using System.Buffers;

namespace MyGame;

public class Deck: Main_Components
{
    private Card_Maker owner;
    private List<Card> cards;

    public Deck(Card_Maker own)
    {
        owner = own;
        cards = new List<Card>();
        var rand = new Random();
        int r;
        // Делаем рандомную колоду карт
        for (int i = 0; i < 35; i++)
        {
            r = rand.Next(0,17);
            switch (r)
            {
                case 0:
                    cards.Add(new Alpha());
                    break;
                case 1:
                    cards.Add(new Coyote());
                    break;
                case 2:
                    cards.Add(new Ermine());
                    break;
                case 3:
                    cards.Add(new Frog());
                    break;
                case 4:
                    cards.Add(new Grizzly());
                    break;
                case 5:
                    cards.Add(new Hedgehog());
                    break;
                case 6:
                    cards.Add(new Huck());
                    break;
                case 7:
                    cards.Add(new Mantis());
                    break;
                case 8:
                    cards.Add(new Mole());
                    break;
                case 9:
                    cards.Add(new Opossum());
                    break;
                case 10:
                    cards.Add(new Otter());
                    break;
                case 11:
                    cards.Add(new Pack_Rat());
                    break;
                case 12:
                    cards.Add(new Sparrow());
                    break;
                case 13:
                    cards.Add(new Stink_Bug());
                    break;
                case 14:
                    cards.Add(new Turkey());
                    break;
                case 15:
                    cards.Add(new Viper());
                    break;
                case 16:
                    cards.Add(new Wolf());
                    break;
            }
        }
    }

    public void add_card(Card card)
    {
        this.cards.Add(card);
    }

    // Вытягивание карты из колоды
    public Card get_card(string choice)
    {
        // По дефолту это Белка
        Card res_card = new Squirrel();
        // Мы хотим получить белку или случайную карту?
        if (choice != "squirrel")
        {
            // Не пуста ли колода рандомных карт
            if (cards.Count != 0)
            {
                res_card = cards[cards.Count - 1];
                cards.Remove(res_card);
            }
        }
        return res_card;
    }

    public List<Card> deck_list()
    {
        return cards;
    }
    
    public int cards_counter()
    {
        return cards.Count;
    }
}