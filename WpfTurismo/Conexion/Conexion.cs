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
using System.Runtime.InteropServices.WindowsRuntime;

namespace WpfTurismo
{
    public class Conexion
    {
        //Metodo para obtener la direccion ip para el registro
        public static string ObtenerIpAdrees()
        {
            string resu = "";
            string url = "https://freegeoip.app/json/";

            var Json = new WebClient().DownloadString(url);

            Ipe a = JsonConvert.DeserializeObject<Ipe>(Json);

            resu = a.Ip;

            return resu;
        }
        //Metodo para mandar la infomacion de inicio de sesion para validar y la creacion del token por parte de la api
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

                //Console.WriteLine(responseString);

                return responseString;
            }
            catch (WebException ex)
            {
                Console.WriteLine(((HttpWebResponse)ex.Response).StatusDescription);
                var error = ((HttpWebResponse)ex.Response);

                return error;

            }

        }
        //Metodo para traer el tipo de usuario de para validar en el inicio de sesion
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

            //Console.WriteLine(resp);
            string resul = "";
            

            DatosUsuario D = JsonConvert.DeserializeObject<DatosUsuario>(resp);

            resul = D.TipoUsuario;
            return resul;
        }

        public static string AgregarUsu(AgregaUsuario usu)
        {
            string url = "http://localhost:5000/api/user/register";

            string json = JsonConvert.SerializeObject(usu);

            WebClient conect = new WebClient();
            conect.Headers[HttpRequestHeader.ContentType] = "application/json";
            string HtmlResult = conect.UploadString(url, "POST", json);



            return HtmlResult;
        }
        //Metodo para buscar edificio y guardar los datos en un objeto


        //Metodo para crear el edificio mandando el json con los datos correspondientes capturadon en pantalla 
        public static string CrearEdi(string token , Edificio edi)
        {
            

            string url = "http://localhost:5000/api/edificio/create ";
                //var resp = await xd.Content.ReadAsStringAsync();

            string json = JsonConvert.SerializeObject(edi);

            //var conec = new WebClient().Headers.Set("Content-Type", "application/x-www-form-urlencoded").UploadString(url, "POST", json);
            WebClient conect = new WebClient();
            conect.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
            conect.Headers[HttpRequestHeader.ContentType] = "application/json";
            string HtmlResult = conect.UploadString(url, "POST", json);

            //Console.WriteLine(HtmlResult);

            return HtmlResult;
        }
        // Actualizar Edificio 
        public static string ActualizarEdi(string token,Edificio edi,int ide)
        {
            string url = "http://localhost:5000/api/edificio/"+ide+"/update";

            string json = JsonConvert.SerializeObject(edi);

            WebClient conect = new WebClient();
            conect.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
            conect.Headers[HttpRequestHeader.ContentType] = "application/json";
            string HtmlResult = conect.UploadString(url, "PUT", json);

            Console.WriteLine(json);
            return HtmlResult;
        }
        // Eliminar edificio
        public static string EliminarEdi(string token, int ide)
        {
            string url = "http://localhost:5000/api/edificio/" + ide + "/delete";

            WebClient conect = new WebClient();
            conect.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
            conect.Headers[HttpRequestHeader.ContentType] = "application/json";
            string HtmlResult = conect.UploadString(url, "DELETE","");

            return HtmlResult;
        }
        // Agredar departamento al registro 
        public static string CrearDepa(string token , Departamento depa)
        {
            string url = "http://localhost:5000/api/departamento/create";

            string json = JsonConvert.SerializeObject(depa);

            WebClient conect = new WebClient();
            conect.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
            conect.Headers[HttpRequestHeader.ContentType] = "application/json";
            string HtmlResult = conect.UploadString(url, "POST", json);

            Console.WriteLine(HtmlResult);

            return HtmlResult;

        }
        // Actualizar Departamento
        public static string ActualizarDepa(string token, Departamento depa, int ide)
        {
            string url = "http://localhost:5000/api/departamento/" + ide + "/update";

            string json = JsonConvert.SerializeObject(depa);

            WebClient conect = new WebClient();
            conect.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
            conect.Headers[HttpRequestHeader.ContentType] = "application/json";
            string HtmlResult = conect.UploadString(url, "PUT", json);

            
            return HtmlResult;
        }
        //Eliminar Departamento con id del mismo
        public static string EliminarDepa(string token,int ide)
        {
            string url = "http://localhost:5000/api/departamento/" + ide + "/delete";

            WebClient conect = new WebClient();
            conect.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
            conect.Headers[HttpRequestHeader.ContentType] = "application/json";
            string HtmlResult = conect.UploadString(url, "DELETE", "");

            return HtmlResult;
        }
        //Obtener Nombre de edificio
        public static List<ObtenerEdificio> ObtenerEdificio()
        {
            string url = "http://localhost:5000/api/edificios";
            WebClient conect = new WebClient();
 
            string HtmlResult = conect.DownloadString(url);

            List<ObtenerEdificio> a = JsonConvert.DeserializeObject<List<ObtenerEdificio>>(HtmlResult);

            /* foreach(ObtenerEdificio edi in a)
             {
                 Console.WriteLine(edi.nombre);
             }*/
            return a;
        }
        //Buscar Edificios por nombre
        public static List<ObtenerEdificio> BuscarEdificio(string token , string ediNombre)
        {
            string url = "http://localhost:5000/api/edificioByName/"+ediNombre;

            WebClient conect = new WebClient();
            conect.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
            string json = conect.DownloadString(url);

            List<ObtenerEdificio> xd = JsonConvert.DeserializeObject<List<ObtenerEdificio>>(json);

            return xd;
        }
        //buscar departamentos por nombre edificio y numero
        public static List<ObtenerDepartamento> BuscarDepa(string token ,string ediNombre,int depaNumero)
        {
            string url = "http://localhost:5000/api/depanumeroedificio/"+depaNumero+"/" + ediNombre;

            WebClient conect = new WebClient();
            conect.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
            string json = conect.DownloadString(url);

            List<ObtenerDepartamento> xd = JsonConvert.DeserializeObject<List<ObtenerDepartamento>>(json);

            return xd;
        }
        //Obtener las regiones
        public static List<Region> ObtenerRegion()
        {
            string url = "http://localhost:5000/api/combo/region";
            WebClient conect = new WebClient();

            string json = conect.DownloadString(url);

            List<Region> a = JsonConvert.DeserializeObject<List<Region>>(json);

            return a;
        }
        //Obtener Comunas
        public static List<Comuna> ObtenerComunas()
        {
            string url = "http://localhost:5000/api/combo/comuna";
            WebClient conect = new WebClient();

            string json = conect.DownloadString(url);

            List<Comuna> a = JsonConvert.DeserializeObject<List<Comuna>>(json);

            return a;
        }
        // Obtener departamentos para datagrid
        public static List<ObtenerDepartamento> DepaGrid()
        {
            string url = "http://localhost:5000/api/departamentos";
            WebClient conect = new WebClient();

            string json = conect.DownloadString(url);

            List<ObtenerDepartamento> xd = JsonConvert.DeserializeObject<List<ObtenerDepartamento>>(json);

            return xd;
        }

        public static void prueba(Edificio xd)
        {
           

            string jsons = JsonConvert.SerializeObject(xd);

            Console.WriteLine(jsons);

        }
    }
}
