using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WiazanieDanychCwiczenia
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double _rozmiar;
        private string _tekst;
        private Brush _kolor;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

           
            Rozmiar = 12;
            Kolor = Brushes.Black;
            Tekst = "Kolejny test wiązania danych";
        }

        public double Rozmiar
        {
            get => _rozmiar;
            set
            {
                _rozmiar = value;
                OnPropertyChanged(nameof(Rozmiar));
            }
        }

        public string Tekst
        {
            get => _tekst;
            set
            {
                _tekst = value;
                OnPropertyChanged(nameof(Tekst));
            }
        }

        public Brush Kolor
        {
            get => _kolor;
            set
            {
                _kolor = value;
                OnPropertyChanged(nameof(Kolor));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        private void ComboKolor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboKolor.SelectedItem is ComboBoxItem selectedItem)
            {
                
                string colorName = selectedItem.Content.ToString();

                
                Kolor = (Brush)new BrushConverter().ConvertFromString(colorName);
            }
        }
    }
}
