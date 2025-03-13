using System.ComponentModel.DataAnnotations;

namespace S17L1.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }
        [Required]
        [StringLength(50)]
        public required string Surname { get; set; }
        [Required]
        [StringLength(50)]
        public required string Email { get; set; }

        public ICollection<Borrow>? Borrows { get; set; }
    }
}
