using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Phone]
        [Required] 
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;

        // Navigation property
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
