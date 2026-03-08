namespace LibraryManagementSystem.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
