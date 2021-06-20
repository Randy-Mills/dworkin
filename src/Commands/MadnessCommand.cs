using System;
using System.Text.RegularExpressions;
using Dworkin.Interfaces;
using Dworkin.Tables.Madness;
using Dworkin.Utils;

namespace Dworkin.Commands
{
    public class MadnessCommand : IGenerator
    {
        private Random _rng;
        private Logger _logger;

        public MadnessCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;
        }

        public string Generate(string[] commands)
        {
            ITable table;
            if (Array.Exists(commands, element => element.ToLower() == "-short"))
            {
                table = new ShortTermMadness();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-long"))
            {
                table = new LongTermMadness();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-indefinite"))
            {
                table = new IndefiniteMadness();
            }
            else
            {
                return $"Provided madness type does not correspond to the available list of options.";
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