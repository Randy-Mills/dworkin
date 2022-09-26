using Dworkin.Utils;
using Dworkin.Interfaces;
using Discord;
using Discord.WebSocket;

namespace Dworkin.Commands
{
    public class HelpCommand : IGenerator
    {
        private Logger _logger;
        
        public HelpCommand(Logger logger)
        {
            _logger = logger;
        }

        public SlashCommandBuilder BuildCommandWithOptions()
        {
            var commandBuilder = new SlashCommandBuilder();
            commandBuilder.WithName("dworkinhelp");
            commandBuilder.WithDescription("Outputs dworkin help");
            return commandBuilder;
        }

        public string Generate(SocketSlashCommandData data)
        {
            return "Commands"
                   + "\n\n/wildsurge: Randomly roll a Wild Surge effect."
                   + "\n\tOptions:"
                   + "\n\t chaos: Roll on the large, extra chaotic table."
                   + "\n\t eldritch: Roll on the Ravenloft eldritch table."
                   + "\n\t izzet: Roll on the Izzet Guild table."
                   + "\n\t duration: Include a random duration value with the generated wild surge."
                   // + "\n\t digit: Directly lookup the value instead of rolling."
                   + "\n\n/bard: Rolls for an inspirational or brutal remark to others around you."
                   + "\n\tOptions:"
                   + "\n\t mockery: Rolls for a brutal insult."
                   + "\n\t inspiration: Rolls for an inspirational line to your comrades."
                   + "\n\n/injury: Rolls for a Lingering Injury depending on type of damage."
                   + "\n\tOptions:"
                   + "\n\t acid: Rolls for a lingering injury caused by acid."
                   + "\n\t cold: Rolls for a lingering injury caused by cold."
                   + "\n\t fire: Rolls for a lingering injury caused by fire."
                   + "\n\t force: Rolls for a lingering injury caused by force."
                   + "\n\t lightning: Rolls for a lingering injury caused by lightning."
                   + "\n\t necrotic: Rolls for a lingering injury caused by necrotic."
                   + "\n\t piercing: Rolls for a lingering injury caused by piercing."
                   + "\n\t poison: Rolls for a lingering injury caused by poison."
                   + "\n\t psychic: Rolls for a lingering injury caused by psychic."
                   + "\n\t radiant: Rolls for a lingering injury caused by radiant."
                   + "\n\t slashing: Rolls for a lingering injury caused by slashing."
                   + "\n\t thunder: Rolls for a lingering injury caused by thunder."
                   + "\n\n/madness: Rolls for a madness effect depending on the severity."
                   + "\n\tOptions:"
                   + "\n\t short: Rolls for a short term madness effect."
                   + "\n\t long: Rolls for a long term madness effect."
                   + "\n\t indefinite: Rolls for a indefinite madness effect."
                   + "\n\n/weather: Randomly generate a basic weather state."
                   + "\n\tOptions:"
                   + "\n\t light: Randomly generate a light precipitation state."
                   + "\n\t medium: Randomly generate a medium precipitation state."
                   + "\n\t heavy: Randomly generate a heavy precipitation state."
                   // + "\n\t digit: Directly lookup the value instead of rolling."
                   + "\n\n/npc: Randomly generate a basic NPC with a name, gender, race, and appearance."
                   + "\n\n/dworkinhelp: See the bot help text";
        }
    }
}