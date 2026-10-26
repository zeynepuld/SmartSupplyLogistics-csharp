using SmartSupplyLogistics.Models.Orders;

namespace SmartSupplyLogistics.Patterns.Strategy;

public interface IPaymentStrategy
{
    bool Pay(Order order, decimal amount);
    bool Validate();
    string GetPaymentType();
}
