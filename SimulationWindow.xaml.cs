using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AeroVis.Models;
using AeroVis.ViewModels;

namespace AeroVis
{
    public partial class SimulationWindow : Window
    {
        private readonly CarModel _car;
        private readonly MainViewModel _vm;
        private List<CircuitModel> _circuits = new();
        private int _circuitIndex = 0;
        private CircuitModel? _confirmedCircuit = null;

        public SimulationWindow(CarModel car, MainViewModel vm)
        {
            InitializeComponent();
            _car = car;
            _vm = vm;

            // Wire wind speed updates from the shared VM
            _vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(_vm.NeedleAngle))
                {
                    SimNeedleRotate.Angle = _vm.NeedleAngle;
                    SimSpeedText.Text     = _vm.WindSpeedDisplay;
                }
            };

            LoadCar();
            LoadCompatibleCircuits();
        }

        private void LoadCar()
        {
            SimCarName.Text = _car.Name;
            try
            {
                var sideUri = new System.Uri(_car.ImageSide,
                    _car.ImageSide.StartsWith("http") ? System.UriKind.Absolute : System.UriKind.RelativeOrAbsolute);
                SimCarImage.Source = new BitmapImage(sideUri);
                var rearUri = new System.Uri(_car.ImageRear,
                    _car.ImageRear.StartsWith("http") ? System.UriKind.Absolute : System.UriKind.RelativeOrAbsolute);
                SimCarRearImage.Source = new BitmapImage(rearUri);
            }
            catch { }

            SimRaceInfo.Text = $"{_car.Constructor}  ·  Season {_car.Season}  ·  {_car.Driver1} / {_car.Driver2}\n" +
                               $"Engine: {_car.Engine}  ·  Power: {_car.Power}";
        }

        private void LoadCompatibleCircuits()
        {
            _circuits = CircuitModel.AllCircuits()
                .Where(c => c.CompatibleCars.Contains(_car.Name))
                .ToList();

            CircuitCompatLabel.Text = $"compatible with {_car.Name} ({_circuits.Count})";
            CircuitDots.ItemsSource = _circuits;
            _circuitIndex = 0;
            ShowCircuit();
        }

        private void ShowCircuit()
        {
            if (_circuits.Count == 0)
            {
                CircuitNameText.Text    = "No compatible circuits found";
                CircuitCountryText.Text = "";
                CircuitLengthText.Text  = "";
                CircuitRecordText.Text  = "";
                CircuitIndexText.Text   = "0 / 0";
                return;
            }

            var c = _circuits[_circuitIndex];
            CircuitNameText.Text    = c.Name;
            CircuitCountryText.Text = $"{c.Country}";
            CircuitLengthText.Text  = $"{c.LengthKm:F3} km  ·  {c.Corners} corners";
            CircuitRecordText.Text  = $"Lap record: {c.LapRecord} — {c.RecordHolder}";
            CircuitIndexText.Text   = $"{_circuitIndex + 1} / {_circuits.Count}";

            try
            {
                var uri = new System.Uri(c.ImagePath, System.UriKind.RelativeOrAbsolute);
                CircuitImage.Source = new BitmapImage(uri);
            }
            catch { CircuitImage.Source = null; }

            // Reset confirm highlight
            CircuitSelectedBorder.Visibility = Visibility.Collapsed;
        }

        private void PrevCircuit_Click(object sender, RoutedEventArgs e)
        {
            if (_circuits.Count == 0) return;
            _circuitIndex = _circuitIndex > 0 ? _circuitIndex - 1 : _circuits.Count - 1;
            ShowCircuit();
        }
        private void NextCircuit_Click(object sender, RoutedEventArgs e)
        {
            if (_circuits.Count == 0) return;
            _circuitIndex = _circuitIndex < _circuits.Count - 1 ? _circuitIndex + 1 : 0;
            ShowCircuit();
        }

        private void ConfirmCircuit_Click(object sender, RoutedEventArgs e)
        {
            if (_circuits.Count == 0) return;
            _confirmedCircuit = _circuits[_circuitIndex];
            CircuitSelectedBorder.Visibility = Visibility.Visible;

            // Update race info
            SimCircuitLabel.Text = _confirmedCircuit.Name;
            SimRaceInfo.Text = $"{_car.Constructor}  ·  {_car.Season}  ·  {_car.Driver1} / {_car.Driver2}\n" +
                               $"{_confirmedCircuit.Country}  ·  {_confirmedCircuit.LengthKm:F3} km  ·  {_confirmedCircuit.Corners} corners\n" +
                               $"Lap record: {_confirmedCircuit.LapRecord} by {_confirmedCircuit.RecordHolder}\n" +
                               $"Engine: {_car.Engine}  ·  Power: {_car.Power}";

            // Populate the confirmed circuit panel
            ConfirmedCircuitHeaderLabel.Text = _confirmedCircuit.Name;
            ConfirmedCircuitName.Text    = _confirmedCircuit.Name;
            ConfirmedCircuitCountry.Text = _confirmedCircuit.Country;
            ConfirmedCircuitLength.Text  = $"{_confirmedCircuit.LengthKm:F3} km  ·  {_confirmedCircuit.Corners} corners";
            ConfirmedCircuitRecord.Text  = $"Lap record: {_confirmedCircuit.LapRecord} — {_confirmedCircuit.RecordHolder}";
            try
            {
                var uri = new System.Uri(_confirmedCircuit.ImagePath, System.UriKind.RelativeOrAbsolute);
                ConfirmedCircuitImage.Source = new BitmapImage(uri);
            }
            catch { ConfirmedCircuitImage.Source = null; }

            // ► WIND TUNNEL COMMAND:
            // Here you can send target speed to your wind tunnel hardware.
            // Example: SerialPort.WriteLine($"SPEED:{targetKmh}");

            // Switch to simulation mode: hide the circuit selector, show confirmed view
            CircuitSelectorPanel.Visibility  = Visibility.Collapsed;
            CircuitConfirmedPanel.Visibility = Visibility.Visible;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
        private void CloseBtn_Click(object sender, RoutedEventArgs e)    => Close();
        private void MinimizeBtn_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void MaximizeBtn_Click(object sender, RoutedEventArgs e) =>
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }
}
