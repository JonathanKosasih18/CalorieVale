public class Player : Character
{
    private static readonly Lazy<Player> _instance = new Lazy<Player>(() => new Player());

    public int Experience { get; private set; }
    public int Level { get; private set; }
    private bool isGuarding = false;
    private int level = 1;
    private int experience = 0;
    private int experienceToNextLevel = 100;

    private static int defaultHealth = 50;
    private static int defaultAttackLevel = 25;
    private static int defaultLuck = 5;

    // Singleton pattern
    public static Player Instance => _instance.Value;

    public Weapon CurrentWeapon { get; private set; }

    public Inventory Inventory { get; private set; } = new Inventory();

    private Player() : base("Chubbo", defaultHealth, defaultAttackLevel, defaultLuck)
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        CurrentWeapon = Weapon.CreateWeapon(WeaponType.Fists);
    }

    public void Guard()
    {
        isGuarding = true;
        Console.WriteLine($"{Name} takes a defensive stance!");
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
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
            1 => Weapon.CreateWeapon(WeaponType.Fists),
            3 => Weapon.CreateWeapon(WeaponType.FryGun),
            5 => Weapon.CreateWeapon(WeaponType.SodaSprayer),
            7 => Weapon.CreateWeapon(WeaponType.PizzaSlicer),
            10 => Weapon.CreateWeapon(WeaponType.SugarRushRifle),
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

    public void Heal(int amount)
    {
        if (CurrentHealth + amount > MaxHealth)
        {
            CurrentHealth = MaxHealth;
            return;
        }
        CurrentHealth += amount;
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

    public int GetDamage()
    {
        if (CurrentWeapon == null)
        {
            return AttackLevel;
        }

        return CurrentWeapon.AttackLevel + AttackLevel;
    }
}