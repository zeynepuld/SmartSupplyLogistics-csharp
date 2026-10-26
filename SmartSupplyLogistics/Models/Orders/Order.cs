using SmartSupplyLogistics.Models.Orders.States;
using SmartSupplyLogistics.Models.Products;

namespace SmartSupplyLogistics.Models.Orders;

public class Order
{
    public int OrderId { get; }
    public int UserId { get; }
    public List<OrderItem> Items { get; }
    public IOrderState CurrentState { get; private set; }
    public decimal TotalAmount { get; }
    public DateTime CreatedAt { get; }

    public string? TrackingNo { get; private set; }
    public string? CarrierName { get; private set; }
    public decimal? ShippingPrice { get; private set; }
    public string? LastReturnReason { get; private set; }

    public Order(int orderId, int userId, List<OrderItem> items)
    {
        OrderId = orderId;
        UserId = userId;
        Items = items;
        CurrentState = new PendingState();
        TotalAmount = items.Sum(i => i.LineTotal);
        CreatedAt = DateTime.Now;
    }

    public void ProcessOrder() => CurrentState.NextStep(this);
    public void CancelOrder() => CurrentState.Cancel(this);
    public void ReturnOrder(string reason)
    {
        LastReturnReason = reason;
        CurrentState.Return(this);
    }

    public void SetState(IOrderState state) => CurrentState = state;
    public string GetCurrentState() => CurrentState.GetStateName();

    public void SetShipping(string trackingNo, string carrierName, decimal shippingPrice)
    {
        TrackingNo = trackingNo;
        CarrierName = carrierName;
        ShippingPrice = shippingPrice;
    }
}
