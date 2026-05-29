

using Microsoft.Extensions.DependencyInjection;
using Services.Implementation;
using Services.Interfaces;
using System.Runtime.CompilerServices;

namespace Services
{
    public static class DependencyInjection
    {
        public static void RegisterServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRolServices, RolServices>();
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<ICategoriaServices, CategoriaServices>();
            services.AddTransient<IProductoServices, ProductoServices>();
            services.AddTransient<IDetalleVentaServices, DetalleVentaServices>();
            services.AddTransient<IVentaServices, VentaServices>();
        }
    }
}
