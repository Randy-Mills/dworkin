using System;
using System.Text.RegularExpressions;
using Generator.Tables.WildMagic;
using Generator.Utils;
using Toolkit.Generator;

namespace Generator.Commands
{
    public class WildSurgeCommand : IGenerator
    {
        private Random _rng;
        private Logger _logger;

        public WildSurgeCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;
        }

        public string Generate(string[] commands)
        {
            ITable table;
            if (Array.Exists(commands, element => element.ToLower() == "-chaos"))
            {
                table = new ChaosMagic();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-eldritch"))
            {
                table = new EldritchMagic();
            }
            else
            {
                table = new WildMagic();
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