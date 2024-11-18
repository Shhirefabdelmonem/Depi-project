using System.ComponentModel.DataAnnotations;

namespace LisbrarySystem.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remeber me !!")]
        public bool RememberMe { get; set; }
    }
}
