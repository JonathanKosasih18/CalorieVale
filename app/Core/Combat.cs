// This handle a single wave of combat between the play and a vegie

public static class Combat
{
    public static int TurnNumber { get; private set; } = 1;

    public static void ResetTurn()
    {
        TurnNumber = 1;
    }

    public static void AddTurn()
    {
        TurnNumber++;
    }

    public static void EndDay()
    {
        Console.Clear();
        Console.WriteLine("You were defeated by the Vegie...");
        Console.WriteLine("You Got a Potion!");

        Console.WriteLine("Press any key to continue...");

        Console.ReadKey();


        Player.Instance.Inventory.AddItem(new Potion("Health Potion", 50));

        Player.Instance.ResetHealth();
        Game.Instance.AddDay();
        MainMenu.StartMenu();
    }
}
