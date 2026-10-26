using SmartSupplyLogistics.Models.Orders;

namespace SmartSupplyLogistics.Patterns.Strategy;

public class TransferStrategy : IPaymentStrategy
{
    private readonly string _iban;
    private readonly string _bankName;

    public TransferStrategy(string iban, string bankName)
    {
        _iban = iban;
        _bankName = bankName;
    }

    public bool Pay(Order order, decimal amount)
    {
        if (!Validate()) return false;
        Console.WriteLine($"{_bankName} havalesi ile {amount:C} ödeme bekleniyor. Sipariş No: {order.OrderId}");
        return true;
    }

    public bool Validate() => _iban.Replace(" ", "").Length >= 16;
    public string GetPaymentType() => "Havale";
}
