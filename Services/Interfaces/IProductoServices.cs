using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductoServices
    {
        Task<List<Producto>> Lista(string buscar);

        Task<string> Crear(Producto objeto);

        Task<string> Editar(Producto objeto);
    }
}
