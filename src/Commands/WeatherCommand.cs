using System;
using System.Text.RegularExpressions;
using Dworkin.Interfaces;
using Dworkin.Tables.Weather;
using Dworkin.Utils;

namespace Dworkin.Commands
{
    public class WeatherCommand : IGenerator
    {
        private Random _rng;
        private Logger _logger;

        private ITable _tableLightPrecipitation;
        private ITable _tableMediumPrecipitation;
        private ITable _tableHeavyPrecipitation;
        private ITable _tableTemperateWeather;

        public WeatherCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;

            _tableLightPrecipitation = new LightPrecipitation();
            _tableMediumPrecipitation = new MediumPrecipitation();
            _tableHeavyPrecipitation = new HeavyPrecipitation();
            _tableTemperateWeather = new TemperateWeather();
        }

        public string Generate(string[] commands)
        {
            ITable table;
            if (Array.Exists(commands, element => element.ToLower() == "-light"))
            {
                table = _tableLightPrecipitation;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-medium"))
            {
                table = _tableMediumPrecipitation;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-heavy"))
            {
                table = _tableHeavyPrecipitation;
            }
            else
            {
                table = _tableTemperateWeather;
            }

            var randomValue = _rng.Next(table.TableSize);

            Regex re = new Regex(@"\d+");
            foreach (string element in commands)
            {
                if (re.IsMatch(element))
                {
                    randomValue = Int32.Parse(element);
                    break;
                }
            }

            if (randomValue > table.TableSize)
                return $"Provided value is out of range. Selected table has {table.TableSize} rows.";
            
            return $">>> [{randomValue}]: {TableManager.Fetch(table, randomValue)}";
        }
    }
}