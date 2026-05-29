using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IVentaServices 
    {
        Task<string> Registrar(string venta);
        Task<string> Guardar(Venta objeto);
        Task<Venta> Obtener(string idVenta);
        Task<List<DetalleVenta>> ObtenerDetalle();
    }
}
