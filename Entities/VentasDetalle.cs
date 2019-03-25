using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class VentasDetalle
    {
        [Key]
        public int VDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Productos { get; set; }

        public VentasDetalle()
        {
            VDetalleId = 0;
            VentaId = 0;
        }

        public VentasDetalle(int vDetalleId, int ventaId, int productoId, string producto, int cantidad, int precio, int importe)
        {
            VDetalleId = vDetalleId;
            VentaId = ventaId;
            ProductoId = productoId;
            Producto = producto;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
