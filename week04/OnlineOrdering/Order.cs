using System.Collections.Generic;

public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double productTotal = 0;
        foreach (var product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        // $5 shipping if in USA, $35 if international
        double shippingCost = _customer.IsInUsa() ? 5.0 : 35.0;
        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";
        foreach (var product in _products)
        {
            label += $"Product: {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "--- Shipping Label ---\n";
        label += $"{_customer.GetName()}\n";
        label += $"{_customer.GetShippingAddress()}\n";
        return label;
    }
}