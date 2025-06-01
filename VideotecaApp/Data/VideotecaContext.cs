using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VideotecaApp.Models;

namespace VideotecaApp.Data
{
    public class VideotecaContext : DbContext
    {
        public VideotecaContext(DbContextOptions<VideotecaContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Renta> Rentas => Set<Renta>();
    }
}
