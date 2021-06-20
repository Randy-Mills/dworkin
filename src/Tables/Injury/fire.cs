using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;

namespace Dworkin.Tables.Injury
{
    public class FireInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Lose an Eye.* You have disadvantage on Wisdom (Perception) checks that rely on sight and on ranged attack rolls. Magic such as the regenerate spell can restore the lost eye. If you have no eyes left after sustaining this injury, you're blinded."),
            new Percentile(5,9,"*Fourth Degree Burns.* You have disadvantage on ability checks and Strength, Dexterity, and Constitution saving throws. If you fail a saving throw against an effect that causes fire damage, you also gain the stunned condition until the end of your next turn. Magic such as the regenerate spell cures this damage. If you already have fourth degree burns, you must succeed at a DC 15 Constitution saving throw or die."),
            new Percentile(10,14,"*Third Degree Burns.* You have disadvantage on ability checks and Constitution saving throws. If you fail a saving throw against an effect that causes fire damage, you also gain the stunned condition until the end of your next turn. Magic such as the regenerate spell cures this damage. Alternatively, someone can tend to the burns and make a DC 15 Wisdom (Medicine) check once every week. After ten successes, the burns heal. If you already have third degree burns, you instead suffer fourth degree burns."),
            new Percentile(15,19,"*Second Degree Burns.* You have disadvantage on Strength, Dexterity, and Constitution checks. Magic such as the regenerate spell cures this damage. Alternately, they will heal on their own in 4 weeks. If you already have second degree burns, you instead suffer third degree burns."),
            new Percentile(20,34,"*Major Neuralgia.* You have constant, painful nerve damage over a large portion of your body. Whenever you attempt an action in combat, you must make a DC 15 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, cures the neuralgia, or if you spend twenty days doing nothing but resting, it resolves on its own."),
            new Percentile(35,49,"*Minor Neuralgia.* You have constant, painful nerve damage over a large portion of your body. Whenever you attempt an action in combat, you must make a DC 10 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn. Magical healing of 6th level or higher, such as heal and regenerate, cures the neuralgia, or if you spend ten days doing nothing but resting, it resolves on its own."),
            new Percentile(50,64,"*Horrible Disfigurement.* You have burn scars to the extent that can't be easily concealed. You have disadvantage on Charisma (Persuasion) checks and advantage on Charisma (Intimidation) checks. Magical healing of 6th level or higher, such as heal and regenerate, removes the burn scars."),
            new Percentile(65,79,"*Blisters.* You have severe blisters. You have disadvantage on Dexterity checks. The blisters heal if you receive magical healing. Alternatively, someone can tend to the blisters and make a DC 15 Wisdom (Medicine) check once every 24 hours. After seven successes, the blisters heal."),
            new Percentile(80,99,"*First Degree Burns.* You have superficial but painful burns. Whenever you take fire damage, you take an additional 1 point of damage. Magical healing cures the burns; alternately, they will heal on their own in 2 weeks. If you already have first degree burns, you instead suffer second degree burns.")
        };

        public FireInjury()
        {
            Table = _table;
            Max = _table[_table.Length-1].max;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public Percentile[] Table { get; set; }
        public Table MainTable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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