using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Injury
{
    public class RadiantInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Blindness.* Your eyes are destroyed; you gain the blinded condition. Magic such as the regenerate spell can restore your sight."),
            new Percentile(5,9,"*Partial Blindness.* Your retinas are damaged; you have disadvantage on Wisdom (Perception) checks that rely on sight and on ranged attack rolls. Magic such as the regenerate spell can restore the lost eye. If you have already suffered partial blindness, you're blinded."),
            new Percentile(10,14,"*Third Degree Burns.* You have disadvantage on ability checks and Constitution saving throws. If you fail a saving throw against an effect that causes fire damage, you also gain the stunned condition until the end of your next turn. Magic such as the regenerate spell cures this damage. Alternatively, someone can tend to the burns and make a DC 15 Wisdom (Medicine) check once every week. After ten successes, the burns heal. If you already have third degree burns, you instead suffer fourth degree burns as per the Fire chart."),
            new Percentile(15,19,"*Second Degree Burns.* You have disadvantage on Strength, Dexterity, and Constitution checks. Magic such as the regenerate spell cures this damage. Alternately, they will heal on their own in 4 weeks. If you already have second degree burns, you instead suffer third degree burns."),
            new Percentile(20,34,"*Large Skin Tumors.* You develop several large, painful skin tumors. You have disadvantage on Charisma and Wisdom checks. Magic such as the regenerate spell cures your large skin tumors. If your large skin tumors are not cured within six months, you develop Systemic Damage as per the poison table."),
            new Percentile(35,49,"*Small Skin Tumors.* You develop several small, painless skin tumor. You have disadvantage on Charisma checks. Magic such as the regenerate spell cures your small skin tumors. If your small skin tumors are not cured within one year, you develop Large Skin Tumors."),
            new Percentile(50,64,"*Blisters. You have severe blisters.* You have disadvantage on Dexterity checks. The blisters heal if you receive magical healing. Alternatively, someone can tend to the blisters and make a DC 15 Wisdom (Medicine) check once every 24 hours. After seven successes, the blisters heal."),
            new Percentile(65,79,"*First Degree Burns.* You have superficial but painful burns. Whenever you take fire damage, you take an additional 1 point of damage. Magical healing cures the burns; alternately, they will heal on their own in 2 weeks. If you already have first degree burns, you instead suffer second degree burns."),
            new Percentile(80,99,"*Hair Loss and Cosmetic Damage.* Visible hair on your body burns away but will grow back as normal. If you have any exposed tattoos, they fade as if exposed to 10 years of sunlight.")
        };

        public RadiantInjury()
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