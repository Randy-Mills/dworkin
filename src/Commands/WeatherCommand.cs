using System;
using Dworkin.Interfaces;
using Dworkin.Tables.Weather;
using Dworkin.Utils;
using Discord;
using Discord.WebSocket;
using System.Collections.Generic;

namespace Dworkin.Commands
{

    public class WeatherCommand : IGenerator
    {
        private Random _rng;
        private Logger _logger;

        private ITable _tableLightPrecipitation;
        private ITable _tableMediumPrecipitation;
        private ITable _tableHeavyPrecipitation;
        private ITable _tableTemperateWeather;

        public WeatherCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;

            _tableLightPrecipitation = new LightPrecipitation();
            _tableMediumPrecipitation = new MediumPrecipitation();
            _tableHeavyPrecipitation = new HeavyPrecipitation();
            _tableTemperateWeather = new TemperateWeather();
        }

        public SlashCommandBuilder BuildCommandWithOptions()
        {
            var commandBuilder = new SlashCommandBuilder();
            commandBuilder.WithName("weather");
            commandBuilder.WithDescription("Generate some random weather");
            
            commandBuilder.AddOption(new SlashCommandOptionBuilder()
                .WithName("precipitation-amount")
                .WithDescription("How much precipitation should there be?")
                .WithRequired(true)
                .AddChoice("Light", "light")
                .AddChoice("Medium", "medium")
                .AddChoice("Heavy", "heavy")
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
            
            var precipitationAmountArg = commands[0];
            
            ITable table;
            
            if (precipitationAmountArg == "light")
            {
                table = _tableLightPrecipitation;
            }
            else if (precipitationAmountArg == "medium")
            {
                table = _tableMediumPrecipitation;
            }
            else if (precipitationAmountArg == "heavy")
            {
                table = _tableHeavyPrecipitation;
            }
            else
            {
                table = _tableTemperateWeather;
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

            // if (randomValue > table.TableSize)
            //     return $"Provided value is out of range. Selected table has {table.TableSize} rows.";
            
            return $">>> [{randomValue}]: {TableManager.Fetch(table, randomValue)}";
        }
    }
}