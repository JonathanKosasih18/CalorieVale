using System.Reflection.PortableExecutable;

public static class BattleMenu
{
    public static void StartBattle(Player player, Vegie vegie)
    {
        Console.WriteLine("A Wild " + vegie.Name + " appears!\n");

        Console.WriteLine("Press any key to start the battle...");
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("A wild " + vegie.Name + " appears!");


        while (!player.IsDead() && !vegie.IsDead())
        {
            // Print player and vegie stats
            Console.Clear();
            Console.WriteLine("Wave: " + Game.Instance.currentWave + "\tTurn " + Combat.TurnNumber);
            Console.WriteLine(" Level: " + player.GetLevel() + "\t\t" + "Experience: " + player.GetExperience() + "/" + player.GetExpereinceToNextLevel());
            Console.WriteLine(player.Name + " HP: " + player.CurrentHealth + "\t\t" + vegie.Name + " HP: " + vegie.CurrentHealth);
            Console.WriteLine("\n");

            Console.WriteLine("Player turn");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Item");
            Console.WriteLine("3. Guard");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    player.Attack(vegie);
                    player.GainExperience(10);
                    break;
                case "2":
                    // player.UseItem();
                    ItemMenu(player);
                    break;
                case "3":
                    int previousHealth = player.CurrentHealth;
                    player.Guard();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            if (vegie.IsDead())
            {
                Console.WriteLine("You won!");
                player.GainExperience(50);

                Console.WriteLine("Press any key to continue...");

                Console.ReadKey();

                Game.Instance.StartDay();
            }

            Console.WriteLine("\nVegie's turn");
            vegie.Attack(player);
            if (player.IsDead())
            {
                Combat.EndDay();
                break;
            }

            Combat.AddTurn();
        }
    }

    public static void ItemMenu(Player player)
    {
        Console.Clear();
        Console.WriteLine("Inventory");
        player.Inventory.DisplayInventory();
        Console.WriteLine("Choose an item to use (enter the number):");

        if (int.TryParse(Console.ReadLine(), out int option) && option > 0 && option <= player.Inventory.items.Count)
        {
            Item selectedItem = player.Inventory.items[option - 1];

            // Here you can add logic to use the selected item
            Console.WriteLine($"You chose to use {selectedItem.Name}.");
            selectedItem.Use();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a valid number.");
        }

        Console.ReadKey();
    }
}