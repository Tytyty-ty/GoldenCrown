using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.DTOs
{
    public record LoginRequest(
        [Required(ErrorMessage = "The login field is empty. Please fill it.")] string Login, 
        [Required(ErrorMessage = "The passowrd field is empty. Please fill it.")] string Password
        );
}
