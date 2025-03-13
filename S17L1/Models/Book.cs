using System.ComponentModel.DataAnnotations;

namespace S17L1.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Titolo { get; set; }
        [Required]
        [StringLength(50)]
        public required string Autore { get; set; }
        [Required]
        [StringLength(30)]
        public required string Genere { get; set; }
        public bool Disponibilita { get; set; }
        public string? Copertina { get; set; }

        public Borrow? Borrow { get; set; }
    }
}
