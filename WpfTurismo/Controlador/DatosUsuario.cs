using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTurismo.Controlador
{
    class DatosUsuario
    {
        [JsonProperty(PropertyName = "TipoUsuario")]
        public string TipoUsuario { get; set; }
    }
}
