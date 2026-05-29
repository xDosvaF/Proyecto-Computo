using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class DetalleVentaVM
    {
        public int idProducto { get; set; }
        public int idVenta { get; set; }
        public string nombre_cliente { get; set; }
        public string producto { get; set; } = string.Empty;
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
