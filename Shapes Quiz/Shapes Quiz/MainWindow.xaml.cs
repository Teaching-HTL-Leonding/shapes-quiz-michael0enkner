using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Shapes_Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Shape> Shapes { get; } = new();
        public MainWindow()
        {
            InitializeComponent();
            Shapes.Clear();
            DataContext = this;
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            string selected = comboBox.Text;

            if (selected == "Circle")
            {
                if (double.TryParse(textBoxRadius.Text, out double r) && string.IsNullOrEmpty(textBoxSideA.Text) && string.IsNullOrEmpty(textBoxHeight.Text) && string.IsNullOrEmpty(textBoxSideB.Text))
                {
                    Shapes.Add(new Shape() { Name = "Circle", Radius = r, Area = Math.Round(Math.PI * Math.Pow(r, 2), 2) });
                }
            }
            else if (selected == "Rectangle")
            {
                if (double.TryParse(textBoxSideA.Text, out double a) && double.TryParse(textBoxSideB.Text, out double b) && string.IsNullOrEmpty(textBoxHeight.Text) && string.IsNullOrEmpty(textBoxRadius.Text))
                {
                    Shapes.Add(new Shape() { Name = "Rectangle", SideA = a, SideB = b, Area = Math.Round(a * b, 2) });
                }
            }
            else if (selected == "Triangle")
            {
                if (double.TryParse(textBoxSideA.Text, out double a) && double.TryParse(textBoxHeight.Text, out double h) && string.IsNullOrEmpty(textBoxSideB.Text) && string.IsNullOrEmpty(textBoxRadius.Text))
                {
                    Shapes.Add(new Shape() { Name = "Triangle", SideA = a, Height = h, Area = Math.Round((a * h) / 2, 2) });
                }
            }

            double sumOfAreas = 0;
            foreach (var shape in Shapes)
            {
                sumOfAreas += shape.Area;
            }
            textBlockArea.Text = Convert.ToString(sumOfAreas);
        }
    }
}