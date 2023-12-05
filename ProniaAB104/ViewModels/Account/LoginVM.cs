using System.ComponentModel.DataAnnotations;

namespace ProniaAB104.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string UserNameorEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsRemembered { get; set; }
    }
}
