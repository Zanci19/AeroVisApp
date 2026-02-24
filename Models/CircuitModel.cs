using System.Collections.Generic;

namespace AeroVis.Models
{
    public class CircuitModel
    {
        public string Name        { get; set; } = "";
        public string Country     { get; set; } = "";
        public string City        { get; set; } = "";
        public string ImagePath   { get; set; } = "";
        public double LengthKm    { get; set; }
        public int    Corners     { get; set; }
        public string LapRecord   { get; set; } = "";
        public string RecordHolder{ get; set; } = "";

        // Which car model names raced here (matched against CarModel.Name)
        public List<string> CompatibleCars { get; set; } = new();

        private static string Pack(string f)
            => $"pack://application:,,,/Resources/Circuits/{f}";

        public static List<CircuitModel> AllCircuits() => new()
        {
            // ── 2003 & 2004 circuits (Ferrari F2003-GA and F2004) ─────────────
            new CircuitModel { Name="Melbourne Grand Prix Circuit", Country="Australia", City="Melbourne",
                ImagePath=Pack("melbourne.png"), LengthKm=5.303, Corners=16, LapRecord="1:24.125", RecordHolder="M. Schumacher (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Sepang International Circuit", Country="Malaysia", City="Kuala Lumpur",
                ImagePath=Pack("sepang.png"), LengthKm=5.543, Corners=15, LapRecord="1:34.223", RecordHolder="J. Button (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Bahrain International Circuit", Country="Bahrain", City="Sakhir",
                ImagePath=Pack("bahrain.png"), LengthKm=5.412, Corners=15, LapRecord="1:31.447", RecordHolder="P. De La Rosa (2005)",
                CompatibleCars=new(){"Ferrari F2004","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Imola — San Marino GP", Country="Italy", City="Imola",
                ImagePath=Pack("imola.png"), LengthKm=4.909, Corners=19, LapRecord="1:20.411", RecordHolder="M. Schumacher (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B"}},

            new CircuitModel { Name="Circuit de Barcelona-Catalunya", Country="Spain", City="Barcelona",
                ImagePath=Pack("catalunya.png"), LengthKm=4.655, Corners=16, LapRecord="1:16.330", RecordHolder="K. Räikkönen (2008)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Monaco Circuit", Country="Monaco", City="Monte Carlo",
                ImagePath=Pack("monaco.png"), LengthKm=3.337, Corners=19, LapRecord="1:12.909", RecordHolder="R. Barrichello (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Nürburgring", Country="Germany", City="Nürburg",
                ImagePath=Pack("nurburgring.png"), LengthKm=5.148, Corners=15, LapRecord="1:29.468", RecordHolder="M. Schumacher (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10"}},

            new CircuitModel { Name="Circuit de Spa-Francorchamps", Country="Belgium", City="Spa",
                ImagePath=Pack("spa.png"), LengthKm=7.004, Corners=20, LapRecord="1:46.286", RecordHolder="V. Bottas (2018)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Silverstone Circuit", Country="United Kingdom", City="Silverstone",
                ImagePath=Pack("silverstone.png"), LengthKm=5.891, Corners=18, LapRecord="1:27.097", RecordHolder="M. Schumacher (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Hungaroring", Country="Hungary", City="Budapest",
                ImagePath=Pack("hungaroring.png"), LengthKm=4.381, Corners=14, LapRecord="1:16.627", RecordHolder="M. Schumacher (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Monza — Italian GP", Country="Italy", City="Monza",
                ImagePath=Pack("monza.png"), LengthKm=5.793, Corners=11, LapRecord="1:21.046", RecordHolder="R. Barrichello (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Circuit de la Sarthe (Indianapolis)", Country="USA", City="Indianapolis",
                ImagePath=Pack("indianapolis.png"), LengthKm=4.192, Corners=13, LapRecord="1:10.399", RecordHolder="R. Barrichello (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B"}},

            new CircuitModel { Name="Suzuka Circuit", Country="Japan", City="Suzuka",
                ImagePath=Pack("suzuka.png"), LengthKm=5.807, Corners=18, LapRecord="1:31.540", RecordHolder="R. Barrichello (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Shanghai International Circuit", Country="China", City="Shanghai",
                ImagePath=Pack("shanghai.png"), LengthKm=5.451, Corners=16, LapRecord="1:32.238", RecordHolder="M. Schumacher (2004)",
                CompatibleCars=new(){"Ferrari F2004","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Marina Bay Street Circuit", Country="Singapore", City="Singapore",
                ImagePath=Pack("singapore.png"), LengthKm=5.065, Corners=23, LapRecord="1:41.905", RecordHolder="K. Räikkönen (2018)",
                CompatibleCars=new(){"Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Interlagos — Brazilian GP", Country="Brazil", City="São Paulo",
                ImagePath=Pack("interlagos.png"), LengthKm=4.309, Corners=15, LapRecord="1:10.540", RecordHolder="R. Barrichello (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10","Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Baku City Circuit", Country="Azerbaijan", City="Baku",
                ImagePath=Pack("baku.png"), LengthKm=6.003, Corners=20, LapRecord="1:43.009", RecordHolder="C. Leclerc (2019)",
                CompatibleCars=new(){"Mercedes W11","McLaren MCL60"}},

            new CircuitModel { Name="Malaysia — Kuala Lumpur GP", Country="Malaysia", City="KL",
                ImagePath=Pack("malaysia.png"), LengthKm=5.543, Corners=15, LapRecord="1:34.223", RecordHolder="J. Button (2004)",
                CompatibleCars=new(){"Ferrari F2003-GA","Ferrari F2004","Williams FW14B","Ferrari F10"}},
        };
    }
}
