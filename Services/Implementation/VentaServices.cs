using Repository.Entities;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class VentaServices : IVentaServices
    {
        private readonly IVentaRepository _ventaRepository;

        public VentaServices(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<string> Guardar(Venta objeto)
        {
            return await _ventaRepository.Guardar(objeto);
        }

        public async Task<Venta> Obtener(string idVenta)
        {
            return await _ventaRepository.Obtener(idVenta);
        }

        public async Task<List<DetalleVenta>> ObtenerDetalle()
        {
            return await _ventaRepository.ObtenerDetalle();
        }

        public async Task<string> Registrar(string venta)
        {
            return await _ventaRepository.Registrar(venta);
        }
    }
}
