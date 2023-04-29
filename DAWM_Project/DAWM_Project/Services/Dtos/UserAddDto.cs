using System.ComponentModel.DataAnnotations;

namespace DAWM_Project.Services.Dtos
{
    public class UserAddDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
