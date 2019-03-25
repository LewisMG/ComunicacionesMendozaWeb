using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<EntradaProductos> EntradaProductos { get; set; }
        public DbSet<Ventas> Venta { get; set; }
        public DbSet<VentasDetalle> Ventas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        public Contexto() : base("ConStr") { }
    }
}
