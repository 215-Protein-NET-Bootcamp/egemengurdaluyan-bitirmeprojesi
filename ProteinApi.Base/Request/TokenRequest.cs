using System.ComponentModel.DataAnnotations;

namespace ProteinApi.Base
{
    public class TokenRequest
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }
    }
}
