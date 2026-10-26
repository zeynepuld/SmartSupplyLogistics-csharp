namespace SmartSupplyLogistics.Models.Orders.States;

public class ReturnedState : IOrderState
{
    public string Reason { get; }

    public ReturnedState(string reason = "İade/iptal süreci tamamlandı.")
    {
        Reason = reason;
    }

    public void NextStep(Order order) => throw new InvalidOperationException("İade/iptal edilen siparişte sonraki adım yoktur.");
    public void Cancel(Order order) => throw new InvalidOperationException("Sipariş zaten kapalı durumdadır.");
    public void Return(Order order) => throw new InvalidOperationException("Sipariş zaten iade/iptal sürecindedir.");
    public string GetStateName() => "İade/İptal";
}
