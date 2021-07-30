using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.Bard
{
    public class InspirationBard : ITable
    {
        private const string _tableJson = "/Tables/TableJson/bard_inspiration.json";

        public InspirationBard()
        {
            MainTable = TableManager.BuildTable(_tableJson);
            TableSize = GetTableSize(MainTable);
            Table = TableManager.BuildTableFromJson(MainTable);
            Max = TableSize;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public Percentile[] Table { get; set; }
        public Table MainTable { get; set; }
        public int TableSize { get; set; }

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

        private int GetTableSize(Table table)
        {
            return table.entities.Sum(item => item.weight);
        }
    }
}