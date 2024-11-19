public class Player : Character
{
    private static readonly Lazy<Player> _instance = new Lazy<Player>(() => new Player());

    public int Experience { get; private set; }
    public int Level { get; private set; }
    private bool isGuarding = false;
    private int level = 1;
    private int experience = 0;
    private int experienceToNextLevel = 100;

    // Singleton pattern
    public static Player Instance => _instance.Value;

    public Weapon CurrentWeapon { get; private set; }

    private Player()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        Name = "Chubbo";
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        CurrentWeapon = Weapon.CreateWeapon("Fists");
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
            
            GainExperience(reducedDamage);
            return reducedDamage;
        }
        GainExperience(incomingDamage);
        return incomingDamage;
    }

    private void LevelUp()
    {
        level++;
        experience -= experienceToNextLevel;
        experienceToNextLevel = level * 50;
        
        MaxHealth += 20;
        CurrentHealth = MaxHealth;
        
        // Upgrade weapon based on level
        CurrentWeapon = level switch
        {
            1 => Weapon.CreateWeapon("Fists"),
            3 => Weapon.CreateWeapon("FryGun"),
            5 => Weapon.CreateWeapon("SodaSprayer"),
            7 => Weapon.CreateWeapon("PizzaSlicer"),
            10 => Weapon.CreateWeapon("SugarRushRifle"),
            _ => CurrentWeapon
        };

        Console.WriteLine($"\n{Name} reached level {level}!");
        Console.WriteLine($"Max Health increased to {MaxHealth}!");
        if (CurrentWeapon != null)
        {
            Console.WriteLine($"Obtained new weapon: {CurrentWeapon.Name}!");
        }
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine($"{Name} gained {amount} experience!");
        
        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    public int GetExperience()
    {
        return experience;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetExpereinceToNextLevel()
    {
        return experienceToNextLevel;
    }

    void heal()
    {

    }

    void takeDamage()
    {

    }

    public void Attack(Vegie vegie)
    {
        int damage = GetDamage();
        Console.WriteLine(Name + " use attack on " + vegie.Name);
        vegie.CurrentHealth -= damage;

        // sleep for 1 second
        Thread.Sleep(1000);

        Console.WriteLine("It dealts " + damage + " damage!");
        Console.WriteLine(Name + " gained " + 5 + " experience!");

        Console.WriteLine("Press any key to continue...");

        Console.ReadKey();
    }

    public int GetDamage() {
        if (CurrentWeapon == null) {
            return 5;
        }

        return CurrentWeapon.AttackLevel;
    }

    void useItem(Item item)
    {

    }

}