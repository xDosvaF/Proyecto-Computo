using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IVentaRepository
    {
        Task<string> Registrar(string venta);
        Task<string> Guardar(Venta objeto);
        Task<Venta> Obtener(string idVenta);
        Task<List<DetalleVenta>> ObtenerDetalle();
    }
}
