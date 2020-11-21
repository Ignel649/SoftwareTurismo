using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace WpfTurismo.Controlador
{
   public class Combobox : INotifyPropertyChanged
    {
        DataCombo _obj = new DataCombo();

        private ObservableCollection<Region> _regionCombo = new ObservableCollection<Region>();
        private ObservableCollection<Comuna> _comunaCombo = new ObservableCollection<Comuna>();

        public void cargarRegion()
        {
            _regionCombo = new ObservableCollection<Region>(_obj.RegionList());
        }

        public void cargarComuna(string region_id)
        {
            _comunaCombo = new ObservableCollection<Comuna>
                    (from comuna in _obj.ComunaList()
                     where comuna.region.Equals(region_id)
                     select comuna);

            OnPropertyChanged("SingleComunaList");
        }



        public ObservableCollection<Region> SingleRegionList
        {
            get
            {
                return _regionCombo;
            }
            
        }

        public ObservableCollection<Comuna> SingleComunaList
        {
            get
            {
                return _comunaCombo;
            }
        }

        #region General Propertychange methods

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="PropertyName">Name of the property.</param>
        protected void OnPropertyChanged(string PropertyName)
        {
            VerifyPropertyName(PropertyName);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This 
        /// method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        private void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;
                throw new Exception(msg);
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
