using Repository.Entities;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementation
{
    public class RolServices : IRolServices
    {
        private readonly IRolRepository _repository;

        public RolServices(IRolRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Rol>> Lista()
        {
            return await _repository.Lista();
        }
    }
}
