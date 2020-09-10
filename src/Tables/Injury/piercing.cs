using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Injury
{
    public class PiercingInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Lose an Eye.* You have disadvantage on Wisdom (Perception) checks that rely on sight and on ranged attack rolls. Magic such as the regenerate spell can restore the lost eye. If you have no eyes left after sustaining this injury, you're blinded."),
            new Percentile(5,9,"*Throat Injury.* You gain a level of exhaustion which cannot be removed by normal means. You also have disadvantage on constitution checks. Magic such as the regenerate spell can heal your throat injury."),
            new Percentile(10,14,"*Groin Injury.* Your speed on foot is halved, and you must use a cane or crutch to move. You cannot take the Dash action. You are also sterile. Magic such as the regenerate spell can heal the groin injury."),
            new Percentile(15,19,"*Cardiac Injury.* You gain a level of exhaustion which cannot be removed by normal means. If you fail a saving throw against fear or fear effects, you gain another level of exhaustion that can be removed by normal means. Magic such as the regenerate spell can heal your cardiac damage."),
            new Percentile(20,34,"*Organ Damage.* Whenever you attempt an action in combat, you must make a DC 15 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magic such as the regenerate spell can cure your organ damage. Alternatively, someone can tend to the organ damage and make a DC 15 Wisdom (Medicine) check once every day. After ten successes, the organ damage is resolved."),
            new Percentile(35,49,"*Pierced Stomach.* When you complete a long rest, you must succeed at a Constitution saving throw DC 10 or gain the poisoned condition until you complete a long rest. Magical healing of 6th level or higher, such as heal and regenerate, heals the pierced stomach, or if you spend ten days doing nothing but resting, it heals on its own."),
            new Percentile(50,64,"*Horrible Scar.* You are disfigured to the extent that the wound can't be easily concealed . You have disadvantage on Charisma (Persuasion) checks and advantage on Charisma (Intimidation) checks. Magical healing of 6th level or higher, such as heal and regenerate, removes the scar."),
            new Percentile(65,79,"*Festering Wound.* Your hit point maximum is reduced by 1 every 24 hours the wound persists. If your hit point maximum drops to 0, you die. The wound heals if you receive any magical healing. Alternatively, someone can tend to the wound and make a DC 15 Wisdom (Medicine) check once every 24 hours. After ten successes, the wound heals."),
            new Percentile(80,99,"*Minor Scar.* The scar doesn't have any adverse effect. Magical healing of 6th level or higher, such as heal and regenerate, removes the scar.")
        };

        public PiercingInjury()
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