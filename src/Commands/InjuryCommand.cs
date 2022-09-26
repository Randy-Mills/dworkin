using System;
using Dworkin.Interfaces;
using Dworkin.Tables.Injury;
using Dworkin.Utils;
using Discord;
using Discord.WebSocket;

namespace Dworkin.Commands
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

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

        public SlashCommandBuilder BuildCommandWithOptions()
        {
            var commandBuilder = new SlashCommandBuilder();
            commandBuilder.WithName("injury");
            commandBuilder.WithDescription("Generate a random injury");
            
            commandBuilder.AddOption(new SlashCommandOptionBuilder()
                .WithName("injury-type")
                .WithDescription("What type of injury should we generate?")
                .WithRequired(true)
                .AddChoice("Acid", "acid")
                .AddChoice("Cold", "cold")
                .AddChoice("Fire", "fire")
                .AddChoice("Force", "force")
                .AddChoice("Lightning", "lightning")
                .AddChoice("Necrotic", "necrotic")
                .AddChoice("Piercing", "piercing")
                .AddChoice("Poison", "poison")
                .AddChoice("Psychic", "psychic")
                .AddChoice("Radiant", "radiant")
                .AddChoice("Slashing", "slashing")
                .AddChoice("Thunder", "thunder")
                .WithType(ApplicationCommandOptionType.String)
            );
            
            return commandBuilder;
        }

        public string Generate(SocketSlashCommandData data)
        {
            List<string> commands = new List<string>();
            
            foreach (SocketSlashCommandDataOption option in data.Options)
            {
                commands.Add(option.Value.ToString());
            }
            
            var injuryTypeArg = commands[0];

            ITable table;
            if (injuryTypeArg == "acid")
            {
                table = _tableAcidInjury;
            }
            else if (injuryTypeArg == "cold")
            {
                table = _tableColdInjury;
            }
            else if (injuryTypeArg == "fire")
            {
                table = _tableFireInjury;
            }
            else if (injuryTypeArg == "force")
            {
                table = _tableForceInjury;
            }
            else if (injuryTypeArg == "lightning")
            {
                table = _tableLightningInjury;
            }
            else if (injuryTypeArg == "necrotic")
            {
                table = _tableNecroticInjury;
            }
            else if (injuryTypeArg == "piercing")
            {
                table = _tablePiercingInjury;
            }
            else if (injuryTypeArg == "poison")
            {
                table = _tablePoisonInjury;
            }
            else if (injuryTypeArg == "psychic")
            {
                table = _tablePsychicInjury;
            }
            else if (injuryTypeArg == "radiant")
            {
                table = _tableRadiantInjury;
            }
            else if (injuryTypeArg == "slashing")
            {
                table = _tableSlashingInjury;
            }
            else if (injuryTypeArg == "thunder")
            {
                table = _tableThunderInjury;
            }
            else
            {
                return $"Provided injury type does not correspond to the available list of options.";
            }
        
            var randomValue = _rng.Next(table.TableSize);
            
            // Temporarily disable the direct lookup option for now - sam - sept 21, 2022
            
            // Regex re = new Regex(@"\d+");
            // foreach (string element in commands)
            // {
            //     if (re.IsMatch(element))
            //     {
            //         randomValue = Int32.Parse(element);
            //         break;
            //     }
            // }
            //
            // if (randomValue > table.TableSize)
            //     return $"Provided value is out of range. Selected table has {table.TableSize} rows.";
        
            return $">>> [{randomValue}]: {TableManager.Fetch(table, randomValue)}";
        }
    }
}