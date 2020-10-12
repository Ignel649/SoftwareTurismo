using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Security.Policy;
using System.IO;
using WpfTurismo.Controlador;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WpfTurismo
{
    public class Conexion
    {
        public static string ObtenerIpAdrees()
        {
            string resu = "";
            string url = "https://freegeoip.app/json/";

            var Json = new WebClient().DownloadString(url);

            Ipe a = JsonConvert.DeserializeObject<Ipe>(Json);

            resu = a.Ip;

            return resu;
        }
        public static dynamic MandarCredenciales(Usuario usuario)
        {
            try
            {
                var values = new NameValueCollection();
                values["email"] = usuario.email;
                values["pass"] = usuario.pass;
                values["device_name"] = usuario.device_name;
                values["ip_adress"] = usuario.ip_adress;

                var xd = new WebClient().UploadValues("http://localhost:5000/api/user/login", "POST", values);
                var responseString = Encoding.Default.GetString(xd);

                Console.WriteLine(responseString);

                return responseString;
            }
            catch (WebException ex)
            {
                Console.WriteLine(((HttpWebResponse)ex.Response).StatusDescription);
                var error = ((HttpWebResponse)ex.Response);

                return error;

            }

        }
        public static async Task<string> TipoDeUsuario(Token token)
        {
            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" , token.token);

            string url = "http://localhost:5000/api/user";
            

            cliente.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

           HttpResponseMessage xd = await cliente.GetAsync(url);

            xd.EnsureSuccessStatusCode();
            var resp = await xd.Content.ReadAsStringAsync();

            Console.WriteLine(resp);
            string resul = "";
            

            DatosUsuario D = JsonConvert.DeserializeObject<DatosUsuario>(resp);

            resul = D.TipoUsuario;
            return resul;
        }
    }
}
