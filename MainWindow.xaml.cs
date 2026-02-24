using System.Windows;
using System.Windows.Input;
using AeroVis.ViewModels;

namespace AeroVis
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _vm;
        private const double SpeedBarMaxPx = 178.0;

        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            DataContext = _vm;
            _vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(_vm.WindSpeedFraction))
                    SpeedBar.Width = _vm.WindSpeedFraction * SpeedBarMaxPx;
            };
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
        private void CloseBtn_Click(object sender, RoutedEventArgs e)    => Close();
        private void MinimizeBtn_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void MaximizeBtn_Click(object sender, RoutedEventArgs e) =>
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

        private void PrevCar_Click(object sender, RoutedEventArgs e) => _vm.NavigatePrev();
        private void NextCar_Click(object sender, RoutedEventArgs e) => _vm.NavigateNext();

        private void SelectCar_Click(object sender, RoutedEventArgs e)
        {
            var car = _vm.SelectedCar;
            if (car == null) return;
            var simWin = new SimulationWindow(car, _vm);
            simWin.Show();
        }

        // ► TO CONNECT DIAL: Replace body with SerialPort open/close.
        // In your read loop: App.Current.Dispatcher.Invoke(() => _vm.WindSpeed = value);
        private void ToggleConnect_Click(object sender, RoutedEventArgs e)
            => _vm.ToggleConnection();
    }
}
