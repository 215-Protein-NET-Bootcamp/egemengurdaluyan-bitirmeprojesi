using AutoMapper;
using ProteinApi.Base;
using ProteinApi.Data;
using ProteinApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Service
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(accountRepository, mapper, unitOfWork)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<BaseResponse<AccountDto>> SelfUpdateAsync(int id, AccountDto resource)
        {
            try
            {
                var tempAccount = await accountRepository.GetByIdAsync(id);

                // Update infomation
                Mapper.Map(resource, tempAccount);
                accountRepository.Update(tempAccount);

                await UnitOfWork.CompleteAsync();

                return new BaseResponse<AccountDto>(Mapper.Map<AccountDto>(tempAccount));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Account_Updating_Error", ex);
            }
        }

        public async Task<BaseResponse<AccountDto>> UpdatePasswordAsync(int id, UpdatePasswordRequest resource)
        {
            try
            {
                // Validate Id is existent?
                var tempAccount = await accountRepository.GetByIdAsync(id, hasToken: true);
                if (tempAccount is null)
                    return new BaseResponse<AccountDto>("Account_NoData");
                if (!tempAccount.Password.CheckingPassword(resource.OldPassword))
                    return new BaseResponse<AccountDto>("Account_Password_Error");

                // Update infomation
                tempAccount.Password = HashExtension.HashPassword(resource.NewPassword);
                tempAccount.LastActivity = DateTime.UtcNow;

                await UnitOfWork.CompleteAsync();

                return new BaseResponse<AccountDto>(Mapper.Map<AccountDto>(tempAccount));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Account_Updating_Error", ex);
            }
        }


    }
}
