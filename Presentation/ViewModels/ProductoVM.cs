using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class ProductoVM
    {
        public int idProducto { get; set; }
        public int idCategoria { get; set; }
        public string nombre_categoria { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public decimal precio { get; set; }
        public int stock { get; set; }
        public bool activo { get; set; }
    }
}
