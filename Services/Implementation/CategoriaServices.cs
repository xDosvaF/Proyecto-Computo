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
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaServices(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Categoria>> Lista()
        {
            return await _repository.Lista();
        }
    }
}
