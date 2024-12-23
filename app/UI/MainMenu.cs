public static class MainMenu
{
    private static Game game = Game.Instance;
    private static Player player = Player.Instance;

    public static void StartMenu()
    {
        Console.Clear();
        Console.WriteLine("[CAMP]" + " Day " + game.GetCurrentDay());

        Console.WriteLine("Hello Chubbo!, What would you like to do now?");
        Console.WriteLine("1. Start Game");
        Console.WriteLine("2. Show Stats");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                game.StartDay();
                break;
            case "2":
                ShowStats();
                break;
            case "3":
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }

    public static void ShowStats()
    {
        Console.Clear();

        Console.WriteLine("Your Current Stats: \n");
        Console.WriteLine("Name: " + player.Name);
        Console.WriteLine("Weapon: " + player.CurrentWeapon.Name + " (Attack: " + player.CurrentWeapon.AttackLevel + ")");

        Console.WriteLine("Level: " + player.Level);
        Console.WriteLine("Health: " + player.CurrentHealth);
        Console.WriteLine("Attack Level: " + player.AttackLevel);
        Console.WriteLine("Luck: " + player.Luck);
        Console.WriteLine("Experience: " + player.GetExperience() + "/" + player.GetExpereinceToNextLevel());

        Console.WriteLine("Press any key to continue...");

        Console.ReadKey();

        StartMenu();
    }
}