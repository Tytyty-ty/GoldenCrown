using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.Models
{
    public record Session
    {
        public long UserId { get; set; }
        public string? Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    };
}
