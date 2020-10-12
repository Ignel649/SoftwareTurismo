using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTurismo.Controlador
{
     public class Usuario
    {
        public string email { get; set; }
        public string pass { get; set; }
        public string device_name { get; set; }
        public string ip_adress { get; set; }


        /*public Usuario(string correo ,string contrasenia,string dispositivo,string ip)
        {
            this.Correo = correo;
            this.Contrasenia = contrasenia;
            this.Dispositivo = dispositivo;
            this.Ip = ip;
        }*/

    }
}
