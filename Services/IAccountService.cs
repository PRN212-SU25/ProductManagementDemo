using BusinessObjects;

namespace Services
{
    public interface IAccountService
    {
        AccountMember Login(string memberId, string password);

    }
}
