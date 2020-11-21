using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfTurismo.Controlador
{
    public class Comuna
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "nombre_comuna")]
        public string nombre_comuna { get; set; }
        [JsonProperty(PropertyName = "region")]
        public int region { get; set; }
    }
}
