using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Producto
    {
        public int idProducto { get; set; }
        public Categoria RefCategoria { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public decimal precio { get; set; }
        public int stock { get; set; }
        public bool activo { get; set; }

    }
}
