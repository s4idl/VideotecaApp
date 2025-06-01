using VideotecaApp.Models;

namespace VideotecaApp.Repositorio.Interfaces
{
    public interface IRepositorioRenta
    {
        Task<List<Renta>> ObtenerTodas();
        Task<Renta?> ObtenerPorId(int id);
        Task Crear(Renta renta);
        Task Actualizar(Renta renta);
        Task Eliminar(int id);
        Task MarcarComoDevuelto(int id);
    }
}
