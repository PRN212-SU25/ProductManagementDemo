using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountMember Login(string memberId, string password)
        {
            return AccountDAO.Login(memberId, password);
        }
    }
}
