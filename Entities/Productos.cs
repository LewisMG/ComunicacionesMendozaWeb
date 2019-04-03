using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        public int Ganancia { get; set; }
        public int Precio { get; set; }
        public int Inventario { get; set; }

        public Productos()
        {
            Fecha = DateTime.Now;
        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
