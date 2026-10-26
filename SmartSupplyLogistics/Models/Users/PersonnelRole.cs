namespace SmartSupplyLogistics.Models.Users;

public class PersonnelRole : IUserRole
{
    private readonly HashSet<string> _permissions = new(StringComparer.OrdinalIgnoreCase)
    {
        "ListProducts", "UpdateStock", "AssembleProduct", "ReceiveStockAlert", "UpdateOrderStatus"
    };

    public string GetRoleName() => "Personel";
    public bool Can(string permission) => _permissions.Contains(permission);
}
