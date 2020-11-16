using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTurismo.Controlador
{
     public class Edificio
    {
        public string nombre { get; set; }

        public string direccion_edificio { get; set; }

        public int telefono { get; set; }

        public string foto { get; set; }

        public int fk_id_comuna { get; set; }

    }
}
