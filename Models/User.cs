using System.ComponentModel.DataAnnotations;

namespace absensionline.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
    }
}