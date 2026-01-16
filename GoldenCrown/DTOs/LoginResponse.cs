using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.DTOs
{
    public record LoginResponse([Required] string Token);
}
