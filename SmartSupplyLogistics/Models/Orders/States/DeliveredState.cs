namespace SmartSupplyLogistics.Models.Orders.States;

public class DeliveredState : IOrderState
{
    public void NextStep(Order order) => throw new InvalidOperationException("Teslim edilen siparişte sonraki normal adım yoktur.");
    public void Cancel(Order order) => throw new InvalidOperationException("Teslim edilen sipariş iptal edilemez.");
    public void Return(Order order) => order.SetState(new ReturnedState("Teslim sonrası iade talebi oluşturuldu."));
    public string GetStateName() => "Teslim Edildi";
}
