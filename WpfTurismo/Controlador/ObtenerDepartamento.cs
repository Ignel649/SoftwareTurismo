using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WpfTurismo.Controlador
{
    public class ObtenerDepartamento
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "num_habitacion")]
        public int num_habitacion { get; set; }
        [JsonProperty(PropertyName = "num_habitaciones")]
        public int num_habitaciones { get; set; }
        [JsonProperty(PropertyName = "metros_cuadrados")]
        public int metros_cuadrados { get; set; }
        [JsonProperty(PropertyName = "banios")]
        public int banios { get; set; }
        [JsonProperty(PropertyName = "piso")]
        public int piso { get; set; }
        [JsonProperty(PropertyName = "precio_noche")]
        public int precio_noche { get; set; }
        [JsonProperty(PropertyName = "edificio")]
        public string edificio { get; set; }
        [JsonProperty(PropertyName = "estado")]
        public string estado { get; set; }
        [JsonProperty(PropertyName = "nombreEdificio")]
        public string nombreEdificio { get; set; }
        [JsonProperty(PropertyName = "activo")]
        public int activo { get; set; }
    }
}
