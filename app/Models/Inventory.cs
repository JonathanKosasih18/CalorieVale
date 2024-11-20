using System.Text;

public class Inventory
{
    public List<Item> items = new List<Item>();

    public Inventory()
    {
        AddItem(new Potion("Health Potion", 50));
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    // Change ToString to a method that returns a string or just display inventory.
    public void DisplayInventory()
    {
        Console.Clear();
        if (items.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        foreach (Item item in items)
        {
            Console.WriteLine(item.ToString());  // Calls the ToString method of Item
        }
    }
}
