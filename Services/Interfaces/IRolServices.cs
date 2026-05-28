

using Repository.Entities;

namespace Services.Interfaces
{
    public interface IRolServices
    {
        Task<List<Rol>> Lista();
    }
}
