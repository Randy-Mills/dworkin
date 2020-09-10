using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Madness
{
    public class LongTermMadness : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,9,"The character feels compelled to repeat a specific activity over and over, such as washing hands, touching things, praying, or counting coins. Lasts for 1d10 x 10 hours."),
            new Percentile(10,19,"The character experiences vivid hallucinations and has disadvantage on ability checks. Lasts for 1d10 x 10 hours."),
            new Percentile(20,29,"The character suffers extreme paranoia. The character has disadvantage on wisdom and charisma checks. Lasts for 1d10 x 10 hours."),
            new Percentile(30,39,"The character regards something (usually the source of madness) with intense revulsion, as if affected by the antipathy effect of the Antipathy/Sympathy spell. Lasts for 1d10 x 10 hours."),
            new Percentile(40,44,"The character experiences a powerful delusion. Choose a potion. The character imagines that he or she is under its effects. Lasts for 1d10 x 10 hours."),
            new Percentile(45,54,"The character becomes attached to a “lucky charm,” such as a person or an object, and has disadvantage on attack rolls, ability checks, and saving throws while more than 30 feet from it. Lasts for 1d10 x 10 hours."),
            new Percentile(55,64,"The character is blinded (25%) or deafened (75%). Lasts for 1d10 x 10 hours."),
            new Percentile(65,74,"The character experiences uncontrollable tremors or tics, which impose disadvantage on attack rolls, ability checks, and saving throws that involve strength or dexterity. Lasts for 1d10 x 10 hours."),
            new Percentile(75,84,"The character suffers from partial amnesia. The character knows who he or she is and retains racial traits and class features, but doesn’t recognize other people or remember anything that happened before the madness took effect. Lasts for 1d10 x 10 hours."),
            new Percentile(85,89,"Whenever the character takes damage, he or she must succeed on a DC 15 wisdom saving throw or be affected as though he or she failed a saving throw against the confusion spell. The confusion effect lasts for 1 minute. Madness lasts for 1d10 x 10 hours."),
            new Percentile(90,94,"The character loses the ability to speak. Lasts for 1d10 x 10 hours."),
            new Percentile(95,99,"The character falls unconscious. No amount of jostling or damage can wake the character. Lasts for 1d10 x 10 hours.")
        };

        public LongTermMadness()
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