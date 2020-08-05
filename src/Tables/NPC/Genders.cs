using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Genders
{
    public class Genders : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,500,"male"),
            new Percentile(501,998,"female"),
            new Percentile(999, 1000,"non-binary")
        };

        public Genders()
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