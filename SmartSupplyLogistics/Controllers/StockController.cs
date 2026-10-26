using SmartSupplyLogistics.Models.Users;
using SmartSupplyLogistics.Patterns.Observer;
using SmartSupplyLogistics.Patterns.Singleton;

namespace SmartSupplyLogistics.Controllers;

public class StockController
{
    private readonly StockManager _stockManager;
    private readonly Logger _logger;

    public StockController(StockManager stockManager, Logger logger)
    {
        _stockManager = stockManager;
        _logger = logger;
    }

    public void UpdateStock(User user, string productName, int stock)
    {
        if (!user.Can("UpdateStock"))
            throw new UnauthorizedAccessException($"{user.GetRole()} rolü stok güncelleyemez.");

        _stockManager.UpdateStock(productName, stock);
        _logger.Log($"Stok değişimi: {productName} -> {stock}. İşlemi yapan: {user.Name}");
    }
}
