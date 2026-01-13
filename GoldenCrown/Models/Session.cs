using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.Models
{
    public record Session
        (
        long UserId,
        string Token,
        DateTime ExpiresAt
        );
}
