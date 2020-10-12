using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTurismo.Controlador
{
     public class Ipe
    {
        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }

    }
}
