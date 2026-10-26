namespace SmartSupplyLogistics.Models.Orders.States;

public class ApprovedState : IOrderState
{
    public void NextStep(Order order) => order.SetState(new PreparingState());
    public void Cancel(Order order) => order.SetState(new ReturnedState("Onaylanan sipariş iptal edildi."));
    public void Return(Order order) => throw new InvalidOperationException("Onaylanan ama kargoya çıkmayan sipariş iade edilemez, iptal edilebilir.");
    public string GetStateName() => "Onaylandı";
}
