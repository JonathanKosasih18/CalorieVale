public class MapArea
{
    private static MapArea _instance;

    // Public property to get the current active map
    public static MapArea Instance => _instance;

    public Maps Map { get; set; }
    public List<Vegie> Vegies { get; set; }

    // Protected constructor to restrict instantiation
    protected MapArea(Maps map, List<Vegie> vegies)
    {
        Map = map;
        Vegies = vegies;
    }

    // Method to set the active map dynamically
    public static void SetActiveMap(MapArea map)
    {
        _instance = map;
    }

    // Generate a random Vegie from the map
    public Vegie GenerateVegie()
    {
        int randomIndex = new Random().Next(0, Vegies.Count);
        Vegie prototype = Vegies[randomIndex];
        return new Vegie(prototype.Name, prototype.MaxHealth, prototype.AttackLevel, prototype.Luck);
    }

    // Virtual method for area descriptions
    public virtual void DisplayDescription()
    {
        Console.WriteLine("Gedagedigedagedaoo");
    }
}
