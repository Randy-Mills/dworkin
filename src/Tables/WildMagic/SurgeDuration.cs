using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.WildMagic
{
    public class SurgeDuration : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,1,"10d100 hours have passed."),
            new Percentile(1,2,"1d4 turns have passed per level of the caster."),
            new Percentile(2,3,"They have attained fluency in 1d4 additional languages."),
            new Percentile(3,4,"They have attained fluency in one additional language."),
            new Percentile(4,5,"They have been awarded a title by royalty."),
            new Percentile(5,6,"They have been branded with a hot iron like a bull."),
            new Percentile(6,7,"They have been formally pardoned by the a king."),
            new Percentile(7,8,"They have been reduced to one hit point."),
            new Percentile(8,9,"They have been resurrected."),
            new Percentile(9,10,"They have been stabbed by a silver weapon."),
            new Percentile(10,11,"They have been tried and imprisoned for heresy."),
            new Percentile(11,12,"They have bested 10d10 warriors in single combat."),
            new Percentile(12,13,"They have bought a hugely expensive home and burned it down."),
            new Percentile(13,14,"They have broken every finger on one of their hands."),
            new Percentile(14,15,"They have built 2d10 snowmen."),
            new Percentile(15,16,"They have burned down their current home."),
            new Percentile(16,17,"They have burned themself for 2d20 total hit points of fire damage."),
            new Percentile(17,18,"They have carried a gallon of water from the sea to this spot."),
            new Percentile(18,19,"They have carried a stone from this spot to the sea."),
            new Percentile(19,20,"They have carved their full name in 10d10 different trees."),
            new Percentile(20,21,"They have circumnavigated the globe without using magic to do so."),
            new Percentile(21,22,"They have composed 3d4 sonnets."),
            new Percentile(22,23,"They have cut off 1d4 fingers."),
            new Percentile(23,24,"They have cut off their own ear."),
            new Percentile(24,25,"They have destroyed every book that he owns."),
            new Percentile(25,26,"They have destroyed every table within 1d4 miles."),
            new Percentile(26,27,"They have destroyed their most prized possession."),
            new Percentile(27,28,"They have dug a functioning and productive well on this spot."),
            new Percentile(28,29,"They have eaten 1,000 gold pieces worth of gold."),
            new Percentile(29,30,"They have eaten 1d4 pounds of soil."),
            new Percentile(30,31,"They have eaten 1d4X their weight in squirrels."),
            new Percentile(31,32,"They have eaten 2d6 pounds of cured leather."),
            new Percentile(32,33,"They have eaten an entire, live chicken."),
            new Percentile(33,34,"They have extracted 1d4 of their own teeth."),
            new Percentile(34,35,"They have felled 3d6 trees older than he is."),
            new Percentile(35,36,"They have forged a sword from meteoric iron."),
            new Percentile(36,37,"They have found a lost city hidden in the desert."),
            new Percentile(37,38,"They have founded a cult."),
            new Percentile(38,39,"They have gained a level."),
            new Percentile(39,40,"They have gone 10d10 days and nights without speaking."),
            new Percentile(40,41,"They have gone 1d4 weeks without exposure to direct sunlight."),
            new Percentile(41,42,"They have gone one full month without using magic or any magic items."),
            new Percentile(42,43,"They have had a personal audience with 1d6 different deities."),
            new Percentile(43,44,"They have hand-carved a marble statue of themself."),
            new Percentile(44,45,"They have hidden a cursed ruby beneath a tall mountain."),
            new Percentile(45,46,"They have imbibed 1d4 pints of lamp oil."),
            new Percentile(46,47,"They have imbibed 1d8 pints of their own blood."),
            new Percentile(47,48,"They have located and destroyed an artifact."),
            new Percentile(48,49,"They have lost a level."),
            new Percentile(49,50,"They have lost a total of 3d10 hit points due to burns from acid."),
            new Percentile(50,51,"They have lost a total of 3d10 hit points due to electrical damage."),
            new Percentile(51,52,"They have manually unearthed a diamond larger than their head."),
            new Percentile(52,53,"They have married."),
            new Percentile(53,54,"They have married, divorced, and remarried 1d4 times."),
            new Percentile(54,55,"They have produced an heir."),
            new Percentile(55,56,"They have razed the nearest wooden structure."),
            new Percentile(56,57,"They have remained awake for 4d6 consecutive days and nights."),
            new Percentile(57,58,"They have restored the nearest undead creature to life."),
            new Percentile(58,59,"They have retrieved a particular gold coin from the bottom of the sea."),
            new Percentile(59,60,"They have rid themself of all magic items."),
            new Percentile(60,61,"They have rid the nearest town of mice and rats."),
            new Percentile(61,62,"They have rolled less than their weight on 1d1000, one attempt per day."),
            new Percentile(62,63,"They have rolled less than their Wisdom on 1d100, one attempt per day."),
            new Percentile(63,64,"They have scaled the tallest mountian on the continent."),
            new Percentile(64,65,"They have sharpened every blade within 1d10 miles."),
            new Percentile(65,66,"They have shaved their head completely bald."),
            new Percentile(66,67,"They have shed 2d10 pounds."),
            new Percentile(67,68,"They have single-handedly dammed the nearest river."),
            new Percentile(68,69,"They have slain 1d10 undead."),
            new Percentile(69,70,"They have slain 1d6 kings."),
            new Percentile(70,71,"They have spent 1,000,000 gold pieces with nothing to show for it."),
            new Percentile(71,72,"They have spent 1d4 days and nights at the bottom of a deep well."),
            new Percentile(72,73,"They have spent a night in a sty with at least 3d10 pigs."),
            new Percentile(73,74,"They have spent a night in each of 2d6 dragons' lairs."),
            new Percentile(74,75,"They have spent an entire night at the bottom of a lake."),
            new Percentile(75,76,"They have spent an entire night naked and unprotected in snow."),
            new Percentile(76,77,"They have spent an entire night sealed in a barrel."),
            new Percentile(77,78,"They have spent an entire night up to their neck in offal."),
            new Percentile(78,79,"They have stabbed themself with a weapon that he forged."),
            new Percentile(79,80,"They have swallowed 4d10 gallons of water."),
            new Percentile(80,81,"They have swallowed a pint of molten lead."),
            new Percentile(81,82,"They have tattooed 10d100 cryptic runes on their skin."),
            new Percentile(82,83,"They have thwarted an assassination attempt against the king."),
            new Percentile(83,84,"They have triggered 1d4 additional wild surges."),
            new Percentile(84,85,"They have visited both of the world's magnetic poles."),
            new Percentile(85,86,"They have waded along the shores of 1d4 oceans."),
            new Percentile(86,87,"They have walked 10d100 miles."),
            new Percentile(87,88,"They have walked on the floor of the ocean."),
            new Percentile(88,89,"They have walked on the surface of the moon."),
            new Percentile(89,90,"They have walked the shores of hell."),
            new Percentile(90,91,"They have woven a six foot length of rope from their own hair."),
            new Percentile(91,92,"They have written their full name in 10d10 different books."),
            new Percentile(92,93,"They unearth 1d4 pounds of gold."),
            new Percentile(93,94,"Their next birthday."),
            new Percentile(94,95,"Their child produces an heir."),
            new Percentile(95,96,"One year and one day have passed."),
            new Percentile(96,97,"The current king has died."),
            new Percentile(97,98,"The next total lunar eclipse occurs."),
            new Percentile(98,99,"They have performed an exorcism on a member of the royal family."),
            new Percentile(99,100,"They have been bitten by 1d6 different lycanthropes.")
        };

        public SurgeDuration()
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