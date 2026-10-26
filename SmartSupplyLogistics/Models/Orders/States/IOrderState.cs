namespace SmartSupplyLogistics.Models.Orders.States;

public interface IOrderState
{
    void NextStep(Order order);
    void Cancel(Order order);
    void Return(Order order);
    string GetStateName();
}
