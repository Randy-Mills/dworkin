using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.WildMagic
{
    ///
    /// Table by u/Darkstar559
    ///
    public class IzzetMagic : ITable
    {
        private const string _tableJson = "/Tables/TableJson/wild_magic_izzet.json";

        public IzzetMagic()
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
            return response.ToLower();
        }

        private int GetTableSize(Table table)
        {
            return table.entities.Sum(item => item.weight);
        }
    }
}