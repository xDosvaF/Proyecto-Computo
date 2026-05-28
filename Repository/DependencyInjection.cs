

using Microsoft.Extensions.DependencyInjection;
using Repository.Data;
using Repository.Implementation;
using Repository.Interfaces;

namespace Repository
{
    public static class DependencyInjection
    {
        public static void RegisterRepositoryDependencies(this IServiceCollection services)
        {
            services.AddSingleton<Conexion>();
            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IUsuarioRepository , UsuarioRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProductoRepository , ProductoRepository>();
            services.AddTransient<IDetalleVentaRepository , DetalleVentaRepository>();
        }
    }
}
