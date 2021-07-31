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

        private ITable _tableShortTermMadness;
        private ITable _tableLongTermMadness;
        private ITable _tableIndefiniteMadness;

        public MadnessCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;

            _tableShortTermMadness = new ShortTermMadness();
            _tableLongTermMadness = new LongTermMadness();
            _tableIndefiniteMadness = new IndefiniteMadness();
        }

        public string Generate(string[] commands)
        {
            ITable table;
            if (Array.Exists(commands, element => element.ToLower() == "-short"))
            {
                table = _tableShortTermMadness;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-long"))
            {
                table = _tableLongTermMadness;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-indefinite"))
            {
                table = _tableIndefiniteMadness;
            }
            else
            {
                return $"Provided madness type does not correspond to the available list of options.";
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