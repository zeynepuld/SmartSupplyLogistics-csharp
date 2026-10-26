namespace SmartSupplyLogistics.Models.Users;

public class CourierRole : IUserRole
{
    private readonly HashSet<string> _permissions = new(StringComparer.OrdinalIgnoreCase)
    {
        "GenerateTracking", "UpdateOrderStatus"
    };

    public string GetRoleName() => "Kurye";
    public bool Can(string permission) => _permissions.Contains(permission);
}
