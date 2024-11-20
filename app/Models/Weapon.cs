public class Weapon
{
    public string Name { get; private set; }
    public int AttackLevel { get; private set; }
    public WeaponType Type { get; private set; }

    private Weapon(string name, int attackLevel, WeaponType type)
    {
        Name = name;
        AttackLevel = attackLevel;
        Type = type;
    }

    public static Weapon CreateWeapon(WeaponType weaponType)
    {
        return weaponType switch
        {
            WeaponType.FryGun => new Weapon("FryGun", 10, WeaponType.FryGun),
            WeaponType.SodaSprayer => new Weapon("SodaSprayer", 15, WeaponType.SodaSprayer),
            WeaponType.PizzaSlicer => new Weapon("PizzaSlicer", 20, WeaponType.PizzaSlicer),
            WeaponType.SugarRushRifle => new Weapon("SugarRushRifle", 18, WeaponType.SugarRushRifle),
            _ => new Weapon("Fists", 5, WeaponType.Fists)  // Default weapon
        };
    }
}
