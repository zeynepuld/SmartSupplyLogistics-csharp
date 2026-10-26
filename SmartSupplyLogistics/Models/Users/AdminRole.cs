namespace SmartSupplyLogistics.Models.Users;

public class AdminRole : IUserRole
{
    public string GetRoleName() => "Admin";
    public bool Can(string permission) => true;
}
