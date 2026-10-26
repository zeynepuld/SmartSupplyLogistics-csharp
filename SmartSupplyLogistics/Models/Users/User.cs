namespace SmartSupplyLogistics.Models.Users;

public class User
{
    public int UserId { get; }
    public string Name { get; }
    public string Email { get; }
    private readonly IUserRole _role;

    public User(int userId, string name, string email, IUserRole role)
    {
        UserId = userId;
        Name = name;
        Email = email;
        _role = role;
    }

    public bool Login()
    {
        Console.WriteLine($"{Name} sisteme giriş yaptı. Rol: {GetRole()}");
        return true;
    }

    public void Logout() => Console.WriteLine($"{Name} sistemden çıktı.");
    public string GetRole() => _role.GetRoleName();
    public bool Can(string permission) => _role.Can(permission);
}
