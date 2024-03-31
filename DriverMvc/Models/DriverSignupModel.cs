using System.ComponentModel.DataAnnotations;

namespace DriverMvc.Models
{
    public class DriverSignupModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Any other properties
    }
}

