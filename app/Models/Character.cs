public abstract class Character
{
    public string Name { get; protected set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int AttackLevel { get; set; }
    public int Luck { get; set; }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth < 0) CurrentHealth = 0;
    }

    public virtual bool IsDead() => CurrentHealth <= 0;
}