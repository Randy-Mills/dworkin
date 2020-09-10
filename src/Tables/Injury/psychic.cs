using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Injury
{
    public class PsychicInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Brain Injury.* You have suffered a brain injury. You have disadvantage on Intelligence, Wisdom, and Charisma checks, as well as Intelligence, Wisdom, and Charisma saving throws. If you fail a saving throw against bludgeoning damage, force damage, or psychic damage, you are also stunned until the end of your next turn. Magic such as the regenerate spell can restore your full brain function."),
            new Percentile(5,9,"*Indefinite Madness.* Roll on the Indefinite Madness table in the Dungeon Masters Guide."),
            new Percentile(10,14,"*Severe headaches.* You have disadvantage on Wisdom checks and Wisdom saving throws. If you fail a saving throw against bludgeoning damage, force damage, or psychic damage, you are also stunned until the end of your next turn. Magic such as the regenerate spell can cure your severe headaches."),
            new Percentile(15,19,"*Phobia.* You develop a debilitating fear of something in the situation from which you gained your injury. For example, if you were damaged by a mind flayer, you might have a fear of octopuses. The DM will decide. When you are confronted with your phobia, you have disadvantage on all ability checks and saving throws. Magic such as the regenerate spell can cure your phobia."),
            new Percentile(20,34,"*Long-term Madness.* Roll on the Long-term Madness table in the Dungeon Masters Guide. Your madness lasts twice as long."),
            new Percentile(35,49,"*Weak Persona.* You have suffered damage to your sense of self. You have disadvantage on Charisma checks. Magic such as the regenerate spell can heal your weak persona. Alternately, it will heal on its own in four weeks."),
            new Percentile(50,64,"*Minor headaches.* You have disadvantage on Wisdom checks. Magical healing cures your minor headaches. Alternately, they will resolve on their own in two weeks."),
            new Percentile(65,79,"*Inappropriate Volume.* You can’t regulate your volume. You shout when you intend to whisper, and whisper when you intend to shout. Magical healing cures your inappropriate volume."),
            new Percentile(80,99,"*Short-term Madness.* Roll on the Short-term Madness table in the Dungeon Masters Guide. Your madness lasts twice as long.")
        };

        public PsychicInjury()
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