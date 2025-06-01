using VideotecaApp.Models;

namespace VideotecaApp.Repositorio.Interfaces
{
    public interface IRepositorioPelicula
    {
        Task<List<Pelicula>> ObtenerTodas();
        Task<Pelicula?> ObtenerPorId(int id);
        Task Crear(Pelicula pelicula);
        Task Actualizar(Pelicula pelicula);
        Task Eliminar(int id);
    }
}
