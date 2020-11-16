using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTurismo.Controlador
{
    public class AgregaUsuario
    {
        public string nombre { get; set; }
        public string contrasenia { get; set; }
        public string email { get; set; }
        public string foto { get; set; }
        public string rut { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int fk_id_tipo_usu { get; set; }

    }
}
