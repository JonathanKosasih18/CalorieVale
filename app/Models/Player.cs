public class Player : Character
{
    private static readonly Lazy<Player> _instance = new Lazy<Player>(() => new Player());

    public int Experience { get; private set; }
    public int Level { get; private set; }
    private bool isGuarding = false;

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

    public void Guard()
    {
        isGuarding = true;
        Console.WriteLine($"{Name} takes a defensive stance!");
    }

    public bool IsGuarding()
    {
        return isGuarding;
    }

    public int CalculateGuardedDamage(int incomingDamage)
    {
        if (isGuarding)
        {
            Random random = new Random();
            double reduction = random.Next(50, 76) / 100.0; // 50-75% damage reduction
            int reducedDamage = (int)(incomingDamage * (1 - reduction));
            Console.WriteLine($"{Name} blocks {(int)(reduction * 100)}% of the damage!");
            isGuarding = false;
            return reducedDamage;
        }
        return incomingDamage;
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