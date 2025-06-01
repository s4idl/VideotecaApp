using VideotecaApp.Models;

namespace VideotecaApp.Repositorio.Interfaces
{
    public interface IRepositorioCliente
    {
        Task<List<Cliente>> ObtenerTodos();
        Task<Cliente?> ObtenerPorId(int id);
        Task Crear(Cliente cliente);
        Task Actualizar(Cliente cliente);
        Task Eliminar(int id);
    }
}
