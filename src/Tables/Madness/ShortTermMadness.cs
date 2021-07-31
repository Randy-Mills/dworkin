using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.Madness
{
    public class ShortTermMadness : ITable
    {
        private const string _tableJson = "/Tables/TableJson/madness_short_term.json";

        public ShortTermMadness()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}