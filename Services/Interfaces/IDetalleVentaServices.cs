using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDetalleVentaServices
    {
        Task<string> Crear(DetalleVenta objeto);
        Task<List<DetalleVenta>> Lista();
    }
}
