using CarRental.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public ProfileEnum Profile { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Date Register")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataRegister { get; set; }
        public DateTime? DataUpdate { get; set; }

        public bool ValidPassword(string password)
        {
            return Password == password;
        }
    }
}
