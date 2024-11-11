class Game
{
    private Player player;

    public void startGame()
    {
        var player = Player.Instance;

        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("Your name is " + player.Name);

        var vegie = new Vegie();

        BattleMenu.StartBattle(player, vegie);
    }
}