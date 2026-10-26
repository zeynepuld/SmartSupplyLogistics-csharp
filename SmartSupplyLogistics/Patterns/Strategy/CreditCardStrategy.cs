using SmartSupplyLogistics.Models.Orders;

namespace SmartSupplyLogistics.Patterns.Strategy;

public class CreditCardStrategy : IPaymentStrategy
{
    private readonly string _cardNumber;
    private readonly string _cvv;

    public CreditCardStrategy(string cardNumber, string cvv)
    {
        _cardNumber = cardNumber;
        _cvv = cvv;
    }

    public bool Pay(Order order, decimal amount)
    {
        if (!Validate()) return false;
        Console.WriteLine($"Kredi kartı ile {amount:C} ödeme alındı. Sipariş No: {order.OrderId}");
        return true;
    }

    public bool Validate() => _cardNumber.Length >= 12 && _cvv.Length == 3;
    public string GetPaymentType() => "Kredi Kartı";
}
