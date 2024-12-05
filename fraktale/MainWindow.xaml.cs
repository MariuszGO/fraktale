using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace fraktale
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        if (int.TryParse(liczba_przebiegow.Text, out int iterations) && double.TryParse(wielkosc.Text, out double size))
            {
                DrawingCanvas.Children.Clear();
                Point top = new Point(DrawingCanvas.ActualWidth / 2, 10);
                Point left = new Point(top.X - size / 2, top.Y + Math.Sqrt(3) / 2 * size);
                Point right = new Point(top.X + size / 2, top.Y + Math.Sqrt(3) / 2 * size);

                Trojkat_Sierpinskiego(iterations, top, left, right);
            }
        else
            {
                MessageBox.Show("Błąd !!! Podaj poprawne wartości !!!");
            }
        }

        private void Trojkat_Sierpinskiego(int n, Point gora, Point lewa, Point prawa)
        {
        if (n == 0)
            {
                Polygon trojkat = new Polygon
                {
                    Points = new PointCollection { gora, lewa, prawa },
                    Fill = Brushes.LightBlue,
                    Stroke = Brushes.Black
                };
                DrawingCanvas.Children.Add(trojkat);
            }
        else
            {
                Point srodek_lewy = wspolrzedne_x_y(gora, lewa);
                Point srodek_prawy = wspolrzedne_x_y(gora, prawa);
                Point dol_srodek = wspolrzedne_x_y(lewa, prawa);

                Trojkat_Sierpinskiego(n - 1, gora, srodek_lewy, srodek_prawy);
                Trojkat_Sierpinskiego(n - 1, srodek_lewy, lewa, dol_srodek);
                Trojkat_Sierpinskiego(n - 1, srodek_prawy, dol_srodek, prawa);
            }
        }

        private Point wspolrzedne_x_y(Point p1, Point p2)
        {
        return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }
    }
}
