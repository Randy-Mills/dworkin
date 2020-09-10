using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Injury
{
    public class SlashingInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Lose an Eye.* You have disadvantage on Wisdom (Perception) checks that rely on sight and on ranged attack rolls. Magic such as the regenerate spell can restore the lost eye. If you have no eyes left after sustaining this injury, you're blinded."),
            new Percentile(5,9,"*Lose an Arm or a Hand.* You can no longer hold anything with two hands, and you can hold only a single object at a time. Magic such as the regenerate spell can restore the lost appendage."),
            new Percentile(10,14,"*Lose a Foot or Leg.* Your speed on foot is halved, and you must use a cane or crutch to move unless you have a peg leg or other prosthesis. You fall prone after using the Dash action. You have disadvantage on Dexterity checks made to balance. Magic such as the regenerate spell can restore the lost appendage."),
            new Percentile(15,19,"*Hamstrung.* Your speed on foot is reduced by 5 feet. You must make a DC 10 Dexterity saving throw after using the Dash action. If you fail the save, you fall prone. Magic such as the regenerate spell can cure your severed hamstring tendons."),
            new Percentile(20,34,"*Major Internal Injury.* Whenever you attempt an action in combat, you must make a DC 15 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, heals the internal injury; alternately, if you spend ten days doing nothing but resting, it heals on its own."),
            new Percentile(35,49,"*Minor Internal Injury.* Whenever you attempt an action in combat, you must make a DC 10 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, heals the internal injury; alternately, if you spend ten days doing nothing but resting, it heals on its own."),
            new Percentile(50,64,"*Horrible Scar.* You are disfigured to the extent that the wound can't be easily concealed. You have disadvantage on Charisma (Persuasion) checks and advantage on Charisma (Intimidation) checks. Magical healing of 6th level or higher, such as heal and regenerate, removes the scar."),
            new Percentile(65,79,"*Festering Wound.* Your hit point maximum is reduced by 1 every 24 hours the wound persists. If your hit point maximum drops to 0, you die. The wound heals if you receive magical healing. Alternatively, someone can tend to the wound and make a DC 15 Wisdom (Medicine) check once every 24 hours. After ten successes, the wound heals."),
            new Percentile(80,99,"*Minor Scar.* The scar doesn't have any adverse effect. Magical healing of 6th level or higher, such as heal and regenerate, removes the scar.")
        };

        public SlashingInjury()
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