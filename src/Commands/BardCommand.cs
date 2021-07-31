using System;
using System.Text.RegularExpressions;
using Dworkin.Utils;
using Dworkin.Tables.Bard;
using Dworkin.Interfaces;

namespace Dworkin.Commands
{
    public class BardCommand : IGenerator
    {
        private Random _rng;
        private Logger _logger;

        private ITable _tableMockeryBard;
        private ITable _tableInspirationBard;

        public BardCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;

            _tableMockeryBard = new MockeryBard();
            _tableInspirationBard = new InspirationBard();
        }

        public string Generate(string[] commands)
        {
            ITable table;
            if (Array.Exists(commands, element => element.ToLower() == "-mockery"))
            {
                table = _tableMockeryBard;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-inspiration"))
            {
                table = _tableInspirationBard;
            }
            else
            {
                return $"Provided Bard type does not correspond to the available list of options.";
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