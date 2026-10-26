namespace SmartSupplyLogistics.Models.Users;

public class CustomerRole : IUserRole
{
    private readonly HashSet<string> _permissions = new(StringComparer.OrdinalIgnoreCase)
    {
        "ListProducts", "PlaceOrder", "MakePayment", "ViewOrderHistory"
    };

    public string GetRoleName() => "Müşteri";
    public bool Can(string permission) => _permissions.Contains(permission);
}
