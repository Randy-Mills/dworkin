using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Races
{
    public class Races : ITable
    {
        private Percentile[] _table = {

            // All odd races are 1 in 1000 or 0.1%
            new Percentile(0,1,"Grung"),
            new Percentile(2,3,"Locathah"),
            new Percentile(4,5,"Verdan"),
            new Percentile(6,7,"Simic Hybrid"),
            new Percentile(8,9,"Vedalken"),
            new Percentile(10,11,"Centaur"),
            new Percentile(12,13,"Loxodon"),
            new Percentile(14,15,"Minotaur"),
            new Percentile(16,17,"Gith"),
            new Percentile(18,19,"Shifter"),
            new Percentile(20,21,"Warforged"),
            new Percentile(22,23,"Changeling"),
            new Percentile(24,25,"Kalashtar"),
            new Percentile(26,27,"Orc of Eberron"),
            new Percentile(28,29,"Tortle"),
            new Percentile(30,31,"Feral Tiefling"),
            new Percentile(32,33,"Tabaxi"),
            new Percentile(34,35,"Triton"),
            new Percentile(36,37,"Yuan-ti Pureblood"),
            new Percentile(38,39,"Orc"),
            new Percentile(40,41,"Lizardfolk"),
            new Percentile(42,43,"Kobold"),
            new Percentile(44,45,"Goblin"),
            new Percentile(46,47,"Hobgoblin"),
            new Percentile(48,49,"Kenku"),
            new Percentile(50,51,"Firbolg"),
            new Percentile(52,53,"Bugbear"),
            new Percentile(54,55,"Aasimar"),
            new Percentile(56,57,"Aarakocra"),
            new Percentile(58,59,"Genasi"),
            new Percentile(60,61,"Goliath"),
            new Percentile(62,63,"Leonin"),
            new Percentile(64,65,"Satyr"),
            new Percentile(66,67,"Eldar"),
            new Percentile(68,69,"Half-Orc"),

            // Humans are 23% chance
            new Percentile(69,300,"Human"),

            // Al other races are 10% chance
            new Percentile(300,400,"Tiefling"),
            new Percentile(401,500,"Halfling"),
            new Percentile(501,600,"Half-Elf"),
            new Percentile(601,700,"Gnome"),
            new Percentile(701,800,"Elf"),
            new Percentile(801,900,"Dwarf"),
            new Percentile(901,1000,"Dragonborn")

        };

        public Races()
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
            return response.ToLower();
        }
    }
}