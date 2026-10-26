using SmartSupplyLogistics.Models.Orders;

namespace SmartSupplyLogistics.Patterns.Strategy;

public class PaymentManager
{
    public IPaymentStrategy? Strategy { get; private set; }
    private readonly List<IPaymentStrategy> _paymentHistory = new();

    public void SetStrategy(IPaymentStrategy strategy) => Strategy = strategy;

    public bool ExecutePayment(Order order)
    {
        if (Strategy is null) throw new InvalidOperationException("Ödeme stratejisi seçilmedi.");
        var result = Strategy.Pay(order, order.TotalAmount);
        if (result) _paymentHistory.Add(Strategy);
        return result;
    }

    public List<string> GetPaymentHistory() => _paymentHistory.Select(p => p.GetPaymentType()).ToList();
}
