using System;

namespace WeatherApp.Models
{
    public class WeatherSearchResult
    {
        public Coord coord { get; set; } = new Coord();
        public Weather[] weather { get; set; } = Array.Empty<Weather>();
        public Main main { get; set; } = new Main();
        public Wind wind { get; set; } = new Wind();
        public Sys sys { get; set; } = new Sys();
        public string name { get; set; } = "";

        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Weather
        {
            public string main { get; set; } = "";
            public string description { get; set; } = "";
            public string icon { get; set; } = "";
        }

        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public string country { get; set; } = "";
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }
    }
} 