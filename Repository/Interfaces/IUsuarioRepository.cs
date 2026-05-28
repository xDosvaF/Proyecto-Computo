using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> Lista(string buscar);
        Task<string> Crear(Usuario objeto);
        Task<string> Editar(Usuario objeto);

    }
}
