namespace SmartSupplyLogistics.Patterns.Observer;

public class EmailNotifier : IStockObserver
{
    private readonly string _smtpServer;

    public EmailNotifier(string smtpServer)
    {
        _smtpServer = smtpServer;
    }

    public void Update(string productName, int stock)
    {
        Console.WriteLine($"[E-POSTA] Satın alma birimine gönderildi ({_smtpServer}): {productName} stoğu kritik: {stock}");
    }

    public string GetObserverName() => "EmailNotifier";
}
