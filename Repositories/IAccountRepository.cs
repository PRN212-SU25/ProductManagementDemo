using BusinessObjects;

namespace Repositories
{
    public interface IAccountRepository
    {
        AccountMember Login(string memberId, string password);

    }
}
