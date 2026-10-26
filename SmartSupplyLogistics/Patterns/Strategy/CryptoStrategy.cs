using SmartSupplyLogistics.Models.Orders;

namespace SmartSupplyLogistics.Patterns.Strategy;

public class CryptoStrategy : IPaymentStrategy
{
    private readonly string _walletAddress;
    private readonly string _cryptoType;

    public CryptoStrategy(string walletAddress, string cryptoType)
    {
        _walletAddress = walletAddress;
        _cryptoType = cryptoType;
    }

    public bool Pay(Order order, decimal amount)
    {
        if (!Validate()) return false;
        Console.WriteLine($"{_cryptoType} ile {amount:C} karşılığı kripto ödeme alındı. Sipariş No: {order.OrderId}");
        return true;
    }

    public bool Validate() => _walletAddress.Length >= 8 && !string.IsNullOrWhiteSpace(_cryptoType);
    public string GetPaymentType() => "Kripto Ödeme";
}
