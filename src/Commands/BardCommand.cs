using System;
using System.Text.RegularExpressions;
using Generator.Tables.Bard;
using Generator.Utils;
using Toolkit.Generator;

namespace Generator.Commands
{
    public class BardCommand : IGenerator
    {
        private Random _rng;
        private Logger _logger;

        public BardCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;
        }

        public string Generate(string[] commands)
        {
            ITable table;
            if (Array.Exists(commands, element => element.ToLower() == "-mockery"))
            {
                table = new MockeryBard();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-inspiration"))
            {
                table = new InspirationBard();
            }
            else
            {
                return $"Provided Bard type does not correspond to the available list of options.";
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

            return $">>> [{randomValue}]: {table.Fetch(randomValue)}";
        }
    }
}