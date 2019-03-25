using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string NombreCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<VentasDetalle> Detalle { get; set; }

        public Ventas()
        {
            this.Detalle = new List<VentasDetalle>();

            Fecha = DateTime.Now;
        }

        public void AgregarDetalle(int VDetalleId, int VentaId, int productoId, string producto, int Cantidad, int Precio, int Importe)
        {
            this.Detalle.Add(new VentasDetalle(VDetalleId, VentaId, productoId, producto, Cantidad, Precio, Importe));
        }
    }
}
