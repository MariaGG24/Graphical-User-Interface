using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngestaCalorica
{
    public class TablaComidas : INotifyPropertyChanged
    {
        string comidaSeleccionada_;
        int caloriasComidaSeleccionada_;

        public event PropertyChangedEventHandler PropertyChanged;

        public string comidaSeleccionada
        {
            get { return comidaSeleccionada_; }
            set { comidaSeleccionada_ = value; OnPropertyChanged("comidaSeleccionada"); }
        }

        public int caloriasComidaSeleccionada
        {
            get { return caloriasComidaSeleccionada_; }
            set { caloriasComidaSeleccionada_ = value; OnPropertyChanged("caloriasComidaSeleccionada"); }
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }

        public TablaComidas()
        {
            this.comidaSeleccionada = "";
            this.caloriasComidaSeleccionada = 0;
        }
    }
}
