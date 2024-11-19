using System.Reflection.PortableExecutable;

public static class BattleMenu
{
    public static void StartBattle(Player player, Vegie vegie)
    {

        Console.Clear();
        Console.WriteLine("A wild " + vegie.Name + " appears!");


        while (!player.IsDead() && !vegie.IsDead())
        {
            // Print player and vegie stats
            Console.Clear();
            Console.WriteLine(player.Name + " HP: " + player.CurrentHealth + "\t\t" + vegie.Name + " HP: " + vegie.CurrentHealth);
            Console.WriteLine(" Level: " + player.GetLevel() + "\t\t" + "Experience: " + player.GetExperience() + "/" + player.GetExpereinceToNextLevel());
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
                    player.GainExperience(5);
                    break;
                case "2":
                    // player.UseItem();

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
                break;
            }

            Console.WriteLine("\nVegie's turn");
            vegie.Attack(player);
            if (player.IsDead())
            {
                Console.WriteLine("You lost!");
                break;
            }
        }
    }
}