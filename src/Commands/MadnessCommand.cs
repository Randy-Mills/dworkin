using System;
using Dworkin.Interfaces;
using Dworkin.Tables.Madness;
using Dworkin.Utils;
using System.Collections.Generic;
using Discord;
using Discord.WebSocket;

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

        public SlashCommandBuilder BuildCommandWithOptions()
        {
            var commandBuilder = new SlashCommandBuilder();
            commandBuilder.WithName("madness");
            commandBuilder.WithDescription("Generate a random madness");
            
            commandBuilder.AddOption(new SlashCommandOptionBuilder()
                .WithName("madness-type")
                .WithDescription("How long should the madness last?")
                .WithRequired(true)
                .AddChoice("Short", "short")
                .AddChoice("Long", "long")
                .AddChoice("Indefinite", "indefinite")
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
            
            var madnessTypeArg = commands[0];
            
            ITable table;
            if (madnessTypeArg == "short")
            {
                table = _tableShortTermMadness;
            }
            else if (madnessTypeArg == "long")
            {
                table = _tableLongTermMadness;
            }
            else if (madnessTypeArg == "indefinite")
            {
                table = _tableIndefiniteMadness;
            }
            else
            {
                return $"Provided madness type does not correspond to the available list of options.";
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