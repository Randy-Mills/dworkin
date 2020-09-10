using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Injury
{
    public class ForceInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Brain Injury.* You have suffered a brain injury. You have disadvantage on Intelligence, Wisdom, and Charisma checks, as well as Intelligence, Wisdom, and Charisma saving throws. If you fail a saving throw against bludgeoning damage, force damage, or psychic damage, you are also stunned until the end of your next turn. Magic such as the regenerate spell can restore your full brain function."),
            new Percentile(5,9,"*Broken leg.* Your speed on foot is halved, and you must use a cane or crutch to move. You fall prone after using the Dash action. You have disadvantage on Dexterity checks made to balance. If your leg is splinted with a successful DC 15 Wisdom (Medicine) check, then magical healing of 6th level or higher, such as heal and regenerate, mends the broken leg , or it will heal naturally in 8 weeks. If it is not splinted before it's healed or allowed to heal, the effects remain until it is rebroken and splinted."),
            new Percentile(10,14,"*Broken arm.* You can no longer hold anything with two hands, and you can hold only a single object at a time. If your arm is splinted with a successful DC 15 Wisdom (Medicine) check, then magical healing of 6th level or higher, such as heal and regenerate, mends the broken leg, or it will heal naturally in 8 weeks. If it is not splinted before it's healed or allowed to heal, the effects remain until it is rebroken and splinted."),
            new Percentile(15,19,"*Internal Injury.* Whenever you attempt an action in combat, you must make a DC 15 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, cure the injury, or if you spend ten days doing nothing but resting, it will heal naturally."),
            new Percentile(20,34,"*Broken Ribs.* Whenever you attempt an action in combat, you must make a DC 10 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, cure the injury, or if you spend ten days doing nothing but resting, it will heal naturally."),
            new Percentile(35,49,"*Major Concussion.* You have disadvantage on Intelligence checks, Wisdom checks, and Charisma checks, as well as Constitution saving throws to maintain concentration. Magical healing of 6th level or higher, such as heal and regenerate, cures the concussion. Alternately, it heals on its own in four weeks."),
            new Percentile(50,64,"*Minor Concussion.* You have disadvantage on Intelligence checks. The concussion heals if you receive any magical healing; alternately it heals on its own in two weeks. If you already have a minor concussion, you suffer a major concussion."),
            new Percentile(65,79,"*Severe bruising.* You suffer severe bruising over an extensive portion of your anatomy. Anytime you suffer bludgeoning or force damage, you suffer an additional point of bludgeoning or force damage. The bruising heals if you receive magical healing. Alternately, it heals on its own in 2 week."),
            new Percentile(80,99,"*Broken Nose.* Your broken nose is painful but doesn't have any adverse effect. Any magical healing mends your nose, although it may heal crooked if it is crooked when the healing is applied.")
        };

        public ForceInjury()
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