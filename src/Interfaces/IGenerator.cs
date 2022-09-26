using Discord;
using Discord.WebSocket;

namespace Dworkin.Interfaces
{
    public interface IGenerator
    {
        string Generate(SocketSlashCommandData data);
        SlashCommandBuilder BuildCommandWithOptions();
    }
}