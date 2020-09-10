using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Injury
{
    public class NecroticInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Spiritual Injury.* You are afflicted with intense apathy and depression. You have disadvantage on Intelligence, Wisdom, and Charisma ability checks and Intelligence, Wisdom, and Charisma saving throws. Magic such as the heal or regenerate spell can resolve your spiritual injury, but such spells must be cast by a cleric, druid, or other class that uses divine magic."),
            new Percentile(5,9,"*Withered Hand.* You lose a hand. You can no longer hold anything with two hands, and you can hold only a single object at a time. Magic such as the regenerate spell can restore the lost appendage."),
            new Percentile(10,14,"*Withered Foot.* Your speed on foot is halved, and you must use a cane or crutch to move. You fall prone after using the Dash action. You have disadvantage on Dexterity checks made to balance. Magic such as the regenerate spell can restore the lost appendage."),
            new Percentile(15,19,"*Major Organ Necrosis.* Whenever you attempt an action in combat, you must make a DC 15 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, cures the Major Organ Necrosis."),
            new Percentile(20,34,"*Minor Organ Necrosis.* Whenever you attempt an action in combat, you must make a DC 10 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, cures the Major Organ Necrosis."),
            new Percentile(35,49,"*Necrotic Stench.* You smell like rotting flesh. You have disadvantage on Charisma (Persuasion) checks. Magical healing of 6th level or higher, such as heal and regenerate, removes the smell."),
            new Percentile(50,64,"*Necrotizing Wound.* Your hit point maximum is reduced by 1 every 24 hours the wound persists. If your hit point maximum drops to 0, you die. The wound heals if you receive magical healing. Alternatively, someone can tend to the wound and make a DC 15 Wisdom (Medicine) check once every 24 hours. After ten successes, the wound heals."),
            new Percentile(65,79,"*Inflammation.* Your muscles are irritated and inflamed. You have disadvantage on strength checks. Magical healing resolves the inflammation. Alternately, it will resolve on its own in two weeks."),
            new Percentile(80,99,"*Necrotic Discoloration.* You get white and gray spots on your cheeks. The spots don't have any adverse effect. Magical healing of 6th level or higher, such as heal and regenerate, removes the spots.")
        };

        public NecroticInjury()
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