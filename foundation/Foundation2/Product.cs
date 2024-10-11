// Product class to hold product details like name, product ID, price, and quantity.
public class Product
{
    private string _name;
    private string _id;
    private double _price;
    private int _quantity;

    public Product(string name, string id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    // Method to calculate the total cost for this product.
    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    // Method to return the name and product ID for the packing label.
    public string GetPackingLabel()
    {
        return $"{_name} (Product ID: {_id})";
    }
}