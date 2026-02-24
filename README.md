# AeroVis — 1:24 Aerodynamics Simulation App
## Full Setup, Build & Run Guide

---

## 📁 Project Structure

```
AeroVisApp/
└── AeroVis/
    ├── AeroVis.csproj
    ├── App.xaml / App.xaml.cs
    ├── MainWindow.xaml / MainWindow.xaml.cs
    ├── Models/
    │   └── CarModel.cs          ← Add cars here
    ├── ViewModels/
    │   └── MainViewModel.cs
    ├── Converters/
    │   ├── HexToBrushConverter.cs
    │   └── BoolToVisibilityConverter.cs
    └── Resources/
        ├── windtunnel.png        ← PUT YOUR WIND TUNNEL PHOTO HERE
        └── Cars/
            ├── ferrari_f2003.png ← PUT CAR IMAGES HERE
            └── (more cars...)
```

---

## ✅ Prerequisites

1. **Windows 10 or 11** (required — WPF is Windows-only)
2. **Install .NET 8 SDK**
   - Go to: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
   - Download: **.NET 8.0 SDK** (not Runtime, the full SDK)
   - Install it (just click through the installer)
   - Verify: open Command Prompt and type:
     ```
     dotnet --version
     ```
     You should see something like `8.0.xxx`

---

## 🖼️ Add Your Images

### Wind Tunnel Image
1. Take a photo of your AeroVis wind tunnel device
2. Save it as: `Resources/windtunnel.png`
   (replace the placeholder file in that folder)
3. Any size is fine — the app will scale it automatically

### Ferrari F2003 Car Image
1. Find or save a PNG/JPG of the Ferrari F2003 with a transparent or dark background
2. Save it as: `Resources/Cars/ferrari_f2003.png`
3. Recommended: transparent background PNG, landscape orientation

### Adding More Cars (Later)
When you tell me which cars to add, I'll give you the exact `CarModel` entry.
You'll just add the image to `Resources/Cars/` and add the entry to `CarModel.cs`.

---

## 🔨 Build & Run

### Method 1: Command Line (easiest)
```
# Open Command Prompt or PowerShell
# Navigate to the project folder:
cd C:\path\to\AeroVisApp\AeroVis

# Run directly (builds automatically):
dotnet run

# OR build an .exe:
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```
The .exe will appear in:
`AeroVis\bin\Release\net8.0-windows\win-x64\publish\AeroVis.exe`

### Method 2: Visual Studio (recommended for development)
1. Download **Visual Studio Community 2022** (free): https://visualstudio.microsoft.com/
2. During install, check: **".NET desktop development"** workload
3. Open Visual Studio → **Open a project or solution**
4. Navigate to `AeroVisApp/AeroVis/AeroVis.csproj` and open it
5. Press **F5** to run, or **Ctrl+Shift+B** to build
6. To make an .exe: right-click the project → **Publish** → Folder → Publish

### Method 3: VS Code
1. Install **VS Code**: https://code.visualstudio.com/
2. Install extension: **C# Dev Kit**
3. Open the `AeroVisApp` folder
4. Open terminal: `dotnet run`

---

## 🎨 App Features

| Area | What it does |
|---|---|
| **Left sidebar** | Shows your wind tunnel device info + connection status |
| **Connect button** | Simulates connecting/disconnecting the device |
| **Centre** | Car slideshow — use ‹ › arrows to browse cars |
| **Right panel** | Technical specs for the currently shown car |
| **SELECT MODEL** | Confirms which car you're simulating |
| **Title bar** | Drag to move, minimize/maximize/close buttons |

---

## 🚗 Adding More Cars

Open `Models/CarModel.cs` and add entries to the `DefaultCars()` list.

**Template:**
```csharp
new CarModel
{
    Name         = "McLaren MP4/4",
    Team         = "McLaren Honda",
    Season       = "1988",
    Constructor  = "McLaren",
    Driver1      = "Ayrton Senna",
    Driver2      = "Alain Prost",
    Chassis      = "MP4/4",
    Engine       = "Honda RA168E 1.5 L V6 Turbo",
    Transmission = "6-speed Semi-automatic",
    Power        = "680–685 hp",
    Fuel         = "Shell",
    Tyres        = "13\" Goodyear",
    ImagePath    = "pack://application:,,,/Resources/Cars/mclaren_mp44.png",
    AccentHex    = "#FF8000",      // team colour
    SelectButtonHex = "#FF8000"   // button colour when this car is shown
},
```

And add the image to `Resources/Cars/mclaren_mp44.png`.

---

## 🔧 Colour Customisation

Each car has its own colours via `AccentHex` and `SelectButtonHex`:
- **Ferrari** → Red (`#E81416`)
- **McLaren** → Orange (`#FF8000`)
- **Williams** → Blue (`#003087`)
- **Mercedes** → Silver/Teal (`#00D2BE`)
- etc.

The card border, season badge, and SELECT button all change automatically.

---

## ❓ Troubleshooting

| Problem | Fix |
|---|---|
| `dotnet` not recognised | Install .NET 8 SDK and restart terminal |
| Image not showing | Check file is in `Resources/Cars/` and filename matches exactly |
| App won't start | Make sure you're on Windows — WPF doesn't run on Mac/Linux |
| Build errors | Run `dotnet restore` first, then `dotnet build` |
