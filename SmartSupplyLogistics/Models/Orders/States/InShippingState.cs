namespace SmartSupplyLogistics.Models.Orders.States;

public class InShippingState : IOrderState
{
    public void NextStep(Order order) => order.SetState(new DeliveredState());
    public void Cancel(Order order) => throw new InvalidOperationException("Kargodaki ürün iptal edilemez; sadece iade süreci başlatılabilir.");
    public void Return(Order order) => order.SetState(new ReturnedState("Kargoda iade süreci başlatıldı."));
    public string GetStateName() => "Kargoda";
}
