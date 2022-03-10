using MyGame;

class Program: Main_Components
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of Game Mode:\n1. Person Vs Person\n2. Boss Fight (AI vs Person)\n3. Bot battle");
        int choice = 0;
        while (choice < 1 || choice > 3)
        {
            choice = Convert.ToInt32(Console.ReadLine());
        }

        switch (choice)
        {
            case 1:
                PersonVsPerson();
                break;
            case 2:
                Boss_Fight();
                break;
            case 3:
                AIVsAI();
                break;
        }
    }

    static void Boss_Fight()
    {
        var rand = new Random();
        int r = rand.Next(0, 2);
        switch (r)
        {
            case 0:
                AIVsPerson();
                break;
            case 1:
                PersonVsAI();
                break;
        }
    }
    static void first_player_atack(Game_Field gameField, Card_Maker Player1, Card_Maker Player2)
    {
        for (int i = 0; i < 4; i++)
        {
            corpse_cleaning(gameField, Player1, Player2);
            if (gameField.get_slot(i) != null)
            {
                int stink = 0;
                int leader_effect = 0;
                int poison_effect = 0;
                if (i > 0)
                {
                    if (gameField.get_slot(i - 1) != null)
                    {
                        if (gameField.get_slot(i - 1).is_leader())
                        {
                            leader_effect++;
                        }
                    }
                }

                if (i < 3)
                {
                    if (gameField.get_slot(i + 1) != null)
                    {
                        if (gameField.get_slot(i + 1).is_leader())
                        {
                            leader_effect++;
                        }
                    }
                }

                if (gameField.get_slot(i + 4) != null)
                {
                    if (gameField.get_slot(i).get_damage() > 0 || leader_effect > 0)
                    {
                        stink = Convert.ToInt32(gameField.get_slot(i + 4).is_stinky());
                    }
                }

                if (gameField.get_slot(i).is_poison() &&
                    (leader_effect > 0 || gameField.get_slot(i).get_damage() > 0))
                {
                    poison_effect = 100000000;
                }

                if (gameField.get_slot(i).is_double_kicker())
                {
                    Console.WriteLine("Ben");
                    if (i < 3)
                    {
                        if (gameField.get_slot(i + 5) != null)
                        {
                            if (((!gameField.get_slot(i + 5).is_antifly()) && gameField.get_slot(i).is_fly()) ||
                                (gameField.get_slot(i + 5).is_water()))
                            {
                                Console.WriteLine("wtf?");
                                gameField.set_damage_balance(2,
                                    gameField.get_slot(i).get_damage() + leader_effect - stink);
                            }
                            else
                            {
                                gameField.get_slot(i + 5).set_heal_points(
                                    gameField.get_slot(i + 5).get_heal_points() -
                                    gameField.get_slot(i).get_damage() + stink - leader_effect - poison_effect);
                                if (gameField.get_slot(i + 5).is_barbed() &&
                                    (gameField.get_slot(i).get_damage() - stink > 0 || leader_effect - stink > 0))
                                {
                                    gameField.get_slot(i)
                                        .set_heal_points(gameField.get_slot(i).get_heal_points() - 1);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("whyyyyyy");
                            gameField.set_damage_balance(2,
                                gameField.get_slot(i).get_damage() + leader_effect - stink);
                        }
                    }

                    if (i > 0)
                    {
                        if (gameField.get_slot(i + 3) != null)
                        {
                            if ((!gameField.get_slot(i + 3).is_antifly() && gameField.get_slot(i).is_fly()) ||
                                (gameField.get_slot(i + 3).is_water()))
                            {
                                gameField.set_damage_balance(2,
                                    gameField.get_slot(i).get_damage() + leader_effect - stink);
                            }
                            else
                            {
                                gameField.get_slot(i + 3).set_heal_points(
                                    gameField.get_slot(i + 3).get_heal_points() -
                                    gameField.get_slot(i).get_damage() + stink - leader_effect - poison_effect);
                                if (gameField.get_slot(i + 3).is_barbed() &&
                                    (gameField.get_slot(i).get_damage() - stink > 0 || leader_effect - stink > 0))
                                {
                                    gameField.get_slot(i)
                                        .set_heal_points(gameField.get_slot(i).get_heal_points() - 1);
                                }
                            }
                        }
                        else
                        {
                            gameField.set_damage_balance(2,
                                gameField.get_slot(i).get_damage() + leader_effect - stink);
                        }
                    }
                }
                else
                {
                    if (gameField.get_slot(i + 4) != null)
                    {
                        if ((!gameField.get_slot(i + 4).is_antifly() && gameField.get_slot(i).is_fly()) ||
                            (gameField.get_slot(i + 4).is_water()))
                        {
                            gameField.set_damage_balance(2,
                                gameField.get_slot(i).get_damage() + leader_effect - stink);
                        }
                        else
                        {
                            gameField.get_slot(i + 4).set_heal_points(gameField.get_slot(i + 4).get_heal_points() -
                                gameField.get_slot(i).get_damage() + stink - leader_effect - poison_effect);
                            if (gameField.get_slot(i + 4).is_barbed() &&
                                (gameField.get_slot(i).get_damage() - stink > 0 || leader_effect - stink > 0))
                            {
                                gameField.get_slot(i).set_heal_points(gameField.get_slot(i).get_heal_points() - 1);
                            }
                        }
                    }
                    else
                    {
                        gameField.set_damage_balance(2, gameField.get_slot(i).get_damage() + leader_effect - stink);
                    }
                }
            }
        }
    }

    static void second_player_atack(Game_Field gameField, Card_Maker Player1, Card_Maker Player2)
    {
        for (int i = 4; i < 8; i++)
        {
            corpse_cleaning(gameField, Player1, Player2);
            if (gameField.get_slot(i) != null)
            {
                int stink = 0;
                int leader_effect = 0;
                int poison_effect = 0;
                if (i > 4)
                {
                    if (gameField.get_slot(i - 1) != null)
                    {
                        if (gameField.get_slot(i - 1).is_leader())
                        {
                            leader_effect++;
                        }
                    }
                }

                if (i < 7)
                {
                    if (gameField.get_slot(i + 1) != null)
                    {
                        if (gameField.get_slot(i + 1).is_leader())
                        {
                            leader_effect++;
                        }
                    }
                }

                if (gameField.get_slot(i - 4) != null)
                {
                    if (gameField.get_slot(i).get_damage() > 0 || leader_effect > 0)
                    {
                        stink = Convert.ToInt32(gameField.get_slot(i - 4).is_stinky());
                    }
                }

                if (gameField.get_slot(i).is_poison() &&
                    (leader_effect > 0 || gameField.get_slot(i).get_damage() > 0))
                {
                    poison_effect = 100000000;
                }

                if (gameField.get_slot(i).is_double_kicker())
                {
                    if (i < 7)
                    {
                        if (gameField.get_slot(i - 3) != null)
                        {
                            if ((!gameField.get_slot(i - 3).is_antifly() && gameField.get_slot(i).is_fly()) ||
                                (gameField.get_slot(i - 3).is_water()))
                            {
                                gameField.set_damage_balance(1,
                                    gameField.get_slot(i).get_damage() + leader_effect - stink);
                            }
                            else
                            {
                                gameField.get_slot(i - 3).set_heal_points(
                                    gameField.get_slot(i - 3).get_heal_points() -
                                    gameField.get_slot(i).get_damage() + stink - leader_effect - poison_effect);
                                if (gameField.get_slot(i - 3).is_barbed() &&
                                    (gameField.get_slot(i).get_damage() - stink > 0 || leader_effect - stink > 0))
                                {
                                    gameField.get_slot(i)
                                        .set_heal_points(gameField.get_slot(i).get_heal_points() - 1);
                                }
                            }
                        }
                        else
                        {
                            gameField.set_damage_balance(1,
                                gameField.get_slot(i).get_damage() + leader_effect - stink);
                        }
                    }

                    if (i > 4)
                    {
                        if (gameField.get_slot(i - 5) != null)
                        {
                            if ((!gameField.get_slot(i - 5).is_antifly() && gameField.get_slot(i).is_fly()) ||
                                (gameField.get_slot(i - 5).is_water()))
                            {
                                gameField.set_damage_balance(1,
                                    gameField.get_slot(i).get_damage() + leader_effect - stink);
                            }
                            else
                            {
                                gameField.get_slot(i - 5).set_heal_points(
                                    gameField.get_slot(i - 5).get_heal_points() -
                                    gameField.get_slot(i).get_damage() + stink - leader_effect - poison_effect);
                                if (gameField.get_slot(i - 5).is_barbed() &&
                                    (gameField.get_slot(i).get_damage() - stink > 0 || leader_effect - stink > 0))
                                {
                                    gameField.get_slot(i)
                                        .set_heal_points(gameField.get_slot(i).get_heal_points() - 1);
                                }
                            }
                        }
                        else
                        {
                            gameField.set_damage_balance(1,
                                gameField.get_slot(i).get_damage() + leader_effect - stink);
                        }
                    }
                }
                else
                {
                    if (gameField.get_slot(i - 4) != null)
                    {
                        if ((!gameField.get_slot(i - 4).is_antifly() && gameField.get_slot(i).is_fly()) ||
                            (gameField.get_slot(i - 4).is_water()))
                        {
                            gameField.set_damage_balance(1,
                                gameField.get_slot(i).get_damage() + leader_effect - stink);
                        }
                        else
                        {
                            gameField.get_slot(i - 4).set_heal_points(gameField.get_slot(i - 4).get_heal_points() -
                                gameField.get_slot(i).get_damage() + stink - leader_effect - poison_effect);
                            if (gameField.get_slot(i - 4).is_barbed() &&
                                (gameField.get_slot(i).get_damage() - stink > 0 || leader_effect - stink > 0))
                            {
                                gameField.get_slot(i).set_heal_points(gameField.get_slot(i).get_heal_points() - 1);
                            }
                        }
                    }
                    else
                    {
                        gameField.set_damage_balance(1, gameField.get_slot(i).get_damage() + leader_effect - stink);
                    }
                }
            }
        }
    }

    static void move_diggers(Game_Field gameField)
    {
        for (int i = 0; i < 4; i++)
        {
            if (gameField.get_slot(i) != null)
            {
                if (gameField.get_slot(i).is_digging())
                {
                    int max = 0;
                    int position = i;
                    for (int j = 4; j < 8; j++)
                    {
                        if (gameField.get_slot(j) != null)
                        {
                            if (gameField.get_slot(j).get_damage() > max && gameField.get_slot(j - 4) == null)
                            {
                                max = gameField.get_slot(j).get_damage();
                                position = j - 4;
                            }
                        }
                    }

                    if (position != i)
                    {
                        gameField.set_slot(gameField.get_slot(i), position);
                        gameField.set_slot(null, i);
                    }
                }
            }
        }

        for (int i = 4; i < 8; i++)
        {
            if (gameField.get_slot(i) != null)
            {
                if (gameField.get_slot(i).is_digging())
                {
                    int max = 0;
                    int position = i;
                    for (int j = 0; j < 4; j++)
                    {
                        if (gameField.get_slot(j) != null)
                        {
                            if (gameField.get_slot(j).get_damage() > max && gameField.get_slot(j + 4) == null)
                            {
                                max = gameField.get_slot(j).get_damage();
                                position = j + 4;
                            }
                        }
                    }

                    if (position != i)
                    {
                        gameField.set_slot(gameField.get_slot(i), position);
                        gameField.set_slot(null, i);
                    }
                }
            }
        }
    }

    static void corpse_cleaning(Game_Field gameField, Card_Maker Player1, Card_Maker Player2)
    {
        for (int i = 0; i < 8; i++)
        {
            if (gameField.get_slot(i) != null)
            {
                if (gameField.get_slot(i).get_heal_points() <= 0)
                {
                    gameField.set_slot(null, i);
                    if (i < 4)
                    {
                        Player1.set_bones(Player1.get_bones() + 1);
                    }
                    else
                    {
                        Player2.set_bones(Player2.get_bones() + 1); 
                    }
                }
            }
        }
    }

    static void first_AI_turn_strategy(Card_Maker Player1, Game_Field gameField, Hand hand1, Deck deck1)
    {
        Console.WriteLine(Player1.get_name() + " turn.");
        bool end = false;
        var rand = new Random();
        int r = rand.Next(0, 2);
        switch (r)
        {
            case 0:
                hand1.take_card(deck1.get_card(true));
                break;
            case 1:
                hand1.take_card(deck1.get_card(false));
                break;
        }

        int t = 0;
        Card[] check_slots = gameField.get_first_part_slots();
        while (hand1.get_cards_on_hand().Count != 0 && end == false)
        {
            check_slots = gameField.get_first_part_slots();
            t = 0;
            for (int i = 0; i < hand1.get_cards_on_hand().Count; i++)
            {
                if (hand1.get_cards_on_hand()[i].get_blood_cost() != 0)
                {
                    if (gameField.first_slots_counter() >= hand1.get_cards_on_hand()[i].get_blood_cost())
                    {
                        int go = 0;
                        foreach (var slot in gameField.get_first_part_slots())
                        {
                            if (slot != null)
                            {
                                if (slot.get_blood_cost() != 0)
                                {
                                    if (slot.get_blood_cost() < hand1.get_cards_on_hand()[i].get_blood_cost())
                                    {
                                        go++;
                                    }
                                }else if (slot.get_blood_cost() == 0 && slot.get_blood_cost() == 0 &&
                                          slot.get_damage() < hand1.get_cards_on_hand()[i].get_damage())
                                {
                                    go++;
                                }
                            }
                        }

                        if (go >= hand1.get_cards_on_hand()[i].get_blood_cost())
                        {
                            t = 0;
                            for (int k = 0; k < hand1.get_cards_on_hand()[i].get_blood_cost(); k++)
                            {
                                t = 0;
                                for (int j = 0; j < 4; j++)
                                {
                                    if (gameField.get_first_part_slots()[j] != null)
                                    {
                                        t = j;
                                    }
                                }

                                gameField.set_slot(null, t);
                                Player1.set_bones(Player1.get_bones() + 1);
                            }

                            t = 0;
                            for (int j = 3; j >= 0; j--)
                            {
                                if (gameField.get_first_part_slots()[j] == null)
                                {
                                    t = j;
                                }
                            }

                            gameField.set_slot(hand1.drop_card(i), t);
                            if (gameField.get_slot(t).is_backpack())
                            {
                                hand1.take_card(deck1.get_card(true));
                            }
                        }
                    }
                }
                else if (hand1.get_cards_on_hand()[i].get_bones_cost() != 0)
                {
                    if (gameField.first_slots_counter() != 4)
                    {
                        if (hand1.get_cards_on_hand()[i].get_bones_cost() <= Player1.get_bones())
                        {
                            t = 0;
                            for (int j = 3; j >= 0; j--)
                            {
                                if (gameField.get_first_part_slots()[j] == null)
                                {
                                    t = j;
                                }
                            }
                            Player1.set_bones(Player1.get_bones() -
                                              hand1.get_cards_on_hand()[i].get_bones_cost());
                            gameField.set_slot(hand1.drop_card(i), t);
                            if (gameField.get_slot(t).is_backpack())
                            {
                                hand1.take_card(deck1.get_card(true));
                            }
                        }
                    }
                }
                else
                {
                    if (gameField.first_slots_counter() != 4)
                    {
                        t = 0;
                        for (int j = 3; j >= 0; j--)
                        {
                            if (gameField.get_first_part_slots()[j] == null)
                            {
                                t = j;
                            }
                        }
                        gameField.set_slot(hand1.drop_card(i), t);
                        if (gameField.get_slot(t).is_backpack())
                        {
                            hand1.take_card(deck1.get_card(true));
                        }
                    }
                }
            }

            end = true;
            for (int h = 0; h < 4; h++)
            {
                if (check_slots[h] != null && gameField.get_first_part_slots()[h] != null)
                {
                    if (check_slots[h].get_name() != gameField.get_first_part_slots()[h].get_name())
                    {
                        end = false;
                    }
                }
                else if (check_slots[h] == null && gameField.get_first_part_slots()[h] != null)
                {
                    end = false;
                }
                else if (check_slots[h] != null && gameField.get_first_part_slots()[h] == null)
                {
                    end = false;
                }
            }
        }
    }

    static void second_AI_turn_strategy(Card_Maker Player2, Game_Field gameField, Hand hand2, Deck deck2)
    {
        Console.WriteLine(Player2.get_name() + " turn.");
        bool end = false;
        var rand = new Random();
        int r = rand.Next(0, 2);
        switch (r)
        {
            case 0:
                hand2.take_card(deck2.get_card(true));
                break;
            case 1:
                hand2.take_card(deck2.get_card(false));
                break;
        }
        int t = 4;
        Card[] check_slots = gameField.get_second_part_slots();
        while (hand2.get_cards_on_hand().Count != 0 && end == false)
        {
            t = 4;
            check_slots = gameField.get_second_part_slots();
            for (int i = 0; i < hand2.get_cards_on_hand().Count; i++)
            {
                if (hand2.get_cards_on_hand()[i].get_blood_cost() != 0)
                {
                    if (gameField.second_slots_counter() >= hand2.get_cards_on_hand()[i].get_blood_cost())
                    {
                        int go = 0;
                        foreach (var slot in gameField.get_second_part_slots())
                        {
                            if (slot != null)
                            {
                                if (slot.get_blood_cost() != 0)
                                {
                                    if (slot.get_blood_cost() < hand2.get_cards_on_hand()[i].get_blood_cost())
                                    {
                                        go++;
                                    }
                                }
                                else if (slot.get_blood_cost() == 0 && slot.get_blood_cost() == 0 &&
                                         slot.get_damage() < hand2.get_cards_on_hand()[i].get_damage())
                                {
                                    go++;
                                }
                            }
                        }

                        if (go >= hand2.get_cards_on_hand()[i].get_blood_cost())
                        {
                            t = 4;
                            for (int k = 0; k < hand2.get_cards_on_hand()[i].get_blood_cost(); k++)
                            {
                                t = 4;
                                for (int j = 4; j < 8; j++)
                                {
                                    if (gameField.get_second_part_slots()[j - 4] != null)
                                    {
                                        t = j;
                                    }
                                }

                                gameField.set_slot(null, t);
                                Player2.set_bones(Player2.get_bones() + 1);
                            }

                            t = 4;
                            for (int j = 7; j >= 4; j--)
                            {
                                if (gameField.get_second_part_slots()[j - 4] == null)
                                {
                                    t = j;
                                }
                            }

                            gameField.set_slot(hand2.drop_card(i), t);
                            if (gameField.get_slot(t).is_backpack())
                            {
                                hand2.take_card(deck2.get_card(true));
                            }
                        }
                    }
                }
                else if (hand2.get_cards_on_hand()[i].get_bones_cost() != 0)
                {
                    if (gameField.second_slots_counter() != 4)
                    {
                        if (hand2.get_cards_on_hand()[i].get_bones_cost() <= Player2.get_bones())
                        {
                            t = 4;
                            for (int j = 7; j >= 4; j--)
                            {
                                if (gameField.get_second_part_slots()[j - 4] == null)
                                {
                                    t = j;
                                }
                            }
                            Player2.set_bones(Player2.get_bones() - hand2.get_cards_on_hand()[i].get_bones_cost());
                            gameField.set_slot(hand2.drop_card(i), t);
                            
                            if (gameField.get_slot(t).is_backpack())
                            {
                                hand2.take_card(deck2.get_card(true));
                            }
                        }
                    }
                }
                else
                {
                    if (gameField.second_slots_counter() != 4)
                    {
                        t = 4;
                        for (int j = 7; j >= 4; j--)
                        {
                            if (gameField.get_second_part_slots()[j - 4] == null)
                            {
                                t = j;
                            }
                        }
                        gameField.set_slot(hand2.drop_card(i), t);
                        if (gameField.get_slot(t).is_backpack())
                        {
                            hand2.take_card(deck2.get_card(true));
                        }
                    }
                }
            }

            end = true;
            for (int h = 0; h < 4; h++)
            {
                if (check_slots[h] != null && gameField.get_second_part_slots()[h] != null)
                {
                    if (check_slots[h].get_name() != gameField.get_second_part_slots()[h].get_name())
                    {
                        end = false;
                    }
                }
                else if (check_slots[h] == null && gameField.get_second_part_slots()[h] != null)
                {
                    end = false;
                }
                else if (check_slots[h] != null && gameField.get_second_part_slots()[h] == null)
                {
                    end = false;
                }
            }
        }
    }
    
    static void first_player_turn_strategy(Card_Maker Player1, Game_Field gameField, Hand hand1, Deck deck1)
    {
        int hand_choice = 0;
        int sacrifice_choice = 0;
        int slot_choice = 0;
        bool end = false;
        Console.WriteLine("Your side:");
        gameField.show_cards_first_side();
        Console.WriteLine("Opponent side:");
        gameField.show_cards_second_side();
        Console.WriteLine("Your bones: " + Player1.get_bones());
        hand1.show_cards();
        Console.WriteLine("Take card! Would you like to take a squirrel or a random card?");
        hand1.take_card(deck1.get_card(Convert.ToBoolean(Console.ReadLine())));
        Console.WriteLine("Now you can play cards.");
        while (hand1.get_cards_on_hand().Count != 0 && end == false)
        {
            Console.WriteLine("Your side:");
            gameField.show_cards_first_side();
            Console.WriteLine("Opponent side:");
            gameField.show_cards_second_side();
            Console.WriteLine("Your bones: " + Player1.get_bones());
            hand1.show_cards();
            hand_choice = 0;
            sacrifice_choice = 0;
            slot_choice = 0;
            Console.WriteLine("Do you want to end your turn?");
            if (Convert.ToBoolean(Console.ReadLine()))
            {
                end = true;
            }
            else
            {
                end = false;
                Console.WriteLine("Let's place some cards! Enter the number that you want to place.");
                Console.WriteLine("Your side:");
                gameField.show_cards_first_side();
                Console.WriteLine("Opponent side:");
                gameField.show_cards_second_side();
                while (hand_choice < 1 || hand_choice > hand1.get_cards_on_hand().Count)
                {
                    hand_choice = Convert.ToInt32(Console.ReadLine());
                }

                if (hand1.get_cards_on_hand()[hand_choice - 1].get_blood_cost() != 0)
                {
                    if (gameField.first_slots_counter() >= hand1.get_cards_on_hand()[hand_choice - 1].get_blood_cost())
                    {
                        Console.WriteLine("Choose the creatures you will sacrifice.");
                        Console.WriteLine("Your side:");
                        gameField.show_cards_first_side();
                        Console.WriteLine("Opponent side:");
                        gameField.show_cards_second_side();
                        for (int k = 0; k < hand1.get_cards_on_hand()[hand_choice - 1].get_blood_cost(); k++)
                        {
                            sacrifice_choice = 0;
                            while (sacrifice_choice < 1 || sacrifice_choice > 4 ||
                                   gameField.get_first_part_slots()[sacrifice_choice - 1] == null)
                            {
                                sacrifice_choice = Convert.ToInt32(Console.ReadLine());
                            }

                            gameField.set_slot(null, sacrifice_choice - 1);
                            Player1.set_bones(Player1.get_bones() + 1);
                        }

                        Console.WriteLine("Place your card on empty slot.");
                        Console.WriteLine("Your side:");
                        gameField.show_cards_first_side();
                        Console.WriteLine("Opponent side:");
                        gameField.show_cards_second_side();
                        slot_choice = 0;
                        while (slot_choice < 1 || slot_choice > 4 ||
                               gameField.get_first_part_slots()[slot_choice - 1] != null)
                        {
                            slot_choice = Convert.ToInt32(Console.ReadLine());
                        }

                        gameField.set_slot(hand1.drop_card(hand_choice - 1), slot_choice - 1);
                        if (gameField.get_slot(slot_choice - 1).is_backpack())
                        {
                            hand1.take_card(deck1.get_card(true));
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough cards on game board.");
                    }
                }
                else if (hand1.get_cards_on_hand()[hand_choice - 1].get_bones_cost() != 0)
                {
                    if (gameField.first_slots_counter() != 4)
                    {
                        if (hand1.get_cards_on_hand()[hand_choice - 1].get_bones_cost() <= Player1.get_bones())
                        {
                            Console.WriteLine("Place your card on empty slot.");
                            Console.WriteLine("Your side:");
                            gameField.show_cards_first_side();
                            Console.WriteLine("Opponent side:");
                            gameField.show_cards_second_side();
                            slot_choice = 0;
                            while (slot_choice < 1 || slot_choice > 4 ||
                                   gameField.get_first_part_slots()[slot_choice - 1] != null)
                            {
                                slot_choice = Convert.ToInt32(Console.ReadLine());
                            }
                            Player1.set_bones(Player1.get_bones() -
                                              hand1.get_cards_on_hand()[hand_choice - 1].get_bones_cost());
                            gameField.set_slot(hand1.drop_card(hand_choice - 1), slot_choice - 1);
                            Console.WriteLine("Your bones: " + Player1.get_bones());
                            if (gameField.get_slot(slot_choice - 1).is_backpack())
                            {
                                hand1.take_card(deck1.get_card(true));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough bones.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Maximum cards on the board.");
                    }
                }
                else
                {
                    if (gameField.first_slots_counter() != 4)
                    {
                        Console.WriteLine("Place your card on empty slot.");
                        Console.WriteLine("Your side:");
                        gameField.show_cards_first_side();
                        Console.WriteLine("Opponent side:");
                        gameField.show_cards_second_side();
                        slot_choice = 0;
                        while (slot_choice < 1 || slot_choice > 4 ||
                               gameField.get_first_part_slots()[slot_choice - 1] != null)
                        {
                            slot_choice = Convert.ToInt32(Console.ReadLine());
                        }

                        gameField.set_slot(hand1.drop_card(hand_choice - 1), slot_choice - 1);
                        if (gameField.get_slot(slot_choice - 1).is_backpack())
                        {
                            hand1.take_card(deck1.get_card(true));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Maximum cards on the board.");
                    }
                }
            }
        }
    }

    static void second_player_turn_strategy(Card_Maker Player2, Game_Field gameField, Hand hand2, Deck deck2)
    {
        int hand_choice = 0;
        int sacrifice_choice = 0;
        int slot_choice = 0;
        bool end = false;
        Console.WriteLine("Your side:");
        gameField.show_cards_second_side();
        Console.WriteLine("Opponent side:");
        gameField.show_cards_first_side();
        Console.WriteLine("Your bones: " + Player2.get_bones());
        hand2.show_cards();
        Console.WriteLine("Take card! Would you like to take a squirrel or a random card?");
        hand2.take_card(deck2.get_card(Convert.ToBoolean(Console.ReadLine())));
        Console.WriteLine("Now you can play cards.");
        while (hand2.get_cards_on_hand().Count != 0 && end == false)
        {
            Console.WriteLine("Your side:");
            gameField.show_cards_second_side();
            Console.WriteLine("Opponent side:");
            gameField.show_cards_first_side();
            Console.WriteLine("Your bones: " + Player2.get_bones());
            hand2.show_cards();
            hand_choice = 0;
            sacrifice_choice = 0;
            slot_choice = 0;
            Console.WriteLine("Do you want to end your turn?");
            if (Convert.ToBoolean(Console.ReadLine()))
            {
                end = true;
            }
            else
            {
                end = false;
                Console.WriteLine("Let's place some cards! Enter the number that you want to place.");
                while (hand_choice < 1 || hand_choice > hand2.get_cards_on_hand().Count)
                {
                    hand_choice = Convert.ToInt32(Console.ReadLine());
                }

                if (hand2.get_cards_on_hand()[hand_choice - 1].get_blood_cost() != 0)
                {
                    if (gameField.second_slots_counter() >=
                        hand2.get_cards_on_hand()[hand_choice - 1].get_blood_cost())
                    {
                        Console.WriteLine("Choose the creatures you will sacrifice.");
                        Console.WriteLine("Your side:");
                        gameField.show_cards_second_side();
                        Console.WriteLine("Opponent side:");
                        gameField.show_cards_first_side();
                        for (int k = 0; k < hand2.get_cards_on_hand()[hand_choice - 1].get_blood_cost(); k++)
                        {
                            sacrifice_choice = 0;
                            while (sacrifice_choice < 1 || sacrifice_choice > 4 ||
                                   gameField.get_second_part_slots()[sacrifice_choice - 1] == null)
                            {
                                sacrifice_choice = Convert.ToInt32(Console.ReadLine());
                            }

                            gameField.set_slot(null, sacrifice_choice + 3);
                            Player2.set_bones(Player2.get_bones() + 1);
                        }

                        Console.WriteLine("Place your card on empty slot.");
                        Console.WriteLine("Your side:");
                        gameField.show_cards_second_side();
                        Console.WriteLine("Opponent side:");
                        gameField.show_cards_first_side();
                        slot_choice = 0;
                        while (slot_choice < 1 || slot_choice > 4 ||
                               gameField.get_second_part_slots()[slot_choice - 1] != null)
                        {
                            slot_choice = Convert.ToInt32(Console.ReadLine());
                        }

                        gameField.set_slot(hand2.drop_card(hand_choice - 1), slot_choice + 3);
                        if (gameField.get_slot(slot_choice + 3).is_backpack())
                        {
                            hand2.take_card(deck2.get_card(true));
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough cards on game board.");
                    }
                }
                else if (hand2.get_cards_on_hand()[hand_choice - 1].get_bones_cost() != 0)
                {
                    if (gameField.second_slots_counter() != 4)
                    {
                        if (hand2.get_cards_on_hand()[hand_choice - 1].get_bones_cost() <= Player2.get_bones())
                        {
                            Console.WriteLine("Place your card on empty slot.");
                            Console.WriteLine("Your side:");
                            gameField.show_cards_second_side();
                            Console.WriteLine("Opponent side:");
                            gameField.show_cards_first_side();
                            slot_choice = 0;
                            while (slot_choice < 1 || slot_choice > 4 ||
                                   gameField.get_second_part_slots()[slot_choice - 1] != null)
                            {
                                slot_choice = Convert.ToInt32(Console.ReadLine());
                            }
                            Player2.set_bones(Player2.get_bones() -
                                              hand2.get_cards_on_hand()[hand_choice - 1].get_bones_cost());
                            gameField.set_slot(hand2.drop_card(hand_choice - 1), slot_choice + 3);
                            Console.WriteLine("Your bones: " + Player2.get_bones());
                            if (gameField.get_slot(slot_choice + 3).is_backpack())
                            {
                                hand2.take_card(deck2.get_card(true));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough bones.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Maximum cards on the board.");
                    }
                }
                else
                {
                    if (gameField.second_slots_counter() != 4)
                    {
                        Console.WriteLine("Place your card on empty slot.");
                        Console.WriteLine("Your side:");
                        gameField.show_cards_second_side();
                        Console.WriteLine("Opponent side:");
                        gameField.show_cards_first_side();
                        slot_choice = 0;
                        while (slot_choice < 1 || slot_choice > 4 ||
                               gameField.get_second_part_slots()[slot_choice - 1] != null)
                        {
                            slot_choice = Convert.ToInt32(Console.ReadLine());
                        }

                        gameField.set_slot(hand2.drop_card(hand_choice - 1), slot_choice + 3);
                        if (gameField.get_slot(slot_choice + 3).is_backpack())
                        {
                            hand2.take_card(deck2.get_card(true));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Maximum cards on the board.");
                    }
                }
            }
        }
    }

    static void PersonVsPerson()
    {
        Card_Maker Player1 = new Card_Maker("Abobus", 1);
        Card_Maker Player2 = new Card_Maker("Buba", 2);
        Game_Field gameField = new Game_Field();
        Hand hand1 = new Hand(Player1);
        Hand hand2 = new Hand(Player2);
        Deck deck1 = new Deck(Player1);
        Deck deck2 = new Deck(Player2);
        for (int j = 0; j < 5; j++)
        {
            hand1.take_card(deck1.get_card(true));
            hand2.take_card(deck2.get_card(true));
        }

        Console.WriteLine(Player1.get_name() + " turn, you cannot attack this round.");
        first_player_turn_strategy(Player1, gameField, hand1, deck1);
        move_diggers(gameField);

        //MAIN PHASE

        while (gameField.check_damage_balance() <= 5)
        {
            if (deck2.cards_counter() == 0)
            {
                deck2 = new Deck(Player2);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(Player2.get_name() + " turn, you can attack this round.");
            
            second_player_turn_strategy(Player2, gameField, hand2, deck2);
            
            move_diggers(gameField);
            
            Console.WriteLine("BATTLE!");
            second_player_atack(gameField, Player1, Player2);
            corpse_cleaning(gameField, Player1, Player2);

            Console.WriteLine("Your side:");
            gameField.show_cards_second_side();
            Console.WriteLine("Opponent side:");
            gameField.show_cards_first_side();
            
            Console.WriteLine("Your scales: " + gameField.get_scales()[1]);
            Console.WriteLine("Opponent scales: " + gameField.get_scales()[0]);
            //---------------------------------------------------
            if (gameField.check_damage_balance() <= 5)
            {
                if (deck1.cards_counter() == 0)
                {
                    deck1 = new Deck(Player1);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(Player1.get_name() + " turn, you can attack this round.");
                
                first_player_turn_strategy(Player1, gameField, hand1, deck1);
                
                move_diggers(gameField);
                
                Console.WriteLine("BATTLE!");
                first_player_atack(gameField, Player1, Player2);
                corpse_cleaning(gameField, Player1, Player2);

                Console.WriteLine("Your side:");
                gameField.show_cards_first_side();
                Console.WriteLine("Opponent side:");
                gameField.show_cards_second_side();
                
                Console.WriteLine("Your scales: " + gameField.get_scales()[0]);
                Console.WriteLine("Opponent scales: " + gameField.get_scales()[1]);
            }
        }

        if (gameField.get_scales()[1] > gameField.get_scales()[0])
        {
            Console.WriteLine("First player win!");
        }
        else
        {
            Console.WriteLine("Second player win!");
        }

        Console.WriteLine("First player: " + gameField.get_scales()[0] + " ||| Second player: " +
                          gameField.get_scales()[1]);
    }
    
    static void AIVsPerson()
    {
        Card_Maker Player1 = new Card_Maker("BOT1", 1);
        Card_Maker Player2 = new Card_Maker("Buba", 2);
        Game_Field gameField = new Game_Field();
        Hand hand1 = new Hand(Player1);
        Hand hand2 = new Hand(Player2);
        Deck deck1 = new Deck(Player1);
        Deck deck2 = new Deck(Player2);
        for (int j = 0; j < 5; j++)
        {
            hand1.take_card(deck1.get_card(true));
            hand2.take_card(deck2.get_card(true));
        }
        
        
        first_AI_turn_strategy(Player1, gameField, hand1, deck1);
        move_diggers(gameField);
        //MAIN PHASE

        while (gameField.check_damage_balance() <= 5)
        {
            if (deck2.cards_counter() == 0)
            {
                deck2 = new Deck(Player2);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(Player2.get_name() + " turn, you can attack this round.");
            
            second_player_turn_strategy(Player2, gameField, hand2, deck2);
            
            move_diggers(gameField);
            
            Console.WriteLine("BATTLE!");
            second_player_atack(gameField, Player1, Player2);
            corpse_cleaning(gameField, Player1, Player2);

            Console.WriteLine("Your side:");
            gameField.show_cards_second_side();
            Console.WriteLine("Opponent side:");
            gameField.show_cards_first_side();
            
            Console.WriteLine("Your scales: " + gameField.get_scales()[1]);
            Console.WriteLine("Opponent scales: " + gameField.get_scales()[0]);
            //---------------------------------------------------
            if (gameField.check_damage_balance() <= 5)
            {
                if (deck1.cards_counter() == 0)
                {
                    deck1 = new Deck(Player1);
                }
                first_AI_turn_strategy(Player1, gameField, hand1, deck1);
                move_diggers(gameField);
                Console.WriteLine("Your side:");
                gameField.show_cards_second_side();
                Console.WriteLine("Opponent side:");
                gameField.show_cards_first_side();
                
                Console.WriteLine("BATTLE!");
                first_player_atack(gameField, Player1, Player2);
                corpse_cleaning(gameField, Player1, Player2);
                
                Console.WriteLine("Your side:");
                gameField.show_cards_second_side();
                Console.WriteLine("Opponent side:");
                gameField.show_cards_first_side();
                
                Console.WriteLine("Your scales: " + gameField.get_scales()[1]);
                Console.WriteLine("Opponent scales: " + gameField.get_scales()[0]);
            }
        }

        if (gameField.get_scales()[1] > gameField.get_scales()[0])
        {
            Console.WriteLine("Bot win!");
        }
        else
        {
            Console.WriteLine("Player win!");
        }

        Console.WriteLine("Bot: " + gameField.get_scales()[0] + " ||| Player: " +
                          gameField.get_scales()[1]);
    }
    
    static void PersonVsAI()
    {
        Card_Maker Player1 = new Card_Maker("Abobus", 1);
        Card_Maker Player2 = new Card_Maker("BOT2", 2);
        Game_Field gameField = new Game_Field();
        Hand hand1 = new Hand(Player1);
        Hand hand2 = new Hand(Player2);
        Deck deck1 = new Deck(Player1);
        Deck deck2 = new Deck(Player2);
        for (int j = 0; j < 5; j++)
        {
            hand1.take_card(deck1.get_card(true));
            hand2.take_card(deck2.get_card(true));
        }

        Console.WriteLine(Player1.get_name() + " turn, you cannot attack this round.");
        first_player_turn_strategy(Player1, gameField, hand1, deck1);
        move_diggers(gameField);

        //MAIN PHASE

        while (gameField.check_damage_balance() <= 5)
        {
            if (deck2.cards_counter() == 0)
            {
                deck2 = new Deck(Player2);
            }
            second_AI_turn_strategy(Player2, gameField, hand2, deck2);
            move_diggers(gameField);
            
            Console.WriteLine("Your side:");
            gameField.show_cards_first_side();
            Console.WriteLine("Opponent side:");
            gameField.show_cards_second_side();
            
            Console.WriteLine("BATTLE!");
            second_player_atack(gameField, Player1, Player2);
            corpse_cleaning(gameField, Player1, Player2);

            Console.WriteLine("Your side:");
            gameField.show_cards_first_side();
            Console.WriteLine("Opponent side:");
            gameField.show_cards_second_side();
            
            Console.WriteLine("Your scales: " + gameField.get_scales()[0]);
            Console.WriteLine("Opponent scales: " + gameField.get_scales()[1]);
            //---------------------------------------------------
            if (gameField.check_damage_balance() <= 5)
            {
                if (deck1.cards_counter() == 0)
                {
                    deck1 = new Deck(Player1);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(Player1.get_name() + " turn, you can attack this round.");
                
                first_player_turn_strategy(Player1, gameField, hand1, deck1);
                
                move_diggers(gameField);
                
                Console.WriteLine("BATTLE!");
                first_player_atack(gameField, Player1, Player2);
                corpse_cleaning(gameField, Player1, Player2);

                Console.WriteLine("Your side:");
                gameField.show_cards_first_side();
                Console.WriteLine("Opponent side:");
                gameField.show_cards_second_side();
                
                Console.WriteLine("Your scales: " + gameField.get_scales()[0]);
                Console.WriteLine("Opponent scales: " + gameField.get_scales()[1]);
            }
        }

        if (gameField.get_scales()[1] > gameField.get_scales()[0])
        {
            Console.WriteLine("Player win!");
        }
        else
        {
            Console.WriteLine("Bot win!");
        }

        Console.WriteLine("Player: " + gameField.get_scales()[0] + " ||| Bot: " +
                          gameField.get_scales()[1]);
    }
    
    static void AIVsAI()
    {
        Card_Maker Player1 = new Card_Maker("BOT1", 1);
        Card_Maker Player2 = new Card_Maker("BOT2", 2);
        Game_Field gameField = new Game_Field();
        Hand hand1 = new Hand(Player1);
        Hand hand2 = new Hand(Player2);
        Deck deck1 = new Deck(Player1);
        Deck deck2 = new Deck(Player2);
        for (int j = 0; j < 5; j++)
        {
            hand1.take_card(deck1.get_card(true));
            hand2.take_card(deck2.get_card(true));
        }
        first_AI_turn_strategy(Player1, gameField, hand1, deck1);
        move_diggers(gameField);
        Console.WriteLine("BOT1 side:");
        gameField.show_cards_first_side();
        Console.WriteLine("BOT2 side:");
        gameField.show_cards_second_side();
        //MAIN PHASE

        while (gameField.check_damage_balance() <= 5)
        {
            if (deck2.cards_counter() == 0)
            {
                deck2 = new Deck(Player2);
            }
            second_AI_turn_strategy(Player2, gameField, hand2, deck2);
            move_diggers(gameField);
            Console.WriteLine("BOT1 side:");
            gameField.show_cards_first_side();
            Console.WriteLine("BOT2 side:");
            gameField.show_cards_second_side();
            Console.WriteLine("BATTLE!");
            second_player_atack(gameField, Player1, Player2);
            corpse_cleaning(gameField, Player1, Player2);
            Console.WriteLine("BOT1 side:");
            gameField.show_cards_first_side();
            Console.WriteLine("BOT2 side:");
            gameField.show_cards_second_side();
            
            Console.WriteLine("BOT1 scales: " + gameField.get_scales()[0]);
            Console.WriteLine("BOT2 scales: " + gameField.get_scales()[1]);
            //---------------------------------------------------
            if (gameField.check_damage_balance() <= 5)
            {
                if (deck1.cards_counter() == 0)
                {
                    deck1 = new Deck(Player1);
                }
                first_AI_turn_strategy(Player1, gameField, hand1, deck1);
                move_diggers(gameField);
                Console.WriteLine("BOT1 side:");
                gameField.show_cards_first_side();
                Console.WriteLine("BOT2 side:");
                gameField.show_cards_second_side();
                
                Console.WriteLine("BATTLE!");
                first_player_atack(gameField, Player1, Player2);
                corpse_cleaning(gameField, Player1, Player2);

                Console.WriteLine("BOT1 side:");
                gameField.show_cards_first_side();
                Console.WriteLine("BOT2 side:");
                gameField.show_cards_second_side();
            
                Console.WriteLine("BOT1 scales: " + gameField.get_scales()[0]);
                Console.WriteLine("BOT2 scales: " + gameField.get_scales()[1]);
            }
        }

        if (gameField.get_scales()[1] > gameField.get_scales()[0])
        {
            Console.WriteLine("First Bot win!");
        }
        else
        {
            Console.WriteLine("Second Bot win!");
        }

        Console.WriteLine("First bot: " + gameField.get_scales()[0] + " ||| Second bot: " +
                          gameField.get_scales()[1]);
    }
}