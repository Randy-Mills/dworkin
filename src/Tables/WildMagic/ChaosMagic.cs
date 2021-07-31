using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.WildMagic
{
    public class ChaosMagic : ITable
    {
        private const string _tableJson = "/Tables/TableJson/wild_magic_chaos.json";

        public ChaosMagic()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}