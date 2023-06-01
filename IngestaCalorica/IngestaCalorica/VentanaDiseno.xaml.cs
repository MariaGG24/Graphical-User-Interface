using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IngestaCalorica
{
    /// <summary>
    /// Lógica de interacción para VentanaDiseno.xaml
    /// </summary>
    /// 
    public class ColorEventArgs : EventArgs
    {
        public Brush color { get; set; }

        public ColorEventArgs(Brush b)
        {
            color = b;
        }
    }
    public partial class VentanaDiseno : Window
    {
        public event EventHandler<ColorEventArgs> haycolor;

        void Onhaycolor(Brush b)
        {
            if (haycolor != null)
                haycolor(this, new ColorEventArgs(b));
        }

        public VentanaDiseno()
        {
            InitializeComponent();
        }

        private void azul_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recAzul.Fill);
        }

        private void rojo_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recRojo.Fill);
        }

        private void verde_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recVerde.Fill);
        }

        private void marron_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recMarron.Fill);
        }

        private void azulClaro_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recAzulClaro.Fill);
        }

        private void blanco_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recBlanco.Fill);
        }

        private void azure_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recAzure.Fill);
        }

        private void beige_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recBeige.Fill);
        }

        private void negro_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recNegro.Fill);
        }

        private void lila_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recLila.Fill);
        }

        private void naranja_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recNaranja.Fill);
        }

        private void lima_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recLima.Fill);
        }

        private void azulMarino_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recAzulMarino.Fill);
        }

        private void violeta_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recVioleta.Fill);
        }

        private void azulRoyal_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recAzulRoyal.Fill);
        }

        private void rojoTomate_Click(object sender, RoutedEventArgs e)
        {
            Onhaycolor(recRojoTomate.Fill);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            diseno.ResizeMode = ResizeMode.NoResize;
        }
    }
}
