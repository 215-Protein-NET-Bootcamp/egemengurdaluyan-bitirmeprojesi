using ProteinApi.Dto;

namespace ProteinApi.Service
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
