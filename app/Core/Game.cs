public class Game
{
    private Player player;
    private int currentDay = 0;
    public int currentWave = 0;

    private static readonly Lazy<Game> _instance = new Lazy<Game>(() => new Game());
    public static Game Instance => _instance.Value;

    public Game()
    {
        // Implement different Maps here
        MapArea.SetActiveMap(new LeafyLagoon());
        MapArea.Instance.DisplayDescription();
        player = Player.Instance;
    }

    public void StartDay()
    {
        if (currentWave == 0)
        {
            // Reset wave only at the beginning of a new day
            resetWave();
        }
        AddWave();
        BattleMenu.StartBattle(player, MapArea.Instance.GenerateVegie());
    }


    private void resetWave()
    {
        currentWave = 0;
    }

    public void AddWave()
    {
        currentWave++;
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