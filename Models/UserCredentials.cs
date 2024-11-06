using System.ComponentModel.DataAnnotations;

namespace BaseApiJwtAndBasicsAuth.Models
{
    public class UserCredentials
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
