using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "{0} required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Password { get; set; }
    }
}
