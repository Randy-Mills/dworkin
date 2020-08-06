using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.WildMagic
{
    public class WildMagic : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,1,"Roll on this table at the start of each of your turns for the next minute, ignoring this result on subsequent rolls."),
            new Percentile(2,3,"For the next minute, you can see any invisible creature if you have line of sight to it."),
            new Percentile(4,5,"A modron chosen and controlled by the DM appears in an unoccupied space within 5 feet of you, then disappears I minute later."),
            new Percentile(6,7,"You cast Fireball as a 3rd-level spell centered on yourself."),
            new Percentile(8,9,"You cast Magic Missile as a 5th-level spell."),
            new Percentile(10,11,"Roll a d10. Your height changes by a number of inches equal to the roll. If the roll is odd, you shrink. If the roll is even, you grow."),
            new Percentile(12,13,"You cast Confusion centered on yourself."),
            new Percentile(14,15,"For the next minute, you regain 5 hit points at the start of each of your turns."),
            new Percentile(16,17,"You grow a long beard made of feathers that remains until you sneeze, at which point the feathers explode out from your face."),
            new Percentile(18,19,"You cast Grease centered on yourself."),
            new Percentile(20,21,"Creatures have disadvantage on saving throws against the next spell you cast in the next minute that involves a saving throw."),
            new Percentile(22,23,"Your skin turns a vibrant shade of blue. A Remove Curse spell can end this effect."),
            new Percentile(24,25,"An eye appears on your forehead for the next minute. During that time, you have advantage on Wisdom (Perception) checks that rely on sight."),
            new Percentile(26,27,"For the next minute, all your spells with a casting time of 1 action have a casting time of 1 bonus action."),
            new Percentile(28,29,"You teleport up to 60 feet to an unoccupied space of your choice that you can see."),
            new Percentile(30,31,"You are transported to the Astral Plane until the end of your next turn, after which time you return to the space you previously occupied or the nearest unoccupied space if that space is occupied."),
            new Percentile(32,33,"Maximize the damage of the next damaging spell you cast within the next minute."),
            new Percentile(34,35,"Roll a d10. Your age changes by a number of years equal to the roll. If the roll is odd, you get younger (minimum 1 year old). If the roll is even, you get older."),
            new Percentile(36,37,"1d6 flumphs controlled by the DM appear in unoccupied spaces within 60 feet of you and are frightened of you. They vanish after 1 minute."),
            new Percentile(38,39,"You regain 2d10 hit points."),
            new Percentile(40,41,"You turn into a potted plant until the start of your next turn. While a plant, you are incapacitated and have vulnerability to all damage. If you drop to 0 hit points, your pot breaks, and your form reverts."),
            new Percentile(42,43,"For the next minute, you can teleport up to 20 feet as a bonus action on each of your turns."),
            new Percentile(44,45,"You cast Levitate on yourself."),
            new Percentile(46,47,"A unicorn controlled by the DM appears in a space within 5 feet of you, then disappears 1 minute later."),
            new Percentile(48,49,"You can't speak for the next minute. Whenever you try, pink bubbles float out of your mouth."),
            new Percentile(50,51,"A spectral shield hovers near you for the next minute, granting you a +2 bonus to AC and immunity to Magic Missile."),
            new Percentile(52,53,"You are immune to being intoxicated by alcohol for the next 5d6 days."),
            new Percentile(54,55,"Your hair falls out but grows back within 24 hours."),
            new Percentile(56,57,"For the next minute, any flammable object you touch that isn't being worn or carried by another creature bursts into flame."),
            new Percentile(58,59,"You regain your lowest-level expended spell slot."),
            new Percentile(60,61,"For the next minute, you must shout when you speak."),
            new Percentile(62,63,"You cast Fog Cloud centered on yourself."),
            new Percentile(64,65,"Up to three creatures you choose within 30 feet of you take 4d10 lightning damage."),
            new Percentile(66,67,"You are frightened by the nearest creature until the end of your next turn."),
            new Percentile(68,69,"Each creature within 30 feet of you becomes invisible for the next minute. The invisibility ends on a creature when it attacks or casts a spell."),
            new Percentile(70,71,"You gain resistance to all damage for the next minute."),
            new Percentile(72,73,"A random creature within 60 feet of you becomes poisoned for 1d4 hours."),
            new Percentile(74,75,"You glow with bright light in a 30-foot radius for the next minute. Any creature that ends its turn within 5 feet of you is blinded until the end of its next turn."),
            new Percentile(76,77,"You cast Polymorph on yourself. If you fail the saving throw, you turn into a sheep for the spell's duration."),
            new Percentile(78,79,"Illusory butterflies and flower petals flutter in the air within 10 feet of you for the next minute."),
            new Percentile(80,81,"You can take one additional action immediately."),
            new Percentile(82,83,"Each creature within 30 feet of you takes 1d10 necrotic damage. You regain hit points equal to the sum of the necrotic damage dealt."),
            new Percentile(84,85,"You cast Mirror Image."),
            new Percentile(86,87,"You cast Fly on a random creature within 60 feet of you."),
            new Percentile(88,89,"You become invisible for the next minute. During that time, other creatures can't hear you. The invisibility ends if you attack or cast a spell."),
            new Percentile(90,91,"If you die within the next minute, you immediately come back to life as if by the Reincarnate spell."),
            new Percentile(92,93,"Your size increases by one size category for the next minute."),
            new Percentile(94,95,"You and all creatures within 30 feet of you gain vulnerability to piercing damage for the next minute."),
            new Percentile(96,97,"You are surrounded by faint, ethereal music for the next minute."),
            new Percentile(98,99,"You regain all expended sorcery points.")
        };

        public WildMagic()
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