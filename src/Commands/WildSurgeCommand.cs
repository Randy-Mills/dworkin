using System;
using Dworkin.Interfaces;
using Dworkin.Tables.WildMagic;
using Dworkin.Utils;
using System.Collections.Generic;
using Discord;
using Discord.WebSocket;

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

        public SlashCommandBuilder BuildCommandWithOptions()
        {
            var commandBuilder = new SlashCommandBuilder();
            commandBuilder.WithName("wildsurge");
            commandBuilder.WithDescription("Generate a random wild surge result");
            
            commandBuilder.AddOption(new SlashCommandOptionBuilder()
                .WithName("table")
                .WithDescription("Which wild mage table should we roll on?")
                .WithRequired(true)
                .AddChoice("Chaos", "chaos")
                .AddChoice("Eldritch", "eldritch")
                .AddChoice("Izzet", "izzet")
                .AddChoice("Default", "default")
                .WithType(ApplicationCommandOptionType.String)
            );
            
            commandBuilder.AddOption(new SlashCommandOptionBuilder()
                .WithName("should-also-include-duration")
                .WithDescription("Should the duration be rolled?")
                .WithRequired(false)
                .WithType(ApplicationCommandOptionType.Boolean)
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
            
            var tableArg = commands[0];
            
            var durationArg = "False";
            
            if (commands.Count > 1)
            {
                durationArg = commands[1];
            }
            
            ITable table;
            if (tableArg == "chaos")
            {
                table = _tableChaosMagic;
            }
            else if (tableArg == "eldritch")
            {
                table = _tableEldritchMagic;
            }
            else if (tableArg == "izzet")
            {
                table = _tableIzzetMagic;
            }
            else if (tableArg == "default")
            {
                table = _tableWildMagic;
            }
            else
            {
                return $"Provided wild surge table does not correspond to the available list of options.";
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
        
            var output = $"[{randomValue}]: {TableManager.Fetch(table, randomValue)}";
        
            if (durationArg == "True")
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