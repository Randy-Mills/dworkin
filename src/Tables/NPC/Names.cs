using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Names
{
    [Obsolete]
    public class Names : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,1,"Randy"),
            new Percentile(2,3,"Matt"),
            new Percentile(4,5,"Melanie"),
            new Percentile(6,7,"Josh"),
            new Percentile(8,9,"Ryan"),
            new Percentile(10,11,"Colin"),
            new Percentile(12,13,"Chris")
        };

        public Names()
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