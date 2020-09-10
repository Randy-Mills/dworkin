using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Madness
{
    public class ShortTermMadness : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,19,"The character retreats into his or her mind and becomes paralyzed. The effect ends after 1d10 minutes or if the character takes any damage. "),
            new Percentile(20,29,"The character becomes incapacitated and spends the duration screaming, laughing, or weeping. Lasts for 1d10 minutes."),
            new Percentile(30,39,"The character becomes frightened and must use his or her action and movement each round to flee from the source of the fear. Lasts for 1d10 minutes."),
            new Percentile(40,49,"The character begins babbling and is incapable of normal speech or spellcasting. Lasts for 1d10 minutes."),
            new Percentile(50,59,"The character must use his or her action each round to attack the nearest creature. Lasts for 1d10 minutes."),
            new Percentile(60,69,"The character experiences vivid hallucinations and has disadvantage on ability checks. Lasts for 1d10 minutes."),
            new Percentile(70,74,"The character does whatever anyone tells him or her to do that isn’t obviously self­ destructive. Lasts for 1d10 minutes."),
            new Percentile(75,79,"The character experiences an overpowering urge to eat something strange such as dirt, slime, or offal. Lasts for 1d10 minutes."),
            new Percentile(80,89,"The character is stunned. Lasts for 1d10 minutes."),
            new Percentile(90,99,"The character falls unconscious. Lasts for 1d10 minutes.")
        };

        public ShortTermMadness()
        {
            Table = _table;
            Max = _table[_table.Length-1].max;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public Percentile[] Table { get; set; }

        public string Fetch(int position)
        {
            var response = "";
            foreach (Percentile element in Table)
            {
                if (Enumerable.Range(element.min,element.max).Contains(position))
                    response = element.value;
            }
            return response;
        }
    }
}