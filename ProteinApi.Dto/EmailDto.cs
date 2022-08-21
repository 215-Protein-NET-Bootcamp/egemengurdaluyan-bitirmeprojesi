using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Dto
{
    public class EmailDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailDto(AccountDto dto)
        {
            this.To = dto.Email;
            this.Subject = "About the registration process";
            this.Body = "Successfully registered.";
        }
    }
}
