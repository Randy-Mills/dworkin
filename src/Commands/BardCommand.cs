using System;
using Dworkin.Utils;
using Dworkin.Tables.Bard;
using Dworkin.Interfaces;
using System.Collections.Generic;
using Discord;
using Discord.WebSocket;

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

        public SlashCommandBuilder BuildCommandWithOptions()
        {
            var commandBuilder = new SlashCommandBuilder();
            commandBuilder.WithName("bard");
            commandBuilder.WithDescription("Generate a bardic inspiration or mockery");
            
            commandBuilder.AddOption(new SlashCommandOptionBuilder()
                .WithName("bardic-inspiration")
                .WithDescription("What type of bardic inspiration should be generated?")
                .WithRequired(true)
                .AddChoice("Inspiration", "inspiration")
                .AddChoice("Mockery", "mockery")
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
            
            var inspirationType = commands[0];

            ITable table;
            if (inspirationType == "mockery")
            {
                table = _tableMockeryBard;
            }
            else if (inspirationType == "inspiration")
            {
                table = _tableInspirationBard;
            }
            else
            {
                return $"Provided Bard type does not correspond to the available list of options.";
            }
        
            var randomValue = _rng.Next(table.TableSize);
            
            // Disable the direct lookup option for now - sam - sept 21, 2022
        
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