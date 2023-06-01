using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;

namespace IngestaCalorica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        VentanaDiseno ventanaColor;
        TablaDatos ventanaDatos;
        Button botonTodo;
        DateTime fechaElegida;
        ObservableCollection<CaloriasDias> listaCalorias = new ObservableCollection<CaloriasDias>();
        ObservableCollection<TablaComidas> comidaSeleccionada = new ObservableCollection<TablaComidas>();

        public MainWindow()
        {
            InitializeComponent();
            paginaInicio();
            System.Windows.Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        //********************************************************
        //*                   PÁGINA DE INICIO                   *
        //********************************************************
        private void paginaInicio()
        {
            panel.Children.Clear();
            BitmapImage bi;
            ImageBrush br = new ImageBrush();

            bi = new BitmapImage(new Uri(@"pack://application:,,,/"
                                + Assembly.GetExecutingAssembly().GetName().Name +
                                ";component/icono.png", UriKind.Absolute));

            br.ImageSource = bi;

            ventana.Background = Brushes.Beige;

            Rectangle logo = new Rectangle();
            logo.Fill = br;
            logo.Width = 500;
            logo.Height = 300;
            Canvas.SetBottom(logo, 170);
            Canvas.SetLeft(logo, 250);

            Label et = new Label();
            et.Content = "La aplicación que necesitabas para controlar tus ingestas diarias";
            et.HorizontalAlignment = HorizontalAlignment.Center;
            et.VerticalAlignment = VerticalAlignment.Center;
            Canvas.SetBottom(et, 140);
            Canvas.SetLeft(et, 330);

            Button inicio = new Button();
            inicio.Content = "Entrar";
            inicio.HorizontalAlignment = HorizontalAlignment.Center;
            inicio.VerticalAlignment = VerticalAlignment.Center;
            inicio.Click += Inicio_Click;
            Canvas.SetBottom(inicio, 110);
            Canvas.SetLeft(inicio, 480);

            canvas.Children.Add(logo);
            canvas.Children.Add(et);
            canvas.Children.Add(inicio);
        }

        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            canvas.Background = Brushes.White;
            panel.Background = Brushes.White;
            addBarra();
        }

        //***********************************************************
        //*                    SALIDA POR EL MENÚ                   *
        //***********************************************************
        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = "¿Desea salir de la aplicación?";
            string titulo = "Salir";
            MessageBoxImage icono = MessageBoxImage.Question;
            MessageBoxButton botones = MessageBoxButton.YesNo;
            MessageBoxResult respuesta = System.Windows.MessageBox.Show(mensaje, titulo, botones, icono);

            switch (respuesta)
            {
                case MessageBoxResult.Yes:
                    ventana.Close();
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        //************************************************************
        //*                   DIBUJAR LOS GRÁFICOS                   *
        //************************************************************
        private void addBarra()
        {
            canvas.Children.Clear();
            panel.Children.Clear();
            panel.Children.Add(etiqueta);

            double y = 0;
            int distancia = 40;
            int max = 0;

            foreach(CaloriasDias c in listaCalorias)
            {
                if (c.totalCalorias > max)
                    max = c.totalCalorias;
            }

            for (int i = 0; i < listaCalorias.Count; i++)
            {
                if (listaCalorias[i].totalCalorias == 0)
                    listaCalorias.Remove(listaCalorias[i]);
                else
                {
                    if(listaCalorias[i].desayuno != 0)
                    {
                        Line d = new Line();
                        d.Stroke = Brushes.Lavender;
                        d.StrokeThickness = 20;
                        d.Margin = new Thickness(10);
                        d.X1 += distancia;
                        d.X2 += distancia;
                        d.Y1 = y;
                        d.Y2 = listaCalorias[i].desayuno * (canvas.ActualHeight - 50) / max;
                        d.ToolTip = "Desayuno: " + listaCalorias[i].desayuno.ToString();
                        Canvas.SetBottom(d, 30);
                        canvas.Children.Add(d);
                    }
                
                    if(listaCalorias[i].mediodia != 0)
                    {
                        Line md = new Line();
                        md.Stroke = Brushes.LightCoral;
                        md.StrokeThickness = 20;
                        md.Margin = new Thickness(10);
                        md.X1 += distancia;
                        md.X2 += distancia;
                        md.Y1 = y;
                        md.Y2 = listaCalorias[i].mediodia * (canvas.ActualHeight - 50) / max;
                        md.ToolTip = "Mediodía: " + listaCalorias[i].mediodia.ToString();
                        Canvas.SetBottom(md, 30 + listaCalorias[i].desayuno * (canvas.ActualHeight - 50) / max);
                        canvas.Children.Add(md);
                    }

                    if (listaCalorias[i].comida != 0)
                    {
                        Line co = new Line();
                        co.Stroke = Brushes.LightBlue;
                        co.StrokeThickness = 20;
                        co.Margin = new Thickness(10);
                        co.X1 += distancia;
                        co.X2 += distancia;
                        co.Y1 = y;
                        co.Y2 = listaCalorias[i].comida * (canvas.ActualHeight - 50) / max;
                        co.ToolTip = "Comida: " + listaCalorias[i].comida.ToString();
                        Canvas.SetBottom(co, 30 + (listaCalorias[i].desayuno + listaCalorias[i].mediodia) * (canvas.ActualHeight - 50) / max);
                        canvas.Children.Add(co);
                    }
                
                    if(listaCalorias[i].merienda != 0)
                    {
                        Line mr = new Line();
                        mr.Stroke = Brushes.Yellow;
                        mr.StrokeThickness = 20;
                        mr.Margin = new Thickness(10);
                        mr.X1 += distancia;
                        mr.X2 += distancia;
                        mr.Y1 = y;
                        mr.Y2 = listaCalorias[i].merienda * (canvas.ActualHeight - 50) / max;
                        mr.ToolTip = "Merienda: " + listaCalorias[i].merienda.ToString();
                        Canvas.SetBottom(mr, 30 + (listaCalorias[i].desayuno + listaCalorias[i].mediodia + listaCalorias[i].comida) * (canvas.ActualHeight - 50) / max);
                        canvas.Children.Add(mr);
                    }
                
                    if(listaCalorias[i].cena != 0)
                    {
                        Line ce = new Line();
                        ce.Stroke = Brushes.LightPink;
                        ce.StrokeThickness = 20;
                        ce.Margin = new Thickness(10);
                        ce.X1 += distancia;
                        ce.X2 += distancia;
                        ce.Y1 = y;
                        ce.Y2 = listaCalorias[i].cena * (canvas.ActualHeight - 50) / max;
                        ce.ToolTip = "Cena: " + listaCalorias[i].cena.ToString();
                        Canvas.SetBottom(ce, 30 + (listaCalorias[i].totalCalorias - listaCalorias[i].otros - listaCalorias[i].cena) * (canvas.ActualHeight - 50) / max);
                        canvas.Children.Add(ce);
                    }
                
                    if(listaCalorias[i].otros != 0)
                    {
                        Line o = new Line();
                        o.Stroke = Brushes.LightGreen;
                        o.StrokeThickness = 20;
                        o.Margin = new Thickness(10);
                        o.X1 += distancia;
                        o.X2 += distancia;
                        o.Y1 = y;
                        o.Y2 = listaCalorias[i].otros * (canvas.ActualHeight - 50) / max;
                        o.ToolTip = "Otros: " + listaCalorias[i].otros.ToString();
                        Canvas.SetBottom(o, 30 + (listaCalorias[i].totalCalorias - listaCalorias[i].otros) * (canvas.ActualHeight - 50) / max);
                        canvas.Children.Add(o);
                    }
                
                    Label f = new Label();
                    f.Content = ($"{listaCalorias[i].cadenaDia}");
                    f.Margin = new Thickness(10);
                    f.FontSize = 7;
                    f.ToolTip = "Calorías totales: " + listaCalorias[i].totalCalorias.ToString();
                    f.Background = Brushes.White;
                    Canvas.SetLeft(f, distancia - 25);
                    Canvas.SetBottom(f, 0);
                    canvas.Children.Add(f);

                    distancia += 40;
                    if (i == 22) 
                        break;
                }
            }
        }

        private void dibujarDiaDeterminado(DateTime fecha)
        {
            colocarEtiquetas();

            CaloriasDias diaElegido = new CaloriasDias();
            int max = 0;
            foreach(CaloriasDias c in listaCalorias)
            {
                if(c.dia == fecha)
                {
                    Label dia = new Label();
                    dia.Content = "Datos del día: \n" + c.cadenaDia;
                    dia.Background = Brushes.White;
                    Canvas.SetBottom(dia, canvas.ActualHeight / 2);
                    Canvas.SetLeft(dia, 20);
                    canvas.Children.Add(dia);

                    diaElegido.desayuno = c.desayuno;
                    if (max < diaElegido.desayuno)
                        max = diaElegido.desayuno;

                    diaElegido.mediodia = c.mediodia;
                    if (max < diaElegido.mediodia)
                        max = diaElegido.mediodia;

                    diaElegido.comida = c.comida;
                    if (max < diaElegido.comida)
                        max = diaElegido.comida;

                    diaElegido.merienda = c.merienda;
                    if (max < diaElegido.merienda)
                        max = diaElegido.merienda;

                    diaElegido.cena = c.cena;
                    if (max < diaElegido.cena)
                        max = diaElegido.cena;

                    diaElegido.otros = c.otros;
                    if (max < diaElegido.otros)
                        max = diaElegido.otros;
                    break;
                }
            }

            if(diaElegido.desayuno != 0)
                crearBarra(max, diaElegido.desayuno, 151, Brushes.Lavender);
            if (diaElegido.mediodia != 0)
                crearBarra(max, diaElegido.mediodia, 266, Brushes. LightCoral);
            if (diaElegido.comida != 0)
                crearBarra(max, diaElegido.comida, 370, Brushes.LightBlue);
            if (diaElegido.merienda != 0)
                crearBarra(max, diaElegido.merienda, 492, Brushes.Yellow);
            if (diaElegido.cena != 0)
                crearBarra(max, diaElegido.cena, 590, Brushes.LightPink);
            if (diaElegido.otros != 0)
                crearBarra(max, diaElegido.otros, 690, Brushes.LightGreen);
        }

        private void crearBarra(int max, int cal, int coordX, Brush color)
        {
            Rectangle barra = new Rectangle();
            barra.Fill = color;
            barra.Width = 40;

            if (cal == max)
                barra.Height = canvas.ActualHeight - 50;
            else
                barra.Height = cal * (canvas.ActualHeight - 50) / max;

            Canvas.SetBottom(barra, 40);
            Canvas.SetLeft(barra, coordX);
            barra.ToolTip = "Calorías: " + cal.ToString();
            canvas.Children.Add(barra);
        }

        private void colocarEtiquetas()
        {
            Label et1 = new Label();
            et1.Content = "DESAYUNO";
            et1.HorizontalAlignment = HorizontalAlignment.Center;
            et1.Margin = new Thickness(10);
            et1.Background = Brushes.White;
            Canvas.SetLeft(et1, 125);
            Canvas.SetBottom(et1, 0);
            canvas.Children.Add(et1);

            Label et2 = new Label();
            et2.Content = "MEDIODÍA";
            et2.HorizontalAlignment = HorizontalAlignment.Center;
            et2.Margin = new Thickness(10);
            et2.Background = Brushes.White;
            Canvas.SetLeft(et2, 240);
            Canvas.SetBottom(et2, 0);
            canvas.Children.Add(et2);

            Label et3 = new Label();
            et3.Content = "COMIDA";
            et3.HorizontalAlignment = HorizontalAlignment.Center;
            et3.Margin = new Thickness(10);
            et3.Background = Brushes.White;
            Canvas.SetLeft(et3, 354);
            Canvas.SetBottom(et3, 0);
            canvas.Children.Add(et3);

            Label et4 = new Label();
            et4.Content = "MERIENDA";
            et4.HorizontalAlignment = HorizontalAlignment.Center;
            et4.Margin = new Thickness(10);
            et4.Background = Brushes.White;
            Canvas.SetLeft(et4, 468);
            Canvas.SetBottom(et4, 0);
            canvas.Children.Add(et4);

            Label et5 = new Label();
            et5.Content = "CENA";
            et5.HorizontalAlignment = HorizontalAlignment.Center;
            et5.Margin = new Thickness(10);
            et5.Background = Brushes.White;
            Canvas.SetLeft(et5, 582);
            Canvas.SetBottom(et5, 0);
            canvas.Children.Add(et5);

            Label et6 = new Label();
            et6.Content = "OTROS";
            et6.HorizontalAlignment = HorizontalAlignment.Center;
            et6.Margin = new Thickness(10);
            et6.Background = Brushes.White;
            Canvas.SetLeft(et6, 676);
            Canvas.SetBottom(et6, 0);
            canvas.Children.Add(et6);
        }

        private void MostrarTabla_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaDatos != null) return;
            ventanaDatos = new TablaDatos(listaCalorias, comidaSeleccionada);
            ventanaDatos.hayseleccion += VentanaDatos_hayseleccion;
            ventanaDatos.haybarra += VentanaDatos_haybarra;
            ventanaDatos.Closed += VentanaDatos_Closed;
            ventanaDatos.Show();
        }

        private void VentanaDatos_haybarra(object sender, BarrasEventArgs e)
        {
            if (e.dibujo == true)
            {
                botonTodo = null;
                addBarra();
            }
        }

        private void VentanaDatos_hayseleccion(object sender, TablaEventArgs e)
        {
            fechaElegida = e.fecha;
            if(botonTodo == null)
            {
                botonTodo = new Button();
                botonTodo.Content = "Ver Todo";
                botonTodo.Width = 950;
                botonTodo.Margin = new Thickness(10);
                botonTodo.HorizontalAlignment = HorizontalAlignment.Center;
                botonTodo.Click += BotonTodo_Click;
                panel.Children.Remove(etiqueta);
                panel.Children.Add(botonTodo);
            }
            canvas.Children.Clear();
            dibujarDiaDeterminado(e.fecha);
        }

        private void VentanaDatos_Closed(object sender, System.EventArgs e)
        {
            ventanaDatos = null;
        }

        private void BotonTodo_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Add(etiqueta);
            panel.Children.Remove(botonTodo);
            botonTodo = null;
            canvas.Children.Clear();
            addBarra();
        }
        
        private void MostrarMedias_Click(object sender, RoutedEventArgs e)
        {
            
            if (botonTodo == null)
            {
                panel.Children.Clear();
                botonTodo = new Button();
                botonTodo.Content = "Ver Todo";
                botonTodo.Width = 950;
                botonTodo.Margin = new Thickness(10);
                botonTodo.HorizontalAlignment = HorizontalAlignment.Center;
                botonTodo.Click += BotonTodo_Click;
                panel.Children.Add(botonTodo);
            }
            canvas.Children.Clear();
            Rectangle mediaRecomendada = new Rectangle();
            Rectangle mediaMujeres = new Rectangle();
            Rectangle mediaHombres = new Rectangle();
            int max = 0, media = 0, i = 0;

            foreach (CaloriasDias c in listaCalorias)
            {
                if (max < c.totalCalorias / 5)
                    max = c.totalCalorias / 5;
            }
            if (max < 1800)
                max = 1800;
            mediaRecomendada.Stroke = Brushes.Black;
            mediaRecomendada.StrokeThickness = 3;
            mediaRecomendada.Width = (int)canvas.ActualWidth;
            mediaRecomendada.Height = 5;
            Canvas.SetBottom(mediaRecomendada, 1600 * ((int)canvas.ActualHeight - 50) / max);
            mediaRecomendada.ToolTip = "Calorías recomendadas por día: 1600";
            canvas.Children.Add(mediaRecomendada);

            mediaMujeres.Stroke = Brushes.Pink;
            mediaMujeres.StrokeThickness = 3;
            mediaMujeres.Width = (int)canvas.ActualWidth;
            mediaMujeres.Height = 5;
            Canvas.SetBottom(mediaMujeres, 1400 * ((int)canvas.ActualHeight - 50) / max);
            mediaMujeres.ToolTip = "Calorías recomendadas por día para mujeres: 1400";
            canvas.Children.Add(mediaMujeres);

            mediaHombres.Stroke = Brushes.Blue;
            mediaHombres.StrokeThickness = 3;
            mediaHombres.Width = (int)canvas.ActualWidth;
            mediaHombres.Height = 5;
            Canvas.SetBottom(mediaHombres, 1800 * ((int)canvas.ActualHeight - 50) / max);
            mediaHombres.ToolTip = "Calorías recomendadas por día para hombres: 1800";
            canvas.Children.Add(mediaHombres);

            foreach (CaloriasDias c in listaCalorias)
            {
                media = c.totalCalorias / 5;
                Ellipse punto = new Ellipse();
                punto.Width = 10;
                punto.Height = 10;
                punto.Stroke = Brushes.Black;
                punto.Fill = Brushes.Black;
                punto.ToolTip = media.ToString() + " calorías (de media) consumidas el día " + c.cadenaDia;
                Canvas.SetBottom(punto, media * ((int)canvas.ActualHeight - 50) / max);
                Canvas.SetLeft(punto, 50 + (((int)canvas.ActualWidth - 50)/listaCalorias.Count)*i);
                canvas.Children.Add(punto);
                i++;
            }
        }
        //******************************************************
        //*                   CAMBIAR DISEÑO                   *
        //******************************************************
        private void CambiarDiseno_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaColor != null) return;
            ventanaColor = new VentanaDiseno();

            ventanaColor.haycolor += VentanaColor_haycolor;
            ventanaColor.Closed += VentanaColor_Closed;
            ventanaColor.Show();
        }

        private void VentanaColor_Closed(object sender, System.EventArgs e)
        {
            ventanaColor = null;
        }

        private void VentanaColor_haycolor(object sender, ColorEventArgs e)
        {
            canvas.Background = e.color;
            panel.Background = e.color;
        }

        //***********************************************************
        //*                   EXPORTAR EL GRÁFICO                   *
        //***********************************************************
        private void ExportarGrafico_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                FileName = "Gráfico",
                Filter = "JPeg Image | *.jpg | Bitmap Image | *bmp | PNG | *.png | GIF Image | *.gif"
            };

            bool? resp = dlg.ShowDialog();
            if (resp == true)
            {
                guardarImagen(dlg.FileName);
            }
        }

        private void guardarImagen(string fileName)
        {
            PngBitmapEncoder encoder = new PngBitmapEncoder();

            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight, 80, 80, PixelFormats.Pbgra32);

            bitmap.Render(canvas);
            BitmapFrame frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);

            using (var stream = File.Create(fileName))
            {
                encoder.Save(stream);
            }
        }

        //*****************************************************************
        //*                   REDIMENSIÓN DE LA VENTANA                   *
        //*****************************************************************
        private void ventana_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ventana.ResizeMode = ResizeMode.NoResize;
        }

    }
}
