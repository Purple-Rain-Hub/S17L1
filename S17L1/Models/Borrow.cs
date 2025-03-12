using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace S17L1.Models
{
    [PrimaryKey(nameof(UserId), nameof(BookId))]
    public class Borrow
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public DateTime BorrowEndDate { get; set; }
        [Required]
        public bool IsReturned { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }

    }
}
