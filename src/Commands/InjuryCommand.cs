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

        private ITable _tableAcidInjury;
        private ITable _tableColdInjury;
        private ITable _tableFireInjury;
        private ITable _tableForceInjury;
        private ITable _tableLightningInjury;
        private ITable _tableNecroticInjury;
        private ITable _tablePiercingInjury;
        private ITable _tablePoisonInjury;
        private ITable _tablePsychicInjury;
        private ITable _tableRadiantInjury;
        private ITable _tableSlashingInjury;
        private ITable _tableThunderInjury;

        public InjuryCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;

            _tableAcidInjury = new AcidInjury();
            _tableColdInjury = new ColdInjury();
            _tableFireInjury = new FireInjury();
            _tableForceInjury = new ForceInjury();
            _tableLightningInjury = new LightningInjury();
            _tableNecroticInjury = new NecroticInjury();
            _tablePiercingInjury = new PiercingInjury();
            _tablePoisonInjury = new PoisonInjury();
            _tablePsychicInjury = new PsychicInjury();
            _tableRadiantInjury = new RadiantInjury();
            _tableSlashingInjury = new SlashingInjury();
            _tableThunderInjury = new ThunderInjury();
        }

        public string Generate(string[] commands)
        {
            ITable table;
            if (Array.Exists(commands, element => element.ToLower() == "-acid"))
            {
                table = _tableAcidInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-cold"))
            {
                table = _tableColdInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-fire"))
            {
                table = _tableFireInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-force"))
            {
                table = _tableForceInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-lightning"))
            {
                table = _tableLightningInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-necrotic"))
            {
                table = _tableNecroticInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-piercing"))
            {
                table = _tablePiercingInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-poison"))
            {
                table = _tablePoisonInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-psychic"))
            {
                table = _tablePsychicInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-radiant"))
            {
                table = _tableRadiantInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-slashing"))
            {
                table = _tableSlashingInjury;
            }
            else if (Array.Exists(commands, element => element.ToLower() == "-thunder"))
            {
                table = _tableThunderInjury;
            }
            else
            {
                return $"Provided injury type does not correspond to the available list of options.";
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