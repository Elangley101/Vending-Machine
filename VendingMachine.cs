using System;

class Item
{
    private string name;
    private double price;
    private int quantity;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public double Price
    {
        get => price;
        set => price = value;
    }

    public int Quantity
    {
        get => quantity;
        set => quantity = value;
    }

    public Item(string name, double price, int quantity)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }
}

class Vendor
{
    private Item[] items;

    public void Populate(Item[] items)
    {
        this.items = items;
    }

    public bool ProcessPurchase()
    {
        System.Console.WriteLine("Menu:");
        for (int i = 0; i < items.Length; i++)
            System.Console.WriteLine("[{0}] {1}, ${2}, {3} items available", i + 1, items[i].Name, items[i].Price, items[i].Quantity);
        System.Console.Write("Enter item's index: ");
        int index = Int32.Parse(System.Console.ReadLine()) - 1;
        if (index >= 0 && index < items.Length)
        {
            System.Console.Write("Enter quantity: ");
            int quantity = Int32.Parse(System.Console.ReadLine());
            if (quantity > items[index].Quantity)
                System.Console.WriteLine("There are only {0} items available", items[index].Quantity);
            else if (quantity > 0)
            {
                double cost = quantity * items[index].Price;
                items[index].Quantity -= quantity;
                System.Console.WriteLine("You've purchased {0} items of {1} for ${2}", quantity, items[index].Name, cost);
            }
            else
                System.Console.WriteLine("Quantity must be positive");
        }
        else
            System.Console.WriteLine("Bad index");
        System.Console.Write("Do you want to purchase more items (Y/N)? ");
        return System.Console.ReadLine().ToUpper() == "Y";
    }
}

class VendingMachine
{
    static void Main(string[] args)
    {
        Item[] items =
        {
            new Item("Coca-Cola", 0.99, 10),
            new Item("Bonaqua", 0.89, 8),
            new Item("Sprite", 1.29, 5),
            new Item("Fanta", 1.19, 5),
            new Item("Pepsi", 0.99, 3)
        };
        Vendor vendor = new Vendor();
        vendor.Populate(items);
        bool proceed;
        do
        {
            proceed = vendor.ProcessPurchase();
        } while (proceed);
    }
}
