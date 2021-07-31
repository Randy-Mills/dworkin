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
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}