using System;
using System.Text.RegularExpressions;
using Dworkin.Interfaces;
using Dworkin.Tables.WildMagic;
using Dworkin.Utils;

namespace Dworkin.Commands
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
            else if (Array.Exists(commands, element => element.ToLower() == "-izzet"))
            {
                table = new IzzetMagic();
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

            var output = $"[{randomValue}]: {table.Fetch(randomValue)}";

            if (Array.Exists(commands, element => element.ToLower() == "-duration"))
            {
                var durationTable = new SurgeDuration();
                var randomDuration = _rng.Next(durationTable.Max);
                var duration = durationTable.Fetch(randomDuration);
                duration = char.ToLower(duration[0]) + duration.Substring(1);
                output += $" The condition will last until {duration}";
            }
            
            return ">>> " + output;
        }
    }
}