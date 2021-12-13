using System.ComponentModel.DataAnnotations;

namespace SportWebSite.Domain.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please fill email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please fill password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
