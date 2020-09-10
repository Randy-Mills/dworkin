using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Injury
{
    public class ThunderInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Brain Injury.* You have suffered a brain injury. You have disadvantage on Intelligence, Wisdom, and Charisma checks, as well as Intelligence, Wisdom, and Charisma saving throws. If you fail a saving throw against bludgeoning damage, force damage, or psychic damage, you are also stunned until the end of your next turn. Magic such as the regenerate spell can restore your full brain function."),
            new Percentile(5,9,"*Deafness.* Your eardrums have been destroyed; you gain the deafened condition. Magic such as the regenerate spell can restore your hearing."),
            new Percentile(10,14,"*Partial Deafness.* Your eardrums have been damaged; you are hard of hearing. You have disadvantage on any ability check that requires hearing. Magic such as the regenerate spell can restore your hearing."),
            new Percentile(15,19,"*Severe Headaches.* You have disadvantage on Wisdom checks and Wisdom saving throws. If you fail a saving throw against bludgeoning damage, force damage, or psychic damage, you are also stunned until the end of your next turn. Magic such as the regenerate spell can cure your severe headaches."),
            new Percentile(20,34,"*Internal Injury.* Whenever you attempt an action in combat, you must make a DC 15 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, cures the internal injury, or if you spend ten days doing nothing but resting, it heals on its own."),
            new Percentile(35,49,"*Major Concussion.* You have disadvantage on Intelligence checks, Wisdom checks, and Charisma checks, as well as Constitution saving throws to maintain concentration. Magical healing of 6th level or higher, such as heal and regenerate, cures the concussion. Alternately, it heals on its own in four weeks."),
            new Percentile(50,64,"*Minor Concussion.* You have disadvantage on Intelligence checks. The concussion heals if you receive any magical healing; alternately it heals on its own in two weeks. If you already have a minor concussion, you suffer a major concussion."),
            new Percentile(65,79,"*Minor headaches.* You have disadvantage on Wisdom checks. Magical healing of 6th level or higher, such as heal and regenerate, cures the headaches. Alternately, they will resolve on their own in two weeks."),
            new Percentile(80,99,"*Severe bruising.* You suffer severe bruising over an extensive portion of your anatomy. Anytime you suffer bludgeoning or force damage, you suffer an additional point of bludgeoning or force damage. The bruising heals if you receive magical healing. Alternately, it heals on its own in 2 week.")
        };

        public ThunderInjury()
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