using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> Lista(string buscar);

        Task<string> Crear(Producto objeto);

        Task<string> Editar(Producto objeto);
    }
}
