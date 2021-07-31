using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.WildMagic
{
    public class WildMagic : ITable
    {
        private const string _tableJson = "/Tables/TableJson/wild_magic_wild_magic.json";

        public WildMagic()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}