using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.Models
{
    public record Account
        (
        long AccountId,
        long UserId,
        Decimal Balance
        );
}
