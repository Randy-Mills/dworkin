using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.WildMagic
{
    ///
    /// Table by u/Darkstar559
    ///
    public class IzzetMagic : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,1,"Apply lightning type to the spell you cast."),
            new Percentile(2,3,"For the next minute, you can teleport up to 20 feet as a bonus action on each of your turns."),
            new Percentile(4,5,"You can take one additional action immediately."),
            new Percentile(6,7,"You teleport up to 60 feet to an unoccupied space of your choice that you can see."),
            new Percentile(8,9,"Your body turns to lightning, gain resistance to all damage for the next minute."),
            new Percentile(10,11,"You cast Haste on a random creature within 60 feet of you."),
            new Percentile(12,13,"You can't speak for the next minute. Whenever you try, sparks vomit out of your mouth."),
            new Percentile(14,15,"Maximize the damage of the next damaging spell you cast within the next minute."),
            new Percentile(16,17,"Up to three creatures you choose within 30 feet of you take 4d10 lightning damage."),
            new Percentile(18,19,"For the next minute, you must shout when you speak and your voice echos like thunder."),
            new Percentile(20,21,"Apply fire type to the spell you just cast."),
            new Percentile(22,23,"You burst into flames taking 2d6 damage."),
            new Percentile(24,25,"For the next minute, any flammable object you touch that isn't being worn or carried by another creature bursts into flame."),
            new Percentile(26,27,"You cast Fireball as a 3rd-level spell centered on yourself."),
            new Percentile(28,29,"You cast Fireball as a 5th-level spell."),
            new Percentile(30,31,"Your clothes start to slowly melt as if made of wax."),
            new Percentile(32,33,"You turn into a small sentient bonfire until the start of your next turn. While a bonfire, you are incapacitated and have a vulnerability to all damage. If you drop to 0 hit points, your fire goes out, and your form reverts."),
            new Percentile(34,35,"Whatever you are touching is cursed with a permanent continual flame."),
            new Percentile(36,37,"You are surrounded by a crown of will-o-wisp fire. If you cast a spell they fade to nothing."),
            new Percentile(38,39,"You cast Grease centered on yourself."),
            new Percentile(40,41,"Apply Ice type to the spell you cast."),
            new Percentile(42,43,"The temperature in a 50-foot radius drops sharply, whenever an individual in this area of cold is attacked the attacker has advantage."),
            new Percentile(44,45,"Your skin turns a vibrant shade of blue. A Remove Curse spell can end this effect."),
            new Percentile(46,47,"Your Veins turn an icy blue for next minute. During that time, you have advantage on Constitution checks."),
            new Percentile(48,49,"You cast Mirror Image. The images (and you) appear to be made of Ice."),
            new Percentile(50,51,"You clothes and armor permanently turn transparent with an icy sheen."),
            new Percentile(52,53,"You cast Armor of Agathys on yourself."),
            new Percentile(54,55,"Each creature within 30 feet of you becomes invisible for the next minute. The invisibility ends on a creature when it attacks or casts a spell."),
            new Percentile(56,57,"You cast a cone of cold in a random direction."),
            new Percentile(58,59,"Your movements are slowed, reduce your movement speed by half and move in slow motion for an hour. You may not take bonus actions or hold spells in combat during this time."),
            new Percentile(60,61,"Apply Acid type to the spell you just cast."),
            new Percentile(62,63,"You vent noxious vapors in a random direction. Any creatures who enter the cloud become poisoned for 1d4 hours."),
            new Percentile(64,65,"You are immune to being intoxicated by alcohol for the next 5d6 days."),
            new Percentile(66,67,"Corrosive acid explodes in a nova around you. You and all creatures within 30 feet of you gain vulnerability to piercing damage for the next minute."),
            new Percentile(68,69,"You become extremely sickly for the next day. Your hair falls out but grows back within 24 hours, your skin takes on a sickly color, and every time you do an action you must roll an 8 or higher CON save or vomit."),
            new Percentile(70,71,"You cast Polymorph on yourself. If you fail the saving throw, you turn into a small ooze for the spell's duration."),
            new Percentile(72,73,"You cast Acid arrow at the furthest target from you that is in range. You regain health points equal to all damage done by this spell."),
            new Percentile(74,75,"You are convinced the floor is made of corrosive acid until the end of your next turn."),
            new Percentile(76,77,"If you die within the next minute, your body turns into goo and immediately rebuilds itself as if by the Reincarnate spell."),
            new Percentile(78,79,"Your body becomes an amorphous blob of slime and increases by one size category for the next minute."),
            new Percentile(80,81,"Illusory sparks, fire, icy sheens, and acidic hisses occur at random within 10 feet of you for the next hour."),
            new Percentile(82,83,"For the next minute all lightning, fire, cold, and acid damage heals you instead of damaging you."),
            new Percentile(84,85,"For the next minute, all spells you cast have their damage type randomized using 1d4 to lightning, fire, cold, and acid damage types. This does not change the amount of damage done."),
            new Percentile(86,87,"Create an elemental dead zone with a 15-foot radius, where no elements can be cast, created, or exist."),
            new Percentile(88,89,"You cast Chaos Bolt."),
            new Percentile(90,91,"You are transported to the Astral Plane until the end of your next turn, after which time you return to the space you previously occupied or the nearest unoccupied space if that space is occupied."),
            new Percentile(92,93,"An Elemental chosen and controlled by the DM appears in an unoccupied space within 5 feet of you, then disappears I minute later."),
            new Percentile(94,95,"All spells cast in the next minute trigger the wild magic table."),
            new Percentile(96,97,"You regain all expended spell slots."),
            new Percentile(98,99,"A massive weird controlled by the DM appears in a space within 5 feet of you, then disappears 1 minute later.")
        };

        public IzzetMagic()
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