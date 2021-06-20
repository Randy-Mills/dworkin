using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;

namespace Dworkin.Tables.Injury
{
    public class AcidInjury : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,4,"*Blindness.* Your eyes are destroyed; you gain the blinded condition. Magic such as the regenerate spell can restore your sight."),
            new Percentile(5,9,"*Partial Blindness.* Your eyes are damaged; you have disadvantage on Wisdom (Perception) checks that rely on sight and on ranged attack rolls. Magic such as the regenerate spell can heal the damage to your eyes. If you have already suffered partial blindness, you're blinded."),
            new Percentile(10,14,"*Destroyed Hand.* You can no longer hold anything with two hands, and you can hold only a single object at a time. Magic such as the regenerate spell can restore the lost appendage."),
            new Percentile(15,19,"*Destroyed Foot or Leg.* Your speed on foot is halved, and you must use a crutch or cane to move. You fall prone after using the Dash action. You have disadvantage on Dexterity checks made to balance. Magic such as the regenerate spell can restore the damaged appendage."),
            new Percentile(20,34,"*Major Neuralgia.* You are in constant pain from nerve damage. Whenever you attempt an action in combat, you must make a DC 15 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn.Magical healing of 6th level or higher, such as heal and regenerate, cures the neuralgia, or if you spend twenty days doing nothing but resting it resolves on its own."),
            new Percentile(35,49,"*Minor Neuralgia.* You are in constant pain from nerve damage. Whenever you attempt an action in combat, you must make a DC 10 Constitution saving throw. On a failed save, you lose your action and can't use reactions until the start of your next turn.Magical healing of 6th level or higher, such as heal and regenerate, cures the neuralgia, or if you spend ten days doing nothing but resting it resolves on its own."),
            new Percentile(50,64,"*Horrible Disfigurement.* You have acid burns to the extent that the scars can't be easily concealed. You have disadvantage on Charisma (Persuasion) checks and advantage on Charisma (Intimidation) checks. Magical healing of 6th level or higher, such as heal and regenerate, removes the acid burn scar."),
            new Percentile(65,79,"*Blisters.* You have severe blisters. You have disadvantage on Dexterity checks. The blisters heal if you receive magical healing. Alternatively, someone can tend to the blisters and make a DC 15 Wisdom (Medicine) check once every 24 hours. After seven successes, the blisters heal."),
            new Percentile(80,99,"*Minor Disfigurement.* You have acid burn scars, but they don’t have any adverse effect. Magical healing of 6th level or higher, such as heal and regenerate, removes the acid burn scars.")
        };

        public AcidInjury()
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