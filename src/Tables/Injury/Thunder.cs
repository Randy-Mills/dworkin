using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.Injury
{
    public class ThunderInjury : ITable
    {
        private const string _tableJson = "/Tables/TableJson/injury_thunder.json";

        public ThunderInjury()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}