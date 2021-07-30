using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;
using System.IO;

namespace Dworkin.Tables.Races
{
    public class Races : ITable
    {
        private const string _tableJson = "/Tables/TableJson/npc_races.json";

        public Races()
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