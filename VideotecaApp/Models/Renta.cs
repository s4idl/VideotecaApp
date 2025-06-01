using System;
using System.ComponentModel.DataAnnotations;

namespace VideotecaApp.Models
{
    public class Renta
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un cliente.")]
        public int ClienteId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una película.")]
        public int PeliculaId { get; set; }

        public DateTime FechaRenta { get; set; } = DateTime.Now;

        public bool Devuelto { get; set; }

        public Cliente? Cliente { get; set; }
        public Pelicula? Pelicula { get; set; }

    }
}
