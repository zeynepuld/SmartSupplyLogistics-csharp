// Sistemdeki kritik işlemleri tek bir Logger nesnesi üzerinden dosyaya ve konsola kaydeder.

namespace SmartSupplyLogistics.Patterns.Singleton;

public sealed class Logger
{
    private static Logger? _instance;
    private static readonly object LockObject = new();
    private readonly string _logFilePath;

    private Logger(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public static Logger GetInstance(string logFilePath = "system-log.txt")
    {
        lock (LockObject)
        {
            _instance ??= new Logger(logFilePath);
            return _instance;
        }
    }

    public void Log(string message, string level = "INFO")
    {
        var logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
        File.AppendAllText(_logFilePath, logLine + Environment.NewLine);
        Console.WriteLine($"[LOG] {logLine}");
    }

    public List<string> LogSearch(string keyword)
    {
        if (!File.Exists(_logFilePath)) return new List<string>();
        return File.ReadAllLines(_logFilePath)
            .Where(line => line.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public void LogPayment(OrderLikePayment payment)
    {
        Log($"Ödeme loglandı: {payment.PaymentType}, Tutar: {payment.Amount:C}");
    }

    public void LogError(Exception ex) => Log(ex.Message, "ERROR");
}

public record OrderLikePayment(string PaymentType, decimal Amount);
