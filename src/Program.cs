using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
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

        private DiceParser _diceParser;

        private IGenerator _weatherCommand;
        private IGenerator _wildSurgeCommand;
        private IGenerator _npcCommand;
        private IGenerator _injuryCommand;
        private IGenerator _madnessCommand;
        private IGenerator _bardCommand;

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _rng = new Random();
            _logger = new Logger();
            _diceParser = new DiceParser(_rng);

            _weatherCommand = new WeatherCommand(_rng, _logger);
            _wildSurgeCommand = new WildSurgeCommand(_rng, _logger);
            _npcCommand = new NPCCommand(_rng, _logger);
            _injuryCommand = new InjuryCommand(_rng, _logger);
            _madnessCommand = new MadnessCommand(_rng, _logger);
            _bardCommand = new BardCommand(_rng, _logger);

            _client.Log += _logger.Log;

            var token = File.ReadLines("token.txt").First();

            _client.MessageUpdated += MessageUpdated;
            _client.MessageReceived += OnMessageReceivedAsync;
            _client.Ready += () => 
            {
                Console.WriteLine("Bot is connected!");
                return Task.CompletedTask;
            };

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await _client.SetGameAsync("~help");

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task MessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
        {
            // If the message was not in the cache, downloading it will result in getting a copy of `after`.
            var message = await before.GetOrDownloadAsync();
            Console.WriteLine($"{message} -> {after}");
        }

        private async Task OnMessageReceivedAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;     // Ensure the message is from a user/bot
            if (msg == null) return;
            if (msg.Author.Id == _client.CurrentUser.Id) return;     // Ignore self when checking commands
            if (!msg.ToString().StartsWith("~")) return;
            
            var context = new SocketCommandContext(_client, msg);     // Create the command context
            
            bool messageChannel = true;
            string response = "";

            var commands = msg.ToString().Substring(1).Split(' ');

            switch (commands[0].ToLower())
            {
                case "help":
                    response += Help();
                    messageChannel = false;
                    break;
                case "weather":
                case "w":
                    response = _weatherCommand.Generate(commands);
                    break;
                case "wildsurge":
                case "ws":
                    response = _wildSurgeCommand.Generate(commands);
                    break;
                case "npc":
                    response = _npcCommand.Generate(commands);
                    break;
                case "injury":
                    response = _injuryCommand.Generate(commands);
                    break;
                case "madness":
                    response = _madnessCommand.Generate(commands);
                    break;
                case "bard":
                    response = _bardCommand.Generate(commands);
                    break;
                default:
                    response += "Command not recognized";
                    break;
            }
            
            if (messageChannel)
                await context.Channel.SendMessageAsync(_diceParser.Parse(response));
            else {
                await context.User.SendMessageAsync(response);
                await context.Channel.SendMessageAsync("I have sent help to your PMs.");
            }
        }

        private string Help()
        {
            return "Commands"
                 + "\n~wildsurge, ~ws: Randomly roll a Wild Surge effect."
                 + "\n\tOptions:"
                 + "\n\t -chaos: Roll on the large, extra chaotic table."
                 + "\n\t -eldritch: Roll on the Ravenloft eldritch table."
                 + "\n\t -izzet: Roll on the Izzet Guild table."
                 + "\n\t -duration: Include a random duration value with the generated wild surge."
                 + "\n\t digit: Directly lookup the value instead of rolling."
                 + "\n~bard: Rolls for an inpirational or brutal remark to others around you."
                 + "\n\tOptions:"
                 + "\n\t -mockery: Rolls for a brutal insult."
                 + "\n\t -inspiration: Rolls for an inspirational line to your comrads."
                 + "\n~injury: Rolls for a Lingering Injury depending on type of damage."
                 + "\n\tOptions:"
                 + "\n\t -acid: Rolls for a lingering injury caused by acid."
                 + "\n\t -cold: Rolls for a lingering injury caused by cold."
                 + "\n\t -fire: Rolls for a lingering injury caused by fire."
                 + "\n\t -force: Rolls for a lingering injury caused by force."
                 + "\n\t -lightning: Rolls for a lingering injury caused by lightning."
                 + "\n\t -necrotic: Rolls for a lingering injury caused by necrotic."
                 + "\n\t -piercing: Rolls for a lingering injury caused by piercing."
                 + "\n\t -poison: Rolls for a lingering injury caused by poison."
                 + "\n\t -psychic: Rolls for a lingering injury caused by psychic."
                 + "\n\t -radiant: Rolls for a lingering injury caused by radiant."
                 + "\n\t -slashing: Rolls for a lingering injury caused by slashing."
                 + "\n\t -thunder: Rolls for a lingering injury caused by thunder."
                + "\n~madness: Rolls for a madness effect depending on the severity."
                 + "\n\tOptions:"
                 + "\n\t -short: Rolls for a short term madness effect."
                 + "\n\t -long: Rolls for a long term madness effect."
                 + "\n\t -indefinite: Rolls for a indefinite madness effect."
                 + "\n~weather, ~w: Randomly generate a basic weather state."
                 + "\n\tOptions:"
                 + "\n\t -light: Randomly generate a light precipitation state."
                 + "\n\t -medium: Randomly generate a medium precipitation state."
                 + "\n\t -heavy: Randomly generate a heavy precipitation state."
                 + "\n\t digit: Directly lookup the value instead of rolling."
                 + "\n~npc: Randomly generate a basic NPC with a name, gender, race, and appearance.";
        }
    }
}