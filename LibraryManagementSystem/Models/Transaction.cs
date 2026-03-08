namespace LibraryManagementSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

        public int MemberId { get; set; }
        public Member? Member { get; set; }

        public DateTime BorrowedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ReturnedDate { get; set; }
    }
}
