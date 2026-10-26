using SmartSupplyLogistics.Models.Users;

namespace SmartSupplyLogistics.Views;

public class UserView
{
    public void ShowLoginForm() => Console.WriteLine("Kullanıcı giriş formu gösterildi.");
    public void ShowDashboard(User user) => Console.WriteLine($"{user.GetRole()} paneli açıldı.");
    public void ShowAccessDenied() => Console.WriteLine("Erişim reddedildi.");
}
