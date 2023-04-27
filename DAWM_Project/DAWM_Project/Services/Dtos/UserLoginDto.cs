using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DAWM_Project.Services.Dtos
{
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
