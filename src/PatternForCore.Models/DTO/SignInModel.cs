using System.ComponentModel.DataAnnotations;

namespace PatternForCore.Models.DTO
{
    public class SignInModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
