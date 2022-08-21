using ProteinApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Service
{
    public interface ITokenManagementService
    {
        Task<BaseResponse<TokenResponse>> GenerateTokensAsync(TokenRequest loginResource, DateTime now, string userAgent);
    }

}
