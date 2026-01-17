using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.DTOs
{
    public record RegisterRequest(
        [Required(ErrorMessage = "The login field is empty. Please fill it.")]
        [MinLength(3, ErrorMessage = "The login field is required length from 3 characters.")]
        string Login,

        [Required(ErrorMessage = "The name field is empty. Please fill it.")]
        [MinLength(3, ErrorMessage = "The name field is required length from 3 characters.")]
        string Name,

        [Required(ErrorMessage = "The password field is empty. Please fill it.")]
        [MinLength(6, ErrorMessage = "The password field is required length from 6 characters.")]
        string Password
        );
}
