using VideotecaApp.Models;
using VideotecaApp.Data;
using VideotecaApp.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VideotecaApp.Repositorio.Implementaciones
{
    public class RepositorioRenta : IRepositorioRenta
    {
        private readonly VideotecaContext _context;
        public RepositorioRenta(VideotecaContext context) => _context = context;

        public async Task<List<Renta>> ObtenerTodas() =>
            await _context.Rentas.Include(r => r.Cliente).Include(r => r.Pelicula).ToListAsync();

        public async Task Crear(Renta renta)
        {
            var pelicula = await _context.Peliculas.FindAsync(renta.PeliculaId);
            var rentasActivas = await _context.Rentas
                .Where(r => r.ClienteId == renta.ClienteId && !r.Devuelto)
                .CountAsync();

            if (pelicula == null || pelicula.CantidadDisponible <= 0)
                throw new InvalidOperationException("No hay copias disponibles de la película seleccionada.");

            if (rentasActivas >= 3)
                throw new InvalidOperationException("Este cliente ya tiene 3 películas rentadas activas.");

            _context.Rentas.Add(renta);
            pelicula.CantidadDisponible--;
            pelicula.VecesRentada++; // ✅ Se incrementa cuando se renta
            await _context.SaveChangesAsync();
        }

        public async Task<Renta?> ObtenerPorId(int id) =>
            await _context.Rentas
                .Include(r => r.Cliente)
                .Include(r => r.Pelicula)
                .FirstOrDefaultAsync(r => r.Id == id);

        public async Task Actualizar(Renta renta)
        {
            _context.Rentas.Update(renta);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var renta = await _context.Rentas.FindAsync(id);
            if (renta != null)
            {
                _context.Rentas.Remove(renta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarcarComoDevuelto(int id)
        {
            var renta = await _context.Rentas.FindAsync(id);

            if (renta != null && !renta.Devuelto)
            {
                renta.Devuelto = true;

                var pelicula = await _context.Peliculas.FindAsync(renta.PeliculaId);
                if (pelicula != null)
                {
                    pelicula.CantidadDisponible++;

                    if (pelicula.VecesRentada > 0)
                    {
                        pelicula.VecesRentada--; 
                    }
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
