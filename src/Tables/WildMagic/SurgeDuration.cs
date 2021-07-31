using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.WildMagic
{
    public class SurgeDuration : ITable
    {
        private const string _tableJson = "/Tables/TableJson/wild_magic_surge_duration.json";

        public SurgeDuration()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}