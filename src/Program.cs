using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Generator.Commands;
using Generator.Utils;

namespace Generator
{
    public class Program
    {
        private DiscordSocketClient _client;
        private Random _rng;
        private Logger _logger;

        private DiceParser _diceParser;

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _rng = new Random();
            _logger = new Logger();
            _diceParser = new DiceParser(_rng);

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
                    WeatherCommand wc = new WeatherCommand(_rng, _logger);
                    response = wc.Generate(commands);
                    break;
                case "wildsurge":
                case "ws":
                    WildSurgeCommand wcs = new WildSurgeCommand(_rng, _logger);
                    response = wcs.Generate(commands);
                    break;
                case "npc":
                    NPCCommand npcc = new NPCCommand(_rng, _logger);
                    response = npcc.Generate(commands);
                    break;
                default:
                    response += "Command not recognized";
                    break;
            }
            
            if (messageChannel)
                await context.Channel.SendMessageAsync(_diceParser.Parse(response));
            else
                await context.User.SendMessageAsync(response);
        }

        private string Help()
        {
            return "Commands"
                 + "\n~wildsurge, ~ws: Randomly roll a Wild Surge effect."
                 + "\n\tOptions:"
                 + "\n\t -eldritch: Roll on the Ravenloft eldritch table."
                 + "\n\t -chaos: Roll on the large, extra chaotic table."
                 + "\n\t -duration: Include a random duration value with the generated wild surge."
                 + "\n\t digit: Directly lookup the value instead of rolling."
                 + "\n~weather, ~w: Randomly generate a basic weather state."
                 + "\n\tOptions:"
                 + "\n\t -light: Randomly generate a light precipitation state."
                 + "\n\t -medium: Randomly generate a medium precipitation state."
                 + "\n\t -heavy: Randomly generate a heavy precipitation state."
                 + "\n\t digit: Directly lookup the value instead of rolling.";
        }
    }
}