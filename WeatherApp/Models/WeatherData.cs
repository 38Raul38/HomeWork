using System;

namespace WeatherApp.Models
{
    public class WeatherData
    {
        public string CityName { get; set; } = "";
        public DateTime LastUpdated { get; set; }
        
        public Coord Coordinates { get; set; } = new Coord();
        public Weather[] WeatherConditions { get; set; } = Array.Empty<Weather>();
        public Main MainInfo { get; set; } = new Main();
        public Wind WindInfo { get; set; } = new Wind();

        public string FormattedTemperature => $"{MainInfo.Temperature:F1}°C";
        public string FormattedFeelsLike => $"{MainInfo.FeelsLike:F1}°C";
        public string FormattedHumidity => $"{MainInfo.Humidity}%";
        public string FormattedWindSpeed => $"{WindInfo.Speed:F1} m/s";
        public string FormattedLastUpdated => LastUpdated.ToString("HH:mm:ss");

        public class Coord
        {
            public double Longitude { get; set; }
            public double Latitude { get; set; }
        }
        
        public class Weather
        {
            public string Main { get; set; } = "";
            public string Description { get; set; } = "";
            public string Icon { get; set; } = "";
        }
        
        public class Main
        {
            public double Temperature { get; set; }
            public double FeelsLike { get; set; }
            public double TempMin { get; set; }
            public double TempMax { get; set; }
            public int Pressure { get; set; }
            public int Humidity { get; set; }
        }
        
        public class Wind
        {
            public double Speed { get; set; }
        }
    }
} 