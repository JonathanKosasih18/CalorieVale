public class Player : Character
{
    private static readonly Lazy<Player> _instance = new Lazy<Player>(() => new Player());

    public int Experience { get; private set; }
    public int Level { get; private set; }

    // Singleton pattern
    public static Player Instance => _instance.Value;

    private Weapon weapon;

    private Player()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        Name = "Chubbo";
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        AttackLevel = 10;
        Luck = 5;
        Experience = 0;
        Level = 1;
    }

    void levelUp()
    {

    }

    void gainExperience()
    {

    }

    void heal()
    {

    }

    void takeDamage()
    {

    }

    public void Attack(Vegie vegie)
    {
        Console.WriteLine(Name + " use attack on " + vegie.Name);
        vegie.CurrentHealth -= AttackLevel;

        // sleep for 1 second
        Thread.Sleep(1000);

        Console.WriteLine("It dealts " + AttackLevel + " damage!");

        Console.WriteLine("Press any key to continue...");

        Console.ReadKey();
    }

    void useItem(Item item)
    {

    }

}