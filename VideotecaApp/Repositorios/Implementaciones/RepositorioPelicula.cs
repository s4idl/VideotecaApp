using VideotecaApp.Models;
using VideotecaApp.Data;
using VideotecaApp.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VideotecaApp.Repositorio.Implementaciones
{
    public class RepositorioPelicula : IRepositorioPelicula
    {
        private readonly VideotecaContext _context;
        public RepositorioPelicula(VideotecaContext context) => _context = context;

        public async Task<List<Pelicula>> ObtenerTodas() => await _context.Peliculas.ToListAsync();

        public async Task Crear(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task<Pelicula?> ObtenerPorId(int id) =>
            await _context.Peliculas.FindAsync(id);

        public async Task Actualizar(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula != null)
            {
                _context.Peliculas.Remove(pelicula);
                await _context.SaveChangesAsync();
            }
        }
    }
}