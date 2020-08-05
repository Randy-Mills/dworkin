using System;
using System.Text.RegularExpressions;
using Generator.Tables.Weather;
using Generator.Utils;
using Toolkit.Generator;

namespace Generator.Commands
{
    public class WeatherCommand : IGenerator
    {
        private Random _rng;
        private Logger _logger;

        public WeatherCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;
        }

        public string Generate(string[] commands)
        {
            ITable table;
            if (Array.Exists(commands, element => element.ToLower() == "-light"))
            {
                table = new LightPrecipitation();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-medium"))
            {
                table = new MediumPrecipitation();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-heavy"))
            {
                table = new HeavyPrecipitation();
            }
            else
            {
                table = new TemperateWeather();
            }

            var randomValue = _rng.Next(table.Max);

            Regex re = new Regex(@"\d+");
            foreach (string element in commands)
            {
                if (re.IsMatch(element))
                {
                    randomValue = Int32.Parse(element);
                    break;
                }
            }

            if (randomValue > table.Max)
                return $"Provided value is out of range. Selected table has {table.Max} rows.";
            
            return $"[{randomValue}]: {table.Fetch(randomValue)}";
        }
    }
}