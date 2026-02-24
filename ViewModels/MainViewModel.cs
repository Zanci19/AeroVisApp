using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using AeroVis.Models;

namespace AeroVis.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // ── Device ───────────────────────────────────────────────────────────
        private bool _isConnected = false;
        public bool IsConnected
        {
            get => _isConnected;
            set { _isConnected = value; OnPropertyChanged(); OnPropertyChanged(nameof(StatusText)); OnPropertyChanged(nameof(StatusBrush)); }
        }
        public string StatusText  => IsConnected ? "Connected" : "Disconnected";
        public Brush  StatusBrush => IsConnected
            ? new SolidColorBrush(Color.FromRgb(0, 200, 83))
            : new SolidColorBrush(Color.FromRgb(232, 20, 22));
        public string DeviceName     { get; } = "AeroVis 1:24 Scale Wind Tunnel";
        public string MaxModelLength { get; } = "24.00 cm";
        public string MaxModelWidth  { get; } = "12.00 cm";

        // ── Wind speed (km/h, max 400) ───────────────────────────────────────
        // TO CONNECT DIAL: Replace WindSpeed setter with your serial/USB read value.
        // The dial code just needs to call: viewModel.WindSpeed = valueFromDial;
        private double _windSpeed = 0;
        public double WindSpeed
        {
            get => _windSpeed;
            set
            {
                _windSpeed = System.Math.Clamp(value, 0, MaxWindSpeed);
                OnPropertyChanged();
                OnPropertyChanged(nameof(WindSpeedDisplay));
                OnPropertyChanged(nameof(NeedleAngle));
                OnPropertyChanged(nameof(WindSpeedFraction));
            }
        }
        public double MaxWindSpeed      { get; } = 400.0;
        public string WindSpeedDisplay  => $"{_windSpeed:F0}";
        public double WindSpeedFraction => _windSpeed / MaxWindSpeed;
        // -135° = 0 km/h,  +135° = 400 km/h
        public double NeedleAngle => -135.0 + (_windSpeed / MaxWindSpeed) * 270.0;

        // ── Cars ─────────────────────────────────────────────────────────────
        public ObservableCollection<CarModel> Cars { get; } = new();

        private int _selectedIndex = 0;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (value < 0 || value >= Cars.Count) return;
                _selectedIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedCar));
                OnPropertyChanged(nameof(SelectedIndexDisplay));
            }
        }
        public CarModel? SelectedCar         => Cars.Count > 0 ? Cars[_selectedIndex] : null;
        public string    SelectedIndexDisplay => $"{_selectedIndex + 1} / {Cars.Count}";

        // ── Navigation ───────────────────────────────────────────────────────
        public void NavigatePrev() => SelectedIndex = _selectedIndex > 0 ? _selectedIndex - 1 : Cars.Count - 1;
        public void NavigateNext() => SelectedIndex = _selectedIndex < Cars.Count - 1 ? _selectedIndex + 1 : 0;
        public void ToggleConnection() => IsConnected = !IsConnected;

        public MainViewModel()
        {
            foreach (var c in CarModel.DefaultCars()) Cars.Add(c);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
