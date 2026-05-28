using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Usuario
    {
        public int idUsuario {  get; set; }
        public Rol RefRol { get; set; } 
        public string nombre_completo { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
        public int sexo { get; set; }
        public bool activo { get; set; }

    }
}
