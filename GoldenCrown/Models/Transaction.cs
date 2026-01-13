using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.Models
{
    public record Transaction
        (
        long Id,
        long SenderAccountId,
        long ReceiverAccountId,
        DateTime CreatedAt,
        [Range(0.01, Double.MaxValue)] Decimal Amount
        );
}
