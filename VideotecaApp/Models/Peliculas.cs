using System.ComponentModel.DataAnnotations;

namespace VideotecaApp.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El género es obligatorio.")]
        public string Genero { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Debe haber al menos una copia disponible.")]
        public int CantidadDisponible { get; set; }

        [Range(0, int.MaxValue)]
        public int VecesRentada { get; set; } = 0;
    }
}
