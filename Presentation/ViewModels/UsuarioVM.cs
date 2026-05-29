

namespace Presentation.ViewModels
{
    public class UsuarioVM
    {
        public int idUsuario {  get; set; }
        public int idRol {  get; set; }
        public string nombre_rol { get; set; } = string.Empty;
        public string nombre_completo {  get; set; } = string.Empty;
        public string correo {  get; set; } = string.Empty;
        public int sexo { get; set; }
        public string sexo2 { get; set; } = string.Empty ;
        public bool activo { get; set; }
    }
}
