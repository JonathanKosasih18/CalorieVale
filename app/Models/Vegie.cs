public class Vegie : Character
{
    public Vegie()
    {
        this.Name = "Vegie";
        this.MaxHealth = 100;
        this.AttackLevel = 10;
        this.CurrentHealth = this.MaxHealth;
    }

    public void DoTurn()
    {

    }

    public void Attack(Player player)
    {
        Console.WriteLine(Name + " use attack on " + player.Name);

        player.TakeDamage(AttackLevel);

        Thread.Sleep(1000);

        Console.WriteLine("It dealts " + AttackLevel + " damage!");

        Console.WriteLine("Press any key to continue...");

        Console.ReadKey();
    }
}