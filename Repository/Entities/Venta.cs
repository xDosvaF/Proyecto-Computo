using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Venta
    {
        public int idVenta {  get; set; }
        public Usuario UsuarioRegistro { get; set; }
        public string nombre_cliente { get; set; } = string.Empty;
        public decimal pago_total { get; set; }
        public decimal pago {  get; set; }
        public decimal cambio { get; set; }
        public string fecha_registro { get; set; } = string.Empty;
        public int activo {  get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
