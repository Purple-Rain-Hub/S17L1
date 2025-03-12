using System.ComponentModel.DataAnnotations;

namespace S17L1.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public ICollection<Borrow> Borrows { get; set; }
    }
}
