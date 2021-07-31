using System;
using System.Text.RegularExpressions;

namespace Dworkin.Utils
{
    public class DiceParser
    {
        private Random _rng;

        public DiceParser(Random rng)
        {
            _rng = rng;
        }

        public string Parse(string msg)
        {
            Regex diceRegex = new Regex(@"\d+d\d+");

            Match match = diceRegex.Match(msg);
            while (match.Success)
            {
                var numDice = int.Parse(match.ToString().Split("d")[0]);
                var dieSize = int.Parse(match.ToString().Split("d")[1]);
                var value = 0;

                for (int i = 0; i < numDice; i++)
                {
                    value += _rng.Next(dieSize) + 1;
                }

                msg = diceRegex.Replace(msg, value.ToString(), 1);

                match = match.NextMatch();
            }

            return msg;
        }
    }
}