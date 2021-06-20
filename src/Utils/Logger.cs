using System;
using System.Threading.Tasks;
using Discord;

namespace Dworkin.Utils
{
    public class Logger
    {
        public Logger()
        {
        }

        public Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public Task Log(string msg)
        {
            Console.WriteLine(msg);
            return Task.CompletedTask;
        }
    }
}