using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Injury
{
    public class LightningInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Brain Injury.* You have suffered a brain injury. You have disadvantage on Intelligence, Wisdom, and Charisma checks, as well as Intelligence, Wisdom, and Charisma saving throws. If you fail a saving throw against bludgeoning damage, force damage, or psychic damage, you are also stunned until the end of your next turn. Magic such as the regenerate spell can restore your full brain function."),
            new Percentile(5,9,"*Explosive Grounding of the Hand.* You lose a hand. You can no longer hold anything with two hands, and you can hold only a single object at a time. Magic such as the regenerate spell can restore the lost appendage."),
            new Percentile(10,14,"*Explosive Grounding of the Foot.* You lose a foot. Your speed on foot is halved, and you must use a cane or crutch to move unless you have a peg leg or other prosthesis. You fall prone after using the Dash action. You have disadvantage on Dexterity checks made to balance. Magic such as the regenerate spell can restore the lost appendage."),
            new Percentile(15,19,"*Kidney Failure.* When you complete a long rest, you must succeed at a Constitution saving throw DC 15 or gain the poisoned condition until you complete a long rest. Magic such as the regenerate spell can cure your kidney failure. Alternatively, someone can tend to the kidney failure and make a DC 15 Wisdom (Medicine) check once every week. After ten successes, the kidney failure is resolved."),
            new Percentile(20,34,"*Arc Flash.* Roll on the fire table."),
            new Percentile(35,49,"*Cardiac Injury.* You gain a level of exhaustion which cannot be removed by normal means. If you fail a saving throw against fear or fear effects, you gain another level of exhaustion that can be removed by normal means. Magic such as the regenerate spell can heal your cardiac damage."),
            new Percentile(50,64,"*Skeletal Muscle Breakdown.* You have disadvantage on Strength checks and Strength saving throws. Magic such as the regenerate spell can cure your muscle breakdown. Alternatively, it will resolve on its own in 6 weeks."),
            new Percentile(65,79,"*Muscle Spasms.* You have disadvantage on Dexterity checks. Magical healing cures your muscle spasms. Alternatively, they will resolve on their own in 2 weeks."),
            new Percentile(80,99,"*Flash Burns.* You have superficial burns. You turn red as a lobster, but otherwise suffer no mechanical effects. Magical healing cures your flash burns. Alternatively, they will heal on their own in 2 weeks.")
        };

        public LightningInjury()
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