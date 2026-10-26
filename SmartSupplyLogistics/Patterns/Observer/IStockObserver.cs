namespace SmartSupplyLogistics.Patterns.Observer;

public interface IStockObserver
{
    void Update(string productName, int stock);
    string GetObserverName();
}
