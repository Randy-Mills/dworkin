using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Madness
{
    public class IndefiniteMadness : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,14,"*Flaw:* “Being drunk keeps me sane.”"),
            new Percentile(15,24,"*Flaw:* “I keep whatever I find.”"),
            new Percentile(25,29,"*Flaw:* “I try to become more like someone else I know—adopting his or her style of dress, mannerisms, and name.”"),
            new Percentile(30,34,"*Flaw:* “I must bend the truth, exaggerate, or outright lie to be interesting to other people.”"),
            new Percentile(35,44,"*Flaw:* “Achieving my goal is the only thing of interest to me, and I’ll ignore everything else to pursue it.”"),
            new Percentile(45,49,"*Flaw:* “I find it hard to care about anything that goes on around me.”"),
            new Percentile(50,54,"*Flaw:* “I don’t like the way people judge me all the time.”"),
            new Percentile(55,69,"*Flaw:* “I am the smartest, wisest, strongest, fastest, and most beautiful person I know.”"),
            new Percentile(70,79,"*Flaw:* “I am convinced that powerful enemies are hunting me, and their agents are everywhere I go. I am sure they’re watching me all the time.”"),
            new Percentile(80,84,"*Flaw:* “There’s only one person I can trust. And only I can see this Special friend.”"),
            new Percentile(85,94,"*Flaw:* “I can’t take anything seriously. The more serious the situation, the funnier I find it.”"),
            new Percentile(95,99,"*Flaw:* “I’ve discovered that I really like killing people.”")
        };

        public IndefiniteMadness()
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