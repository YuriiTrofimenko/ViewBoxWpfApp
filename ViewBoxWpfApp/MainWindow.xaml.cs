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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ViewBoxWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void original_MouseMove(object sender, MouseEventArgs e)
        {
            Image image = (Image)sender;
            Point point = e.GetPosition(image);
            double x = point.X;
            double y = point.Y;
            double imageHeight = image.ActualHeight;
            double imageWidth = image.ActualWidth;
            double viewBoxHeight = imageHeight / 2;
            double viewBoxWidth = imageWidth / 2;
            double viewBoxX0 = x / imageWidth;
            double viewBoxY0 = y / imageHeight;
            if (x <= viewBoxWidth
                && y > viewBoxHeight)
            {
                ((VisualBrush)copy.Fill).Viewbox =
                new Rect(viewBoxX0, 0.5, 0.5, 0.5);
            }
            if (x > viewBoxWidth
                && y <= viewBoxHeight)
            {
                ((VisualBrush)copy.Fill).Viewbox =
                new Rect(0.5, viewBoxY0, 0.5, 0.5);
            }
            if (x <= viewBoxWidth
                && y <= viewBoxHeight)
            {
                ((VisualBrush)copy.Fill).Viewbox =
                new Rect(viewBoxX0, viewBoxY0, 0.5, 0.5);
            }
        }
    }
}
