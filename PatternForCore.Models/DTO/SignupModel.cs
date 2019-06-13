using System.ComponentModel.DataAnnotations;

namespace PatternForCore.Models.DTO
{
    public class SignupModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your password should be at least six characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
