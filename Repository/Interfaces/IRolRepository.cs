

using Repository.Entities;

namespace Repository.Interfaces
{
    public interface IRolRepository
    {
        Task<List<Rol>> Lista();
    }
}
