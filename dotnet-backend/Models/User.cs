using System.ComponentModel.DataAnnotations;

namespace dotnet_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
        public Boolean IsSeller { get; set; }
    }
}