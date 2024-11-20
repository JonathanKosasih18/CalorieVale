public class LeafyLagoon : MapArea
{
    public LeafyLagoon() : base(Maps.Leafy_Lagoon, new List<Vegie>
    {
        new VegieBuilder()
        .SetName("Letty the Lettuce")
        .SetMaxHealth(75)
        .SetAttackLevel(10)
        .SetLuck(5)
        .Build(),
        new VegieBuilder()
        .SetName("Broco Lee")
        .SetMaxHealth(100)
        .SetAttackLevel(15)
        .SetLuck(5)
        .Build(),
    })
    {
        // Constructor Masih Empty, Bisa ditambah suatu saat
    }

    public override void DisplayDescription()
    {
        Console.WriteLine("You are in the Leafy Lagoon... Don't let the still waters fool you!");
    }

    // Bisa tambahkan method unik untuk LeafyLagoon
}
