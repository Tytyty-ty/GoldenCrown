using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.DTOs
{
    public record RegisterRequest(
        [Required(ErrorMessage = "The login field is empty. Please fill it.")] string Login,
        [Required(ErrorMessage = "The name field is empty. Please fill it.")] string Name,
        [Required(ErrorMessage = "The password field is empty. Please fill it.")] string Password
        );
}
