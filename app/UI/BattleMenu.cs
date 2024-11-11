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
            Console.WriteLine("\n");

            Console.WriteLine("Player turn");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Item");
            Console.WriteLine("3. Run");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    player.Attack(vegie);
                    break;
                case "2":
                    // player.UseItem();
                    break;
                case "3":
                    Console.WriteLine("You can't run from this battle!");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            if (vegie.IsDead())
            {
                Console.WriteLine("You won!");
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