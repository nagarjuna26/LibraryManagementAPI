namespace LibraryManagementSystem.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }              
        public int BookId { get; set; }          
        public int MemberId { get; set; }        
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

    }
}
