using System.ComponentModel.DataAnnotations;

namespace CoreApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage="La password tiene que contener entre 4 y 8 caracteres")]
        public string Password { get; set; }
    }
}