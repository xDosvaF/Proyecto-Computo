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
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioServices(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> Crear(Usuario objeto)
        {
            return await _repository.Crear(objeto);
        }

        public async Task<string> Editar(Usuario objeto)
        {
            return await _repository.Editar(objeto);
        }

        public async Task<List<Usuario>> Lista(string buscar)
        {
            return await _repository.Lista(buscar);
        }
    }
}
