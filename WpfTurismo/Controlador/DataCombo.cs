using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfTurismo.Controlador
{
    public class DataCombo
    {
        List<Comuna> comu = Conexion.ObtenerComunas();
        List<Region> regiones = Conexion.ObtenerRegion();

        

        ObservableCollection<Region> _region = new ObservableCollection<Region>();
        ObservableCollection<Comuna> _comuna = new ObservableCollection<Comuna>();
        public ObservableCollection<Region> RegionList()
        {
            _region.Clear();

            foreach (Region x in regiones)
            {
                _region.Add(new Region { nombre_region = x.nombre_region, id = x.id });
            }

            return _region;

        }
        public ObservableCollection<Comuna> ComunaList()
        {
            _comuna.Clear();

            foreach (Comuna x in comu)
            {
                _comuna.Add(new Comuna { id = x.id, nombre_comuna = x.nombre_comuna, region = x.region});
            }
            Console.WriteLine(comu.Count);
            Console.WriteLine(_comuna);
            return _comuna;

        }
    }
}
