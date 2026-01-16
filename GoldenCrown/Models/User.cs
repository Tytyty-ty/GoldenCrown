using System.ComponentModel.DataAnnotations;

namespace GoldenCrown.Models
{
    public record User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    };
}
