namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public int PublishedYear { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Navigation property
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
