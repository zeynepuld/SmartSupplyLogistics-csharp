namespace SmartSupplyLogistics.Models.Orders.States;

public class PreparingState : IOrderState
{
    public void NextStep(Order order) => order.SetState(new InShippingState());
    public void Cancel(Order order) => order.SetState(new ReturnedState("Hazırlanan sipariş iptal edildi."));
    public void Return(Order order) => throw new InvalidOperationException("Hazırlanan sipariş iade edilemez, iptal edilebilir.");
    public string GetStateName() => "Hazırlanıyor";
}
