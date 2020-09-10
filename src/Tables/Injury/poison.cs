using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Injury
{
    public class PoisonInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Systemic Damage.* You have disadvantage on Strength, Dexterity, and Constitution ability checks and Strength, Dexterity, and Constitution saving throws. Magic such as the regenerate spell cures this damage."),
            new Percentile(5,9,"*Major Liver Damage.* When you complete a long rest, you must succeed at a Constitution saving throw DC 15 or gain the poisoned condition until you complete a long rest. Additionally, whenever you take poison damage, you take an additional 3 (1d6) poison damage. Anytime you drink alcohol or take another drug, you take 3 (1d6) poison damage. Magic such as the regenerate spell can cure your liver failure."),
            new Percentile(10,14,"*Minor Liver Damage.* When you complete a long rest, you must succeed at a Constitution saving throw DC 10 or gain the poisoned condition until you complete a long rest. Additionally, whenever you take poison damage, you take an additional 2 (1d4) poison damage. Anytime you drink alcohol or take another drug, you take 2 (1d4) poison damage. Magic such as the regenerate spell can cure your liver failure."),
            new Percentile(15,19,"*Major Kidney Failure.* When you complete a long rest, you must succeed at a Constitution saving throw DC 15 or gain the poisoned condition until you complete a long rest. Magic such as the regenerate spell can cure your kidney failure. Alternatively, someone can tend to the kidney failure and make a DC 15 Wisdom (Medicine) check once every week. After ten successes, the kidney failure is resolved."),
            new Percentile(20,34,"*Minor Kidney Failure.* When you complete a long rest, you must succeed at a Constitution saving throw DC 10 or gain the poisoned condition until you complete a long rest. Magic such as the regenerate spell can cure your kidney failure. Alternatively, someone can tend to the kidney failure and make a DC 15 Wisdom (Medicine) check once every week. After six successes, the kidney failure is resolved."),
            new Percentile(35,49,"*Cardiac Injury.* You gain a level of exhaustion which cannot be removed by normal means. If you fail a saving throw against fear or fear effects, you gain another level of exhaustion that can be removed by normal means. Magic such as the regenerate spell can heal your cardiac damage."),
            new Percentile(50,64,"*Vertigo.* You have disadvantage on Dexterity checks. Magic such as the regenerate spell can cure your vertigo. Alternatively, it will resolve on its own in 8 weeks."),
            new Percentile(65,79,"*Nausea.* You have disadvantage on Constitution checks. Magical healing cures your nausea. Alternatively, it will resolve on its own in 4 weeks."),
            new Percentile(80,99,"*Minor nausea.* You must succeed at a DC 10 Constitution saving throw before you can consume food. Magical healing cures your nausea. Alternatively, it will resolve on its own in 1 week.")
        };

        public PoisonInjury()
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