namespace SmartSupplyLogistics.Models.Orders.States;

public class PendingState : IOrderState
{
    public void NextStep(Order order) => order.SetState(new ApprovedState());
    public void Cancel(Order order) => order.SetState(new ReturnedState("Sipariş beklemedeyken iptal edildi."));
    public void Return(Order order) => throw new InvalidOperationException("Beklemedeki sipariş iade edilemez, iptal edilebilir.");
    public string GetStateName() => "Beklemede";
}
