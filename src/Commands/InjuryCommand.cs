using System;
using System.Text.RegularExpressions;
using Dworkin.Interfaces;
using Dworkin.Tables.Injury;
using Dworkin.Utils;

namespace Dworkin.Commands
{
    public class InjuryCommand : IGenerator
    {
        private Random _rng;
        private Logger _logger;

        public InjuryCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;
        }

        public string Generate(string[] commands)
        {
            ITable table;
            if (Array.Exists(commands, element => element.ToLower() == "-acid"))
            {
                table = new AcidInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-cold"))
            {
                table = new ColdInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-fire"))
            {
                table = new FireInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-force"))
            {
                table = new ForceInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-lightning"))
            {
                table = new LightningInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-necrotic"))
            {
                table = new NecroticInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-piercing"))
            {
                table = new PiercingInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-poison"))
            {
                table = new PoisonInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-psychic"))
            {
                table = new PsychicInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-radiant"))
            {
                table = new RadiantInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-slashing"))
            {
                table = new SlashingInjury();
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-thunder"))
            {
                table = new ThunderInjury();
            }
            else
            {
                return $"Provided injury type does not correspond to the available list of options.";
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