using BusinessObjects;
using Repositories;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository iAccountRepository;

        public AccountService()
        {
            iAccountRepository = new AccountRepository();
        }
        public AccountMember Login(string memberId, string password)
        {
            return iAccountRepository.Login(memberId, password);
        }

    }
}
