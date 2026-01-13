using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.Models
{
    public record User 
        (
        long Id,
        [MinLength(3)] [MaxLength(32)] string Login, 
        [MinLength(3)] [MaxLength(32)] string Name, 
        [MinLength(6)] [MaxLength(32)] string Password
        );
}
