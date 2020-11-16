using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTurismo.Controlador
{
    public class Departamento
    {
        public int numero_habitacion { get; set; }

        public int numero_habitaciones { get; set; }

        public int metros_cuadrados { get; set; }

        public int banios { get; set; }

        public int piso { get; set; }

        public int precio_noche { get; set; }

        public string foto { get; set; }

        public int fk_id_edificio { get; set; }

        public int fk_id_estado { get; set; }
    }
}
