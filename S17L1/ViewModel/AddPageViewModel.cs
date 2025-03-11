using System.ComponentModel.DataAnnotations;

namespace S17L1.ViewModel
{
    public class AddPageViewModel
    {
        [Required]
        [StringLength(50)]
        public required string Titolo { get; set; }
        [Required]
        [StringLength(50)]
        public required string Autore { get; set; }
        [Required]
        [StringLength(30)]
        public required string Genere { get; set; }
        [Required]
        public bool Disponibilita { get; set; }
        public string? Copertina { get; set; }
    }
}
