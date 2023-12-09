using VGuitarrasBolivia.Models;
using Microsoft.EntityFrameworkCore;

namespace VGuitarrasBolivia.Context
{
    public class MiContext : DbContext
    {
        public MiContext(DbContextOptions options) : base(options)
        {

        }
        //clases persistentes se transforman en base de datos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Guitarra> Guitarra { get; set; }
        public DbSet<Pago> Pago { get; set; }
    }
}
