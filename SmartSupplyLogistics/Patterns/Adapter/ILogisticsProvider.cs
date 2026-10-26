namespace SmartSupplyLogistics.Patterns.Adapter;

public interface ILogisticsProvider
{
    decimal CalculatePrice(decimal weight, decimal distance);
    string GenerateTrackingNo(int orderId);
    string GetCarrierName();
}
