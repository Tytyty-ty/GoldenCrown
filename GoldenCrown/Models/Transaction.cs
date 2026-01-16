using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.Models
{
    public record Transaction
    {
        public long Id { get; set; }
        public long SenderAccountId { get; set; }
        public long ReceiverAccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Decimal Amount { get; set; }
    };
}
