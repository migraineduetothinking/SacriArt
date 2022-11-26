using System.ComponentModel.DataAnnotations;

namespace SacriArt.Models.ViewModels
{
    public record class Admin(string Name, string Password);

    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        // [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }
}
