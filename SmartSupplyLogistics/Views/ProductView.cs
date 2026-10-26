using SmartSupplyLogistics.Models.Products;

namespace SmartSupplyLogistics.Views;

public class ProductView
{
    public void ShowProductList(IEnumerable<IProduct> products)
    {
        Console.WriteLine("\n=== Ürünler ===");
        foreach (var product in products)
            ShowProductDetail(product);
    }

    public void ShowProductDetail(IProduct product) => Console.WriteLine(product.GetDescription());
    public void RenderProductCard(IProduct product) => ShowProductDetail(product);
}
