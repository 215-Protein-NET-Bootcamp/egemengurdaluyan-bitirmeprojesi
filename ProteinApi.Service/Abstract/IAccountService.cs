using ProteinApi.Base;
using ProteinApi.Data;
using ProteinApi.Dto;

namespace ProteinApi.Service
{
    public interface IAccountService : IBaseService<AccountDto, Account>
    {
        Task<BaseResponse<AccountDto>> SelfUpdateAsync(int id, AccountDto resource);
        Task<BaseResponse<AccountDto>> UpdatePasswordAsync(int id, UpdatePasswordRequest resource);
    }
}
