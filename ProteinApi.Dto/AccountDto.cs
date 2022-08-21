using ProteinApi.Base;
using ProteinApi.Data;
using System.ComponentModel.DataAnnotations;

namespace ProteinApi.Dto
{
    public class AccountDto : BaseDto
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [PasswordAttribute]
        public string Password { get; set; }


        [Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }
        public bool IsActive { get; set; }

    }
}