using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;

namespace Dworkin.Tables.AppearanceAdjectives
{
    public class AppearanceAdjectives : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,1,"disheveled"),
            new Percentile(1,2,"jovial"),
            new Percentile(2,3,"filthy"),
            new Percentile(3,4,"clean"),
            new Percentile(4,5,"tense"),
            new Percentile(5,6,"boorish"),
            new Percentile(6,7,"dull"),
            new Percentile(7,8,"confident"),
            new Percentile(8,9,"snobbish"),
            new Percentile(9,10,"scruffy"),
            new Percentile(10,11,"elegant")
        };

        public AppearanceAdjectives()
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