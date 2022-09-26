using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Dworkin.Commands;
using Dworkin.Interfaces;
using Dworkin.Utils;

namespace Dworkin
{
    public class Program
    {
        private DiscordSocketClient _client;
        private Random _rng;
        private Logger _logger;

        private IGenerator _weatherCommand;
        private IGenerator _wildSurgeCommand;
        private IGenerator _npcCommand;
        private IGenerator _injuryCommand;
        private IGenerator _madnessCommand;
        private IGenerator _bardCommand;
        private IGenerator _helpCommand;

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _rng = new Random();
            _logger = new Logger();

            _weatherCommand = new WeatherCommand(_rng, _logger);
            _wildSurgeCommand = new WildSurgeCommand(_rng, _logger);
            _npcCommand = new NPCCommand(_rng, _logger);
            _injuryCommand = new InjuryCommand(_rng, _logger);
            _madnessCommand = new MadnessCommand(_rng, _logger);
            _bardCommand = new BardCommand(_rng, _logger);
            _helpCommand = new HelpCommand(_logger);

            _client.Log += _logger.Log;

            var token = File.ReadLines("token.txt").First();
            
            _client.SlashCommandExecuted += _onSlashCommandReceived;

            _client.Ready += _onClientReady;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await _client.SetGameAsync("Use /dworkinhelp for help");

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task<Task> _onClientReady()
        {
            Console.WriteLine("Dworkin is connected!");
            
            // Bootstrap slash commands pt 1
            var weatherCommand = _weatherCommand.BuildCommandWithOptions();
            var bardCommand = _bardCommand.BuildCommandWithOptions();
            var wildSurgeCommand = _wildSurgeCommand.BuildCommandWithOptions();
            var npcCommand = _npcCommand.BuildCommandWithOptions();
            var injuryCommand = _injuryCommand.BuildCommandWithOptions();
            var madnessCommand = _madnessCommand.BuildCommandWithOptions();
            var helpCommand = _helpCommand.BuildCommandWithOptions();

            try
            {
                // Bootstrap slash commands pt 2
                await _client.CreateGlobalApplicationCommandAsync(weatherCommand.Build());
                await _client.CreateGlobalApplicationCommandAsync(bardCommand.Build());
                await _client.CreateGlobalApplicationCommandAsync(wildSurgeCommand.Build());
                await _client.CreateGlobalApplicationCommandAsync(npcCommand.Build());
                await _client.CreateGlobalApplicationCommandAsync(injuryCommand.Build());
                await _client.CreateGlobalApplicationCommandAsync(madnessCommand.Build());
                await _client.CreateGlobalApplicationCommandAsync(helpCommand.Build());
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception in command handler bootstrap logic;");
                Console.WriteLine(e);
            }
            
            return Task.CompletedTask;
        }
        
        private async Task _onSlashCommandReceived(SocketSlashCommand command)
        {
            string response = null;
            
            // Branch on command name
            switch (command.Data.Name)
            {
                case "weather":
                    response = _weatherCommand.Generate(command.Data);
                    break;
                case "bard":
                    response = _bardCommand.Generate(command.Data);
                    break;
                case "wildsurge":
                    response = _wildSurgeCommand.Generate(command.Data);
                    break;
                case "npc":
                    response = _npcCommand.Generate(command.Data);
                    break;
                case "injury":
                    response = _injuryCommand.Generate(command.Data);
                    break;
                case "madness":
                    response = _madnessCommand.Generate(command.Data);
                    break;
                case "dworkinhelp":
                    response = _helpCommand.Generate(command.Data);
                    break;
                default:
                    response = "Unknown command";
                    break;
            }
            
            await command.RespondAsync($"{response ?? "No response / unrecognized bot command"}");
        }
    }
}