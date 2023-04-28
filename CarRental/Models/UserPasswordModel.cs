using CarRental.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class UserPasswordModel
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
        public ProfileEnum? Profile { get; set; }
    }
}
