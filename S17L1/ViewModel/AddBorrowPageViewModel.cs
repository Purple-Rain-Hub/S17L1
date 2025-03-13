using System.ComponentModel.DataAnnotations;

namespace S17L1.ViewModel
{
    public class AddBorrowPageViewModel
    {
        [Required]
        public DateTime BorrowEndDate { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Surname { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

    }
}
