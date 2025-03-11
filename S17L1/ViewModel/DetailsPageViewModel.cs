using System.ComponentModel.DataAnnotations;

namespace S17L1.ViewModel
{
    public class DetailsPageViewModel
    {
        public Guid Id { get; set; }
        public required string Titolo { get; set; }
        public required string Autore { get; set; }
        public required string Genere { get; set; }
        public bool Disponibilita { get; set; }
        public string? Copertina { get; set; }
    }
}
