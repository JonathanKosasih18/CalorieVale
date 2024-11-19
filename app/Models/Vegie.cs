public enum Difficulty
{
    Easy,
    Normal, 
    Hard
}

public class Vegie : Character
{
    private Random random = new Random();
    public Vegie(Difficulty difficulty = Difficulty.Normal)
    {
        this.Name = "Vegie";
        
        switch (difficulty)
        {
            case Difficulty.Easy:
                this.MaxHealth = 75;
                this.AttackLevel = 5;
                break;
            case Difficulty.Normal:
                this.MaxHealth = 100;
                this.AttackLevel = 10;
                break;
            case Difficulty.Hard:
                this.MaxHealth = 150;
                this.AttackLevel = 15;
                break;
        }
        
        this.CurrentHealth = this.MaxHealth;
    }

    public void Attack(Player player)
    {
        int damage = AttackLevel;
        string attackType = "";

        // 50% chance to hit or miss
        if (random.Next(2) == 0)
        {
            attackType = "swings at";
        }
        else
        {
            damage = 0;
            attackType = "misses";
        }

        Console.WriteLine($"{Name} {attackType} {player.Name}!");

        if (damage > 0)
        {
            if (player.IsGuarding())
            {
                damage = player.CalculateGuardedDamage(damage);
            }
            player.TakeDamage(damage);
        }

        Thread.Sleep(1000);
        Console.WriteLine($"{player.Name} takes {damage} damage!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}