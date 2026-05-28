using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class DetalleVenta
    {
        public int idDetalleVenta {  get; set; }
        public Producto RefProducto { get; set; }
        public int cantidad { get; set; }
        public int precio_total { get; set; }
    }
}
