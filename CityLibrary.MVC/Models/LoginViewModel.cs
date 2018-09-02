using System.ComponentModel.DataAnnotations;

namespace CityLibrary.MVC.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}