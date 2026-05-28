using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUsuarioServices
    {
        Task<List<Usuario>> Lista(string buscar="");
        Task<string> Crear(Usuario objeto);
        Task<string> Editar(Usuario objeto);
    }
}
