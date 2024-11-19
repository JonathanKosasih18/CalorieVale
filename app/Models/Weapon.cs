public class Weapon
{
    public string Name { get; private set; }
    public int AttackLevel { get; private set; }

    public Weapon(string name, int attackLevel)
    {
        Name = name;
        AttackLevel = attackLevel;
    }

    public static Weapon CreateWeapon(string weaponType)
    {
        return weaponType.ToLower() switch
        {
            "FryGun" => new Weapon("FryGun", 10),
            "SodaSprayer" => new Weapon("SodaSprayer", 15),
            "PizzaSlicer" => new Weapon("PizzaSlicer", 20),
            "SugarRushRifle" => new Weapon("SugarRushRifle", 18),
            _ => new Weapon("Fists", 5)  // Default weapon
        };
    }
}