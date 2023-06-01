using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngestaCalorica
{
    public class CaloriasDias : INotifyPropertyChanged
    {
        int totalCalorias_;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime dia { get; set; }
        public string cadenaDia { get; set; }
        public int desayuno { get; set; }
        public int mediodia { get; set; }
        public int comida { get; set; }
        public int merienda { get; set; }
        public int cena { get; set; }
        public int otros { get; set; }
        public int totalCalorias
        {
            get { return totalCalorias_; }
            set { totalCalorias_ = value; OnPropertyChanged("totalCalorias"); }
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }

        public CaloriasDias()
        {
            this.dia = DateTime.Today;
            this.cadenaDia = "";
            this.desayuno = 0;
            this.mediodia = 0;
            this.comida = 0;
            this.merienda = 0;
            this.cena = 0;
            this.otros = 0;
            this.totalCalorias = 0;
        }

    }
}
