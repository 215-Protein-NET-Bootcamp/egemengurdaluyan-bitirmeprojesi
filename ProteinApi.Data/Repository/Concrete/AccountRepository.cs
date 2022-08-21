using Microsoft.EntityFrameworkCore;
using ProteinApi.Base;

namespace ProteinApi.Data
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Account> GetByIdAsync(int id, bool hasToken)
        {
            var queryable = Context.Account.Where(x => x.Id.Equals(id));
            return await queryable.SingleOrDefaultAsync();
        }

        public async Task<Account> ValidateCredentialsAsync(TokenRequest loginResource)
        {
            var accountStored = await Context.Account
                .Where(x => x.Email == loginResource.Email.ToLower())
                .SingleOrDefaultAsync();

            if (accountStored is null)
                return null;
            else
            {
                // Validate credential
                bool isValid = accountStored.Password.CheckingPassword(loginResource.Password);
                if (isValid)
                    return accountStored;
                else
                    return null;
            }

        }
    }
}
