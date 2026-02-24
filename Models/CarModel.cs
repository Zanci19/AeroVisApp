using System.Collections.Generic;

namespace AeroVis.Models
{
    public class CarModel
    {
        public string Name { get; set; } = "";
        public string Team { get; set; } = "";
        public string Season { get; set; } = "";
        public string Constructor { get; set; } = "";
        public string Driver1 { get; set; } = "";
        public string Driver2 { get; set; } = "";
        public string Chassis { get; set; } = "";
        public string Engine { get; set; } = "";
        public string Transmission { get; set; } = "";
        public string Power { get; set; } = "";
        public string Fuel { get; set; } = "";
        public string Tyres { get; set; } = "";
        public string Weight { get; set; } = "";
        public string TopSpeed { get; set; } = "";
        public string Wheelbase { get; set; } = "";

        // Three views
        public string ImageSide  { get; set; } = "";
        public string ImageFront { get; set; } = "";
        public string ImageRear  { get; set; } = "";

        public string AccentHex       { get; set; } = "#FF6B00";
        public string SelectButtonHex { get; set; } = "#FF6B00";

        private static string Pack(string file)
            => $"pack://application:,,,/Resources/Cars/{file}";

        public static List<CarModel> DefaultCars() => new()
        {
            new CarModel
            {
                Name="Ferrari F2003-GA", Team="Scuderia Ferrari", Season="2003",
                Constructor="Scuderia Ferrari", Driver1="Michael Schumacher", Driver2="Rubens Barrichello",
                Chassis="F2003-GA carbon fibre/honeycomb composite",
                Engine="Ferrari Tipo 052  3.0 L V10",
                Transmission="7-speed Semi-automatic + reverse",
                Power="920–930 hp  @  18,600–19,000 rpm",
                Fuel="Shell V-Power", Tyres="13\" Bridgestone Potenza",
                Weight="600 kg", TopSpeed="360 km/h", Wheelbase="3,050 mm",
                ImageSide =Pack("ferrari_f2003_side.png"),
                ImageFront=Pack("ferrari_f2003_front.png"),
                ImageRear =Pack("ferrari_f2003_rear.png"),
                AccentHex="#CC0000", SelectButtonHex="#E81416"
            },
            new CarModel
            {
                Name="Ferrari F2004", Team="Scuderia Ferrari", Season="2004",
                Constructor="Scuderia Ferrari", Driver1="Michael Schumacher", Driver2="Rubens Barrichello",
                Chassis="F2004 carbon fibre/honeycomb composite",
                Engine="Ferrari Tipo 053  3.0 L V10",
                Transmission="7-speed Semi-automatic + reverse",
                Power="~900 hp  @  18,300 rpm",
                Fuel="Shell V-Power", Tyres="13\" Bridgestone Potenza",
                Weight="600 kg", TopSpeed="369 km/h", Wheelbase="3,095 mm",
                ImageSide =Pack("ferrari_f2003_side.png"),
                ImageFront=Pack("ferrari_f2003_front.png"),
                ImageRear =Pack("ferrari_f2003_rear.png"),
                AccentHex="#CC0000", SelectButtonHex="#E81416"
            },
            new CarModel
            {
                Name="Williams FW14B", Team="Williams Grand Prix Engineering", Season="1992",
                Constructor="Williams-Renault", Driver1="Nigel Mansell", Driver2="Riccardo Patrese",
                Chassis="FW14B carbon fibre monocoque",
                Engine="Renault RS3C/RS4  3.5 L V10",
                Transmission="6-speed Semi-automatic",
                Power="~770 hp  @  14,000 rpm",
                Fuel="Elf", Tyres="13\" Goodyear",
                Weight="505 kg", TopSpeed="320 km/h", Wheelbase="2,870 mm",
                ImageSide =Pack("williams_fw14b_side.png"),
                ImageFront=Pack("williams_fw14b_front.png"),
                ImageRear =Pack("williams_fw14b_rear.png"),
                AccentHex="#003E7E", SelectButtonHex="#003E7E"
            },
            new CarModel
            {
                Name="Ferrari F10", Team="Scuderia Ferrari", Season="2010",
                Constructor="Scuderia Ferrari", Driver1="Fernando Alonso", Driver2="Felipe Massa",
                Chassis="F10 carbon fibre/honeycomb composite",
                Engine="Ferrari Tipo 056  2.4 L V8",
                Transmission="7-speed Semi-automatic + reverse",
                Power="~750 hp  @  18,000 rpm",
                Fuel="Shell V-Power", Tyres="13\" Bridgestone Potenza",
                Weight="620 kg", TopSpeed="330 km/h", Wheelbase="3,130 mm",
                ImageSide =Pack("ferrari_f2003_side.png"),
                ImageFront=Pack("ferrari_f2003_front.png"),
                ImageRear =Pack("ferrari_f2003_rear.png"),
                AccentHex="#CC0000", SelectButtonHex="#E81416"
            },
            new CarModel
            {
                Name="Mercedes W11", Team="Mercedes-AMG Petronas F1 Team", Season="2020",
                Constructor="Mercedes-AMG", Driver1="Lewis Hamilton", Driver2="Valtteri Bottas",
                Chassis="W11 carbon fibre/honeycomb composite",
                Engine="Mercedes-AMG F1 M11 EQ  1.6 L V6 Hybrid Turbo",
                Transmission="8-speed Semi-automatic + reverse",
                Power="~1,000 hp combined",
                Fuel="Petronas Primax", Tyres="13\" Pirelli",
                Weight="746 kg", TopSpeed="372 km/h", Wheelbase="3,726 mm",
                ImageSide =Pack("mercedes_w11_side.png"),
                ImageFront=Pack("mercedes_w11_front.png"),
                ImageRear =Pack("mercedes_w11_rear.png"),
                AccentHex="#00D2BE", SelectButtonHex="#00A89C"
            },
            new CarModel
            {
                Name="McLaren MCL60", Team="McLaren F1 Team", Season="2023",
                Constructor="McLaren-Mercedes", Driver1="Lando Norris", Driver2="Oscar Piastri",
                Chassis="MCL60 carbon fibre monocoque",
                Engine="Mercedes-AMG F1 M14 EQ  1.6 L V6 Hybrid Turbo",
                Transmission="8-speed Semi-automatic + reverse",
                Power="~1,000 hp combined",
                Fuel="Gulf", Tyres="13\" Pirelli",
                Weight="798 kg", TopSpeed="340 km/h", Wheelbase="~3,600 mm",
                ImageSide =Pack("mclaren_mcl60_side.png"),
                ImageFront=Pack("mclaren_mcl60_front.png"),
                ImageRear =Pack("mclaren_mcl60_rear.png"),
                AccentHex="#FF8000", SelectButtonHex="#E07000"
            },
        };
    }
}
