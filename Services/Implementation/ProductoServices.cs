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
    public class ProductoServices : IProductoServices
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoServices(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<string> Crear(Producto objeto)
        {
            return await _productoRepository.Crear(objeto);
        }

        public async Task<string> Editar(Producto objeto)
        {
            return await _productoRepository.Editar(objeto);
        }

        public async Task<List<Producto>> Lista(string buscar)
        {
            return await _productoRepository.Lista(buscar);
        }
    }
}
