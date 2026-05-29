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
    public class DetalleVentaServices : IDetalleVentaServices
    {
        private readonly IDetalleVentaRepository _repository;

        public DetalleVentaServices(IDetalleVentaRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> Crear(DetalleVenta objeto)
        {
            return await _repository.Crear(objeto);
        }

        public async Task<List<DetalleVenta>> Lista()
        {
            return await _repository.Lista();
        }
    }
}
