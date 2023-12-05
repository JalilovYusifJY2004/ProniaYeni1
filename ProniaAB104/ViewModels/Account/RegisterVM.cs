using System.ComponentModel.DataAnnotations;

namespace ProniaAB104.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [MinLength(6)]
        [MaxLength(25)]
        public string UserName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string SurName { get; set; }
        [Required]
        [MinLength(11)]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Emailin formaati sevdir")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public GenderType Gender { get; set; }

    }

    public enum GenderType
    {
        Male,
        Female
    }
}
