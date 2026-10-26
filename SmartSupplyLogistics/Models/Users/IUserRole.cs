namespace SmartSupplyLogistics.Models.Users;

public interface IUserRole
{
    string GetRoleName();
    bool Can(string permission);
}
