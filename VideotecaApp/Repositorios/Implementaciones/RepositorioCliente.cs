using VideotecaApp.Models;
using VideotecaApp.Data;
using VideotecaApp.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VideotecaApp.Repositorio.Implementaciones
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly VideotecaContext _context;
        public RepositorioCliente(VideotecaContext context) => _context = context;

        public async Task<List<Cliente>> ObtenerTodos() => await _context.Clientes.ToListAsync();

        public async Task Crear(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente?> ObtenerPorId(int id) =>
            await _context.Clientes.FindAsync(id);

        public async Task Actualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}