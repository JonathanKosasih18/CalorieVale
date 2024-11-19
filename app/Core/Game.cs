public static class Game
{
    private Player player;
    private int currentDay = 0;

    public void startGame()
    {
        player = Player.Instance;

        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("Your name is " + player.Name);

        var vegie = new Vegie();

        BattleMenu.StartBattle(player, vegie);
    }

    public void AddDay()
    {
        currentDay++;
    }

    public int GetCurrentDay()
    {
        return currentDay;
    }
}