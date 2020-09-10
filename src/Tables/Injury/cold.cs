using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Injury
{
    public class ColdInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Ocular Damage.* One of your corneas is damaged from frostbite. You have disadvantage on Wisdom (Perception) checks that rely on sight and on ranged attack rolls. Magic such as the regenerate spell can restore the damaged cornea. If you have no corneas that remain undamaged after sustaining this injury, you're blinded."),
            new Percentile(5,9,"*Systemic Damage from Frostbite.* You have disadvantage on Strength, Dexterity, and Constitution ability checks and Strength, Dexterity, and Constitution saving throws. Magic such as the regenerate spell cures this damage."),
            new Percentile(10,14,"*Gangrene of the Hand.* You can no longer hold anything with two hands, and you can hold only a single object at a time. Magic such as the regenerate spell can restore the crushed appendage."),
            new Percentile(15,19,"*Gangrene of the Foot.* Your speed on foot is halved, and you must use a cane or crutch to move. You fall prone after using the Dash action. You have disadvantage on Dexterity checks made to balance. Magic such as the regenerate spell can restore the crushed appendage."),
            new Percentile(20,34,"*Major Neuralgia.* You have constant, painful nerve damage over a large portion of your body. Whenever you attempt an action in combat, you must make a DC 15 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, cures the neuralgia, or if you spend twenty days doing nothing but resting it resolves on its own."),
            new Percentile(35,49,"*Frostbitten Foot.* Your speed on foot is reduced by 5 feet. You must make a DC 10 Dexterity saving throw after using the Dash action. If you fail the save, you fall prone. Magical healing cures the frostbite. Alternately, your foot can be treated with a successful DC 15 Wisdom (Medicine) check, in which case it will heal naturally in 2 weeks."),
            new Percentile(50,64,"*Frostbitten hand.* Randomly determine which hand has been frostbitten. In order to grasp or manipulate an object with that hand, you must succeed at a DC 15 Dexterity check. Magical healing cures the frostbite. Alternately, your hand can be treated with a successful DC 15 Wisdom (Medicine) check, in which case it will heal naturally in 2 weeks."),
            new Percentile(65,79,"*Minor Neuralgia.* You have constant, painful nerve damage over a large portion of your body. Whenever you attempt an action in combat, you must make a DC 10 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, cures the neuralgia, or if you spend ten days doing nothing but resting it resolves on its own."),
            new Percentile(80,99,"*Anosmia.* You lose your sense of smell and taste. You automatically fail any ability checks that involve your sense of smell or taste. The condition heals if you receive any magical healing.")
        };

        public ColdInjury()
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