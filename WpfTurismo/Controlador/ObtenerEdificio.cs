using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WpfTurismo.Controlador
{
    public class ObtenerEdificio
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "nombre")]
        public string nombre { get; set; }
        [JsonProperty(PropertyName = "direccion")]
        public string direccion { get; set; }
        [JsonProperty(PropertyName = "telefono")]
        public int telefono { get; set; }
        [JsonProperty(PropertyName = "comuna")]
        public string comuna { get; set; }
        [JsonProperty(PropertyName = "region")]
        public string region { get; set; }
        [JsonProperty(PropertyName = "activo")]
        public int activo { get; set; }
    }
}
