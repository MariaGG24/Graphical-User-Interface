using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace IngestaCalorica
{
    /// <summary>
    /// Lógica de interacción para TablaDatos.xaml
    /// </summary>
    /// 
    public class TablaEventArgs : EventArgs
    {
        public DateTime fecha { get; set; }
        public TablaEventArgs(DateTime f)
        {
            fecha = f;
        }
    }

    public class BarrasEventArgs : EventArgs
    {
        public bool dibujo { get; set; }

        public BarrasEventArgs(bool d)
        {
            dibujo = d;
        }
    }
    public partial class TablaDatos : Window
    {
        ObservableCollection<CaloriasDias> listaCalorias;
        public event EventHandler<TablaEventArgs> hayseleccion;
        public event EventHandler<BarrasEventArgs> haybarra;
        ObservableCollection<TablaComidas> listaComidas;

        void Onhayseleccion(DateTime d)
        {
            if (hayseleccion != null)
                hayseleccion(this, new TablaEventArgs(d));
        }

        void Onhaybarra(bool dib)
        {
            if (lvFechas.SelectedItem != null)
                lvFechas.UnselectAll();
            if (haybarra != null)
                haybarra(this, new BarrasEventArgs(dib));
        }

        public TablaDatos(ObservableCollection<CaloriasDias> calorias, ObservableCollection<TablaComidas> comidas)
        {
            InitializeComponent();
            listaCalorias = calorias;
            listaComidas = comidas;
            lvFechas.ItemsSource = listaCalorias;
        }

        //******************************************************
        //*                   AÑADIR COMIDAS                   *
        //******************************************************
        private void anadirComida_Click(object sender, RoutedEventArgs e)
        {
            DateTime fechaDia;
            string comida;
            char separador = ' ';
            string[] cadena;
            int caloriasConsumidas;
            try
            {
                if (calendario.SelectedDate == null)
                {
                    et.Content = "Debe seleccionar una fecha.";
                    return;
                }
                fechaDia = (DateTime)calendario.SelectedDate;
                cadena = fechaDia.ToString().Split(separador);

                if ((comida = (string)comBox.SelectionBoxItem) == "")
                {
                    et.Content = "Debe seleccionar una comida.";
                    return;
                }

                caloriasConsumidas = int.Parse(cajaCalorias.Text);
            }
            catch (FormatException)
            {
                et.Content = "Algún dato de entrada no es correcto. \nInténtelo de nuevo";
                return;
            }

            et.Content = "";

            foreach (CaloriasDias c in listaCalorias)
            {
                if (c.dia == fechaDia.Date)
                {
                    if (comida == "Desayuno")
                    {
                        c.totalCalorias -= c.desayuno;
                        c.desayuno = caloriasConsumidas;
                    }
                    else if (comida == "Mediodía")
                    {
                        c.totalCalorias -= c.mediodia;
                        c.mediodia = caloriasConsumidas;
                    }
                    else if (comida == "Comida")
                    {
                        c.totalCalorias -= c.comida;
                        c.comida = caloriasConsumidas;
                    }
                    else if (comida == "Merienda")
                    {
                        c.totalCalorias -= c.merienda;
                        c.merienda = caloriasConsumidas;
                    }
                    else if (comida == "Cena")
                    {
                        c.totalCalorias -= c.cena;
                        c.cena = caloriasConsumidas;
                    }
                    else
                    {
                        c.totalCalorias -= c.otros;
                        c.otros = caloriasConsumidas;
                    }
                    c.cadenaDia = cadena[0];
                    c.totalCalorias += caloriasConsumidas;

                    if (c.desayuno == 0 && c.mediodia == 0 && c.comida == 0 && c.merienda == 0 && c.cena == 0 && c.otros == 0 && (CaloriasDias)lvFechas.SelectedItem != c)
                        listaCalorias.Remove(c);

                    comBox.SelectedItem = null;
                    calendario.SelectedDate = null;
                    cajaCalorias.Text = null;

                    if (((CaloriasDias)lvFechas.SelectedItem) != null && c.dia == ((CaloriasDias)lvFechas.SelectedItem).dia)
                        formarTablaComidas();

                    Onhaybarra(true);

                    return;
                }
            }

            CaloriasDias diaElegido = new CaloriasDias();
            diaElegido.dia = fechaDia;
            if (comida == "Desayuno")
                diaElegido.desayuno = caloriasConsumidas;
            else if (comida == "Mediodía")
                diaElegido.mediodia = caloriasConsumidas;
            else if (comida == "Comida")
                diaElegido.comida = caloriasConsumidas;
            else if (comida == "Merienda")
                diaElegido.merienda = caloriasConsumidas;
            else if (comida == "Cena")
                diaElegido.cena = caloriasConsumidas;
            else
                diaElegido.otros = caloriasConsumidas;

            diaElegido.cadenaDia = cadena[0];
            diaElegido.totalCalorias += caloriasConsumidas;

            listaCalorias.Add(diaElegido);
            Onhaybarra(true);

            comBox.SelectedItem = null;
            calendario.SelectedDate = null;
            cajaCalorias.Text = null;
            if (((CaloriasDias)lvFechas.SelectedItem) != null && diaElegido.dia == ((CaloriasDias)lvFechas.SelectedItem).dia)
                formarTablaComidas();
        }

        //******************************************************************
        //*                   CARGAR LA LISTA DE COMIDAS                   *
        //******************************************************************
        private void formarTablaComidas()
        {
            listaComidas.Clear();
            lvComidas.ItemsSource = listaComidas;
            for (int i = 0; i < 6; i++)
            {
                TablaComidas com = new TablaComidas();
                if (i == 0)
                {
                    com.comidaSeleccionada = "DESAYUNO";
                    com.caloriasComidaSeleccionada = ((CaloriasDias)(lvFechas.SelectedItem)).desayuno;
                    listaComidas.Add(com);
                }
                else if (i == 1)
                {
                    com.comidaSeleccionada = "MEDIODÍA";
                    com.caloriasComidaSeleccionada = ((CaloriasDias)(lvFechas.SelectedItem)).mediodia;
                    listaComidas.Add(com);
                }
                else if (i == 2)
                {
                    com.comidaSeleccionada = "COMIDA";
                    com.caloriasComidaSeleccionada = ((CaloriasDias)(lvFechas.SelectedItem)).comida;
                    listaComidas.Add(com);
                }
                else if (i == 3)
                {
                    com.comidaSeleccionada = "MERIENDA";
                    com.caloriasComidaSeleccionada = ((CaloriasDias)(lvFechas.SelectedItem)).merienda;
                    listaComidas.Add(com);
                }
                else if (i == 4)
                {
                    com.comidaSeleccionada = "CENA";
                    com.caloriasComidaSeleccionada = ((CaloriasDias)(lvFechas.SelectedItem)).cena;
                    listaComidas.Add(com);
                }
                else
                {
                    com.comidaSeleccionada = "OTROS";
                    com.caloriasComidaSeleccionada = ((CaloriasDias)(lvFechas.SelectedItem)).otros;
                    listaComidas.Add(com);
                }
            }
        }

        //***********************************************************
        //*                   SELECCIÓN DE FECHAS                   *
        //***********************************************************
        private void lvFechas_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lvFechas.SelectedItem != null)
            {
                Onhayseleccion(((CaloriasDias)lvFechas.SelectedItem).dia);
                formarTablaComidas();
            }
            else
            {
                lvFechas.UnselectAll();
                listaComidas.Clear();
                Onhaybarra(true);
            }

        }

        //*****************************************************************
        //*                   REDIMENSIÓN DE LA VENTANA                   *
        //*****************************************************************
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ventana.ResizeMode = ResizeMode.NoResize;
        }
    }
}
