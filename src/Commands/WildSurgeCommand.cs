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

        private ITable _tableChaosMagic;
        private ITable _tableEldritchMagic;
        private ITable _tableIzzetMagic;
        private ITable _tableWildMagic;
        private ITable _tableSurgeDuration;

        public WildSurgeCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;

            _tableChaosMagic = new ChaosMagic();
            _tableEldritchMagic = new EldritchMagic();
            _tableIzzetMagic = new IzzetMagic();
            _tableWildMagic = new WildMagic();
            _tableSurgeDuration = new SurgeDuration();
        }

        public string Generate(string[] commands)
        {
            ITable table;
            if (Array.Exists(commands, element => element.ToLower() == "-chaos"))
            {
                table = _tableChaosMagic;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-eldritch"))
            {
                table = _tableEldritchMagic;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-izzet"))
            {
                table = _tableIzzetMagic;
            }
            else
            {
                table = _tableWildMagic;
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

            var output = $"[{randomValue}]: {TableManager.Fetch(table, randomValue)}";

            if (Array.Exists(commands, element => element.ToLower() == "-duration"))
            {
                var randomDuration = _rng.Next(_tableSurgeDuration.TableSize);
                var duration = TableManager.Fetch(_tableSurgeDuration, randomDuration);
                duration = char.ToLower(duration[0]) + duration.Substring(1);
                output += $" The condition will last until {duration}";
            }
            
            return ">>> " + output;
        }
    }
}