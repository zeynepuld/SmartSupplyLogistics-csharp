namespace SmartSupplyLogistics.Patterns.Observer;

public class SystemNotifier : IStockObserver
{
    private readonly Queue<string> _notificationQueue = new();
    private readonly string _userId;

    public SystemNotifier(string userId)
    {
        _userId = userId;
    }

    public void Update(string productName, int stock)
    {
        var message = $"[SİSTEM] {_userId}: {productName} stoğu kritik seviyede: {stock}";
        _notificationQueue.Enqueue(message);
        Console.WriteLine(message);
    }

    public string GetObserverName() => "SystemNotifier";
}
