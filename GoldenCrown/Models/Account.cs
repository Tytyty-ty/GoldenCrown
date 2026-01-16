using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.Models
{
    public record Account
    {
        public long AccountId { get; set; }
        public long UserId { get; set; }
        public Decimal Balance { get; set; }
    };
}
