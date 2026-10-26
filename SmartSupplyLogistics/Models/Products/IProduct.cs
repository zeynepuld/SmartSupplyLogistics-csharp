namespace SmartSupplyLogistics.Models.Products;

public interface IProduct
{
    string GetName();
    decimal GetPrice();
    int GetStock();
    string GetDescription();
}
