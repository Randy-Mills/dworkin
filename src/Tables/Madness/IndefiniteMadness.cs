using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.Madness
{
    public class IndefiniteMadness : ITable
    {
        private const string _tableJson = "/Tables/TableJson/madness_indefinite.json";

        public IndefiniteMadness()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}