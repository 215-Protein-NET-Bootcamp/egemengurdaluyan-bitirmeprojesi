using ProteinApi.Base;

namespace ProteinApi.Data
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> ValidateCredentialsAsync(TokenRequest loginResource);
        Task<Account> GetByIdAsync(int id, bool hasToken);
    }
}
